using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PriceManager : MonoBehaviour {  

    public GameObject panelShop;
    public GameObject[] prices;
    public GameObject buttonStart;
    public Text coins;

    public bool[] levelsUnLock;
    public int levelNum;

    void Start()
    {
        // проверки того что куплено уровен или нет
        // если куплен то он не обрабатывается;
        //levelGold
        if (PlayerPrefs.GetInt("levelGold") == 1)
            levelsUnLock[0] = true;
        else
            levelsUnLock[0] = false;

        //levelIce
        if (PlayerPrefs.GetInt("levelIce") == 1)
            levelsUnLock[1] = true;
        else
            levelsUnLock[1] = false;

        //levelFantasy
        if (PlayerPrefs.GetInt("levelFantasy") == 1)
            levelsUnLock[2] = true;
        else
            levelsUnLock[2] = false;
    }


    // метод управление ценами
    public void ShopStart()
    {
        if (levelNum == 0)
        {
            panelShop.SetActive(false);
            prices[0].SetActive(false);
            buttonStart.SetActive(true);
        }
        if (levelNum == 1)
        {
            // отключаем ненужные елементы
            buttonStart.SetActive(true);
            prices[1].SetActive(false);
            panelShop.SetActive(false);

            if (levelsUnLock[0] == false)
            {
                panelShop.SetActive(true);
                prices[0].SetActive(true);
                buttonStart.SetActive(false);
            }
        }
        if (levelNum == 2 )
        {
            //отключаем предыдуший и следюшую элементы
            buttonStart.SetActive(true);            
            prices[0].SetActive(false);
            prices[2].SetActive(false);
            panelShop.SetActive(false);

            if (levelsUnLock[1] == false)
            {
                panelShop.SetActive(true);
                prices[1].SetActive(true);
                buttonStart.SetActive(false);
            }

        }
        if (levelNum == 3 )
        {
            // отключаем ненужные елементы
            buttonStart.SetActive(true);
            prices[1].SetActive(false);
            panelShop.SetActive(false);

            if(levelsUnLock[2] == false) {
                panelShop.SetActive(true);
                prices[2].SetActive(true);
                buttonStart.SetActive(false);
            }   
        }

    }



    // кнопка покупки уровней
    public void BuyLevelGold()
    {
        //levelGold
        if(levelNum == 1 && levelsUnLock[0] == false)
        {
            if (PlayerPrefs.GetInt("Gold") >= 500)
            { 
                levelsUnLock[0] = true;
                PlayerPrefs.SetInt("levelGold", 1);
                PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - 500);
                coins.text = PlayerPrefs.GetInt("Gold").ToString();

                buttonStart.SetActive(true);
                prices[0].SetActive(false);
                panelShop.SetActive(false);  
            }
        }

    }



    public void BuyLevelIce()
    {
        //levelIce
        if (levelNum == 2 && levelsUnLock[1] == false)
        {
            GetComponent<IapManager>().BuyLevelIce();

            SceneManager.LoadScene(0);	

            //if (PlayerPrefs.GetInt("Crystal") >= 5)
            //{
            //    levelsUnLock[1] = true;
            //    //PlayerPrefs.SetInt("levelIce", 1);
            //    PlayerPrefs.SetInt("Crystal", PlayerPrefs.GetInt("Crystal") - 5);

            //    panelShop.SetActive(false);
            //    prices[1].SetActive(false);
            //    buttonStart.SetActive(true);

            //}
        }
    }



    public void BuyLevelFantasy()
    {
        //levelFantasy
        if (levelNum == 3 && levelsUnLock[2] == false)
        {
            GetComponent<IapManager>().BuyLevelFantasy();

            SceneManager.LoadScene(0);	

            //if (PlayerPrefs.GetInt("Crystal") >= 5)
            //{
            //    levelsUnLock[2] = true;
            //    //PlayerPrefs.SetInt("levelFantasy", 1);
            //    PlayerPrefs.SetInt("Crystal", PlayerPrefs.GetInt("Crystal") - 7);           

            //    panelShop.SetActive(false);
            //    prices[2].SetActive(false);
            //    buttonStart.SetActive(true);

            //}
        }
    }

}
