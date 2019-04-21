using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public bool pause = false;
	public bool soundOf = false;
    public GameObject PausePanel;
	public GameObject pauseBtn;
	public GameObject settingsPanel;
	private Scene scene;

	public Toggle togMusic;
	public Toggle togSound;

	private AudioSource audio;

    public GameOver gOver;

	void Start()
	{     
		if(!soundOf)
			AudioListener.volume = 1;
		
		scene = SceneManager.GetActiveScene ();
		audio = GameObject.Find ("Directional Light").GetComponent<AudioSource> ();

		if (PlayerPrefs.GetString ("Music") == "No")
			togMusic.isOn = false;
		if (PlayerPrefs.GetString ("Sound") == "No")
			togSound.isOn = false;

	}

	// КНОПКА ПАУЗЫ
    public void PauseM()
    {
			AudioListener.volume = 0;
            PausePanel.SetActive(true);
            Time.timeScale = 0.00001f;
            pause = true;
			pauseBtn.SetActive (false);
            return;
    }

	// КНОПКА ПРОДОЛЖЕНИЕ
	public void ResumeBut()
	{
		if(!soundOf)
			AudioListener.volume = 1;


		PausePanel.SetActive(false);
		Time.timeScale = 1;
		pause = false;
		pauseBtn.SetActive (true);
		return;
	}


	// НАСТРОЙКИ
	public void SettingBut()
	{
		settingsPanel.SetActive (true);
	}

	// ЗАНОВО
	public void RestartBut()
	{
		if(!soundOf)
			AudioListener.volume = 1;
		
		Time.timeScale = 1;
		SceneManager.LoadScene (scene.name);
	}

	// ГЛАВНОЕ МЕНЮ
    public void MainMenuBtn()
    {
        Time.timeScale = 1;
		SceneManager.LoadScene ("Menu");
    }

    public void pauseGOver()
    {
        ResumeBut();
        gOver.gameOver = true;

    }


	// Включение выключение музыки
	public void MusicOnOf()
	{
        if (audio.mute == true) {
			audio.mute = false;
			PlayerPrefs.SetString ("Music", "Yes");
		} else {
			audio.mute = true;
			PlayerPrefs.SetString ("Music", "No");
		}
	}

	// ВЫКЛЮЧЕНИЕ ВКЛЮЧЕНИЕ ЗВУКА
	public void SoundOnOf()
	{
		if(!soundOf) {
		    AudioListener.volume = 0;
			PlayerPrefs.SetString ("Sound", "No");
			soundOf = true;
		    return;
	   }
		if (soundOf)  {
			AudioListener.volume = 1;
			PlayerPrefs.SetString ("Sound", "Yes");
			soundOf = false;
		    return;
	   }
	
	}

	// ПОТДВЕРЖДЕНИЕ НАСТРОЙКИ
	public void OkBut()
	{
		settingsPanel.SetActive (false);
	}




}
