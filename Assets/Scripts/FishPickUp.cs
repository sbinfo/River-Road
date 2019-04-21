using UnityEngine;
using UnityEngine.UI;
using MarchingBytes;

public class FishPickUp : MonoBehaviour
{

    Text FishCounts;
    public GameObject fx;
    private SoundManger sm;
    void Start()
    {
        FishCounts = GameObject.Find("FishCount").GetComponent<Text>();
        sm = GameObject.Find("Boat").GetComponent<SoundManger>();
    }

    void OnTriggerEnter(Collider objCollider)
    {
        if (objCollider.name == "Boat")
        {
            sm.PlaySound(1);

            FishCounts.text = (int.Parse(FishCounts.text) + 1).ToString();
            
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);

            GameObject p = Instantiate(fx, transform.position, Quaternion.identity) as GameObject;
            p.GetComponent<ParticleSystem>().Play();
            Destroy(p, p.GetComponent<ParticleSystem>().main.duration);
        }

		if (objCollider.tag == "Rock")
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);
    }

}