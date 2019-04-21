using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour {

	public void Open()
	{
		gameObject.SetActive (true);
	}

	public void Close()
	{
		gameObject.SetActive (false);
	}

    public void urlOpen()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.SBGames.RiverRoad");
    }
}
