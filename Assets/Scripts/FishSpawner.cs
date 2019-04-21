using System.Collections;
using MarchingBytes;
using UnityEngine;
using UnityEngine.UI;

public class FishSpawner : MonoBehaviour {

    public string[] poolNames;
    public bool isSameDelay; // такая же задержка
    public float timeBeforSpawn; //Время до появления
    public float spawnDelay;
    float MinDelay;
    float MaxDelay;

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
        MinDelay = speedGame.MinFish;
        MaxDelay = speedGame.MaxFish;

        EasyObjectPool.instance.GetObjectFromPool(poolNames[Random.Range(0, poolNames.Length)], transform.position, transform.rotation);
        if(!isSameDelay)
        {
            StartCoroutine(Spawner());
        }


        transform.position = new Vector3(Random.Range(min, max), transform.position.y, transform.position.z);
    }
}
