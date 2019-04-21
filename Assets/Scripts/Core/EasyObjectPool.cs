using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MarchingBytes {

	[System.Serializable]
	public class PoolInfo {
		public string poolName;
		public GameObject prefab;
		public int poolSize;
		public bool fixedSize;
	}

	class Pool {
		private Stack<PoolObject> availableObjStack = new Stack<PoolObject>();

		private bool fixedSize;
		private GameObject poolObjectPrefab;
		private int poolSize;
		private string poolName;

		public Pool(string poolName, GameObject poolObjectPrefab, int initialCount, bool fixedSize) {
			this.poolName = poolName;
			this.poolObjectPrefab = poolObjectPrefab;
			this.poolSize = initialCount;
			this.fixedSize = fixedSize;
			//populate the pool
			for(int index = 0; index < initialCount; index++) {
				AddObjectToPool(NewObjectInstance());
			}
		}

		//o(1)
		private void AddObjectToPool(PoolObject po) {
			//add to pool
			po.gameObject.SetActive(false);
			availableObjStack.Push(po);
			po.isPooled = true;
		}
		
		private PoolObject NewObjectInstance() {
			GameObject go = (GameObject)GameObject.Instantiate(poolObjectPrefab);
			PoolObject po = go.GetComponent<PoolObject>();
			if(po == null) {
				po = go.AddComponent<PoolObject>();
			}
			//set name
			po.poolName = poolName;
			return po;
		}

		//o(1)
		public GameObject NextAvailableObject(Vector3 position, Quaternion rotation) {
			PoolObject po = null;
			if(availableObjStack.Count > 0) {
				po = availableObjStack.Pop();
			} else if(fixedSize == false) {
				//increment size var, this is for info purpose only
				poolSize++;
				//create new object
				po = NewObjectInstance();
			} 
			
			GameObject result = null;
			if(po != null) {
				po.isPooled = false;
				result = po.gameObject;
				result.SetActive(true);
				
				result.transform.position = position;
				result.transform.rotation = rotation;
			}
			
			return result;
		} 
		
		//o(1)
		public void ReturnObjectToPool(PoolObject po) {
			
			if(poolName.Equals(po.poolName)) {
				
				/* we could have used availableObjStack.Contains(po) to check if this object is in pool.
				 * While that would have been more robust, it would have made this method O(n) 
				 */
				if(!po.isPooled) {
					AddObjectToPool(po);
				}
				
			} 
		}
	}

	/// <summary>
	/// Easy object pool.
	/// </summary>
	public class EasyObjectPool : MonoBehaviour {

		public static EasyObjectPool instance;
		[Header("Editing Pool Info value at runtime has no effect")]
		public PoolInfo[] poolInfo;

		//mapping of pool name vs list
		private Dictionary<string, Pool> poolDictionary  = new Dictionary<string, Pool>();
		
		// Use this for initialization
		void Start () {
			//set instance
			instance = this;
			//check for duplicate names
			CheckForDuplicatePoolNames();
			//create pools
			CreatePools();
		}
		
		private void CheckForDuplicatePoolNames() {
			for (int index = 0; index < poolInfo.Length; index++) {
				string poolName = poolInfo[index].poolName;
			}
		}

		private void CreatePools() {
			foreach (PoolInfo currentPoolInfo in poolInfo) {
				
				Pool pool = new Pool(currentPoolInfo.poolName, currentPoolInfo.prefab, 
				                     currentPoolInfo.poolSize, currentPoolInfo.fixedSize);

				
			
				//add to mapping dict
				poolDictionary[currentPoolInfo.poolName] = pool;
			}
		}


		/* Returns an available object from the pool 
		OR 
		null in case the pool does not have any object available & can grow size is false.
		*/
		public GameObject GetObjectFromPool(string poolName, Vector3 position, Quaternion rotation) {
			GameObject result = null;
			
			if(poolDictionary.ContainsKey(poolName)) {
				Pool pool = poolDictionary[poolName];
				result = pool.NextAvailableObject(position,rotation);		
			} 

			
			return result;
		}

		public void ReturnObjectToPool(GameObject go) {
			PoolObject po = go.GetComponent<PoolObject>();
			if(po != null) {
				if(poolDictionary.ContainsKey(po.poolName)) {
					Pool pool = poolDictionary[po.poolName];
					pool.ReturnObjectToPool(po);
				} 
			}
		}

	}
}
