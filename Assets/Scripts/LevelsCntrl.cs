using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsCntrl : MonoBehaviour {
	
	//public StartGame sGameNumber;

	public GameObject butLeft;
	public GameObject butRight;
	public GameObject[] Levels;
	public int count = 0;

	// получаем ресурсы и рекорды
	public Text record;
	public Text coins;

    public PriceManager priceM;

	void Start()
	{
		record.text = PlayerPrefs.GetInt ("Score").ToString();
        coins.text = PlayerPrefs.GetInt("Gold").ToString();  
	}

	
	public void right()
	{
		if (count < Levels.Length-1) {
			Levels [count].SetActive (false);
			count++;
            priceM.levelNum = count;
			Levels [count].SetActive (true);
		}

		if (count != 0)
			butLeft.SetActive (true);
		if (count == Levels.Length - 1)
			butRight.SetActive (false);

        //запускаем метод управление ценами        
        priceM.ShopStart();
			
	}

	public void left() {
		if (count > 0) {
			Levels [count].SetActive (false);
			count--;
            priceM.levelNum = count;
			Levels [count].SetActive (true);
		}

		if (count == 0)
			butLeft.SetActive (false);
		if (count != Levels.Length - 1)
			butRight.SetActive (true);

        //запускаем метод управление ценами
        priceM.ShopStart();
	}
}
