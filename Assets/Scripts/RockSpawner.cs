using System.Collections;
using MarchingBytes;
using UnityEngine;
using UnityEngine.UI;

public class RockSpawner : MonoBehaviour {

    public string[] poolNames;
    public bool isSameDelay; // такая же задержка
    public float timeBeforSpawn; //Время до появления
    public float spawnDelay;
    float MinDelay = 0;
    float MaxDelay = 3;

    public float min = -4f;
    public float max = 3.23f;

    public SpeedGame speedGame;

    void Start()
    {
        if(isSameDelay)
        {
            InvokeRepeating("Spawn", timeBeforSpawn, spawnDelay);
        }
        else
        {
            StartCoroutine(Spawner());
        }

    }


    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(Random.Range(MinDelay, MaxDelay));
        Spawn();
    }

    void Spawn()
    {
        MinDelay = speedGame.MinR;
        MaxDelay = speedGame.MaxR;

        EasyObjectPool.instance.GetObjectFromPool(poolNames[Random.Range(0, poolNames.Length)], transform.position, transform.rotation);
       
        if(!isSameDelay)
        {
            StartCoroutine(Spawner());
        }

        transform.position = new Vector3(Random.Range(min,max), transform.position.y, transform.position.z);
    }
}
