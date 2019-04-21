using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedGame : MonoBehaviour {

    
    public Text text;
    public float speed;
    public float MinR;
    public float MaxR;
    public float MinFish;
    public float MaxFish;
    void Start()
    {
         MinR = 1;
         MaxR = 2;
         MinFish = 0.8f;
         MaxFish = 1.5f;
         StartCoroutine(Fun());
    }

    IEnumerator Fun()
    {
        yield return new WaitForSeconds(3f);
        SpeedCntrl();
        
    }


    void SpeedCntrl()
    {
        if (int.Parse(text.text) >= 10 && int.Parse(text.text) < 20)
        {
            speed = 16;
            MaxR = 0.8f;
            MinR = 0.7f;

            MaxFish = 1.3f;
        }
        else if (int.Parse(text.text) >= 20 && int.Parse(text.text) < 40)
        {
            speed = 18;
            MaxR = 0.7f;
            MinR = 0.6f;

            MaxFish = 1f;
        }
        else if (int.Parse(text.text) >= 40 && int.Parse(text.text) < 60)
        {
            speed = 20;
            MaxR = 0.6f;

            MaxFish = 0.8f;
        }
        else if (int.Parse(text.text) >= 60 && int.Parse(text.text) < 80)
        {
            speed = 22;
            MinR = 0.5f;

            MinFish = 0.7f;

        }
        else if (int.Parse(text.text) >= 80 && int.Parse(text.text) < 100)
        {
            speed = 24;
            MaxR = 0.5f;
            MinR = 0.5f;

            MinFish = 0.6f;
            MaxFish = 0.7f;
        }
        else if (int.Parse(text.text) >= 100 && int.Parse(text.text) < 120)
        {
            speed = 26;

            MinFish = 0.5f;
            MaxFish = 0.6f;
        }
        else if (int.Parse(text.text) >= 130)
        {
            speed = 28;
        }

        StartCoroutine(Fun());

    }
	


}
