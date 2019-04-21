using UnityEngine;
using UnityEngine.UI;
using MarchingBytes;

public class EnemyObject : MonoBehaviour {

    public GameObject fx;
    public SoundManger sm;
	private GameOver gOver;

	void Start () {
		sm = GameObject.Find("Boat").GetComponent<SoundManger>();
		gOver = GameObject.Find ("Ground").GetComponent<GameOver> ();
	}
	
	void OnTriggerEnter(Collider boxCollider)
    {
        
        if(boxCollider.name == "Boat")
        {			
			sm.PlaySound(3);	            
            //Destroy(gameObject);
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);

			gOver.gameOver = true;

			GameObject p = Instantiate(fx, transform.position, Quaternion.identity) as GameObject;
			p.GetComponent<ParticleSystem>().Play();
			Destroy(p, p.GetComponent<ParticleSystem>().main.duration);

        }	
        
    }



}
