using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	// получаем игровые ресурсы
	public Text FishCount;
	public Text Coins;

	// для вывода на экран
	public Text score;
	public Text bestScore;

	public Text personalMoney; // все монеты
	public Text finalCoins; // заработанные

	bool startUpdate = false;

    //элементы рекорда
    public GameObject congr;
    public GameObject textCongr1Obj;
    public Text textCongr2;
    public GameObject textCongr2Obj;

    private const string leaderBoard = "CgkI-Zan2YIEEAIQAw";

	public void ResultScore () {

		score.text = FishCount.text; // записываем полученный результат рекорда на экран
		bestScore.text = PlayerPrefs.GetInt ("Score").ToString(); // получаем максимальный рекорд
		finalCoins.text = Coins.text; // полученное золотот в игре

        //в текст рекорда записываем нужную значению
        textCongr2.text = score.text;

		// проверяем если текшее очки больше чем рекорд то заприсываем
        if (int.Parse(score.text) > PlayerPrefs.GetInt("Score"))
        {
            // Элементы нового рекорда активируем
            congr.SetActive(true);
            textCongr1Obj.SetActive(true);
            textCongr2Obj.SetActive(true);

			PlayerPrefs.SetInt ("Score", int.Parse (FishCount.text));
		}



		// вывод на экран всех имеюшихся монет
		personalMoney.text = PlayerPrefs.GetInt ("Gold").ToString ();

		// добавляем монеты к сушествюшим
		PlayerPrefs.SetInt ("Gold", PlayerPrefs.GetInt("Gold") + int.Parse (Coins.text));

		startUpdate = true; //отправляем сигнал на update
	}


	int countUp = 100;

	void Update()
	{
		if (startUpdate) // если получили сигнал
		{
			countUp--; // то минусуем для задержки некоторогого времени
				if (countUp < 50 && int.Parse (finalCoins.text) > 0)
				{
					finalCoins.text = (int.Parse (finalCoins.text)-1).ToString();
					personalMoney.text = (int.Parse (personalMoney.text)+1).ToString();
				}

		}

	}

}
