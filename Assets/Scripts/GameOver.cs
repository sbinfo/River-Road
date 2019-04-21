using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public Transform target;
	public Transform boat;
	public Rigidbody rBody;

	// PS которые надо отключит и включит во время столкновение
	public GameObject psSmokeOn;
	public GameObject psExplosionOn;
	public GameObject psVolni_Of;
    public GameObject psVolni2_Of; 

	public bool gameOver; //Переменная которая хранит значение закончилась ли игра или нет
	public GameObject panelGameOver; // Панед GameOver
	public PauseMenu pauseM; // для установки паузы чтобы в игре все процессы остановились
	public GameObject[] objects; // все спавнеры для декативации

	//для управление звуков при окончение игры
	public AudioSource audio;
	public AudioSource soundBoat;
	public GameObject fireSound;

	//для отключение скрипта Контроллера
	public BoatController BCntrlOf;
	public GameObject pauseBtn;

	// для отключение остальных текстов на экране
	public GameObject[] uiTexts;

	public ScoreManager scMngr;
	bool proScore = true;


	void Start () {
		gameOver = false;
	}
	

	void Update () {
		if (gameOver) {

			pauseBtn.SetActive (false);

			//отключаем звуки
			soundBoat.mute = true;
			audio.mute = true;
			// влючаем звук огня
			fireSound.SetActive(true);

			//отключаем упраеление
			BCntrlOf.enabled = false;

			// включаем гравитацию лодки
			rBody.isKinematic = false;
			rBody.useGravity = true;

			// активируем PS SMOKE только тогда когда лодка уходит в дно
			if(boat.position.y < -1.38f)
				psSmokeOn.SetActive (true);

            psVolni_Of.SetActive(false); // Отключаем волны
            psVolni2_Of.SetActive(false);
			psExplosionOn.SetActive (true); //активируем взрыв


			// удаляем все спавнеры со сцены
			for (int i = 0; i < objects.Length; i++)
				objects [i].SetActive (false);

			// только тогда когда лодка под водой активируем панел проигрыша
			if (boat.position.y < -1.38f) {
				//даем сигнал чтобы записывать все очки и монеты
				if (proScore) {
					scMngr.ResultScore ();
					proScore = false;
				}

				for (int i = 0; i < uiTexts.Length; i++)
					uiTexts [i].SetActive (false);
				
				panelGameOver.SetActive (true);
				pauseM.pause = true;

			}
		}
	}

}
