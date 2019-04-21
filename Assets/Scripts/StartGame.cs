using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
	
	public LevelsCntrl levelNum;
	public void lLevel()
    {	
		SceneManager.LoadScene (levelNum.count+1);	
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
