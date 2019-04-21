using UnityEngine;
using UnityEngine.UI;
using MarchingBytes;

public class Gold : MonoBehaviour {

    public GameObject fx;
    SoundManger sm;
    Text text;
    
    void Start()
    {       
        sm = GameObject.Find("Boat").GetComponent<SoundManger>();
        text = GameObject.Find("Coins").GetComponent<Text>();
    }

    void OnTriggerEnter(Collider boxCollider)
    {

        if (boxCollider.name == "Boat")
        {
            sm.PlaySound(0);   
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);
            text.text = (int.Parse(text.text) + 1).ToString();

			GameObject p = Instantiate(fx, transform.position, Quaternion.identity) as GameObject;
			p.GetComponent<ParticleSystem>().Play();
			Destroy(p, p.GetComponent<ParticleSystem>().main.duration);
        }
			
  
    }

}
