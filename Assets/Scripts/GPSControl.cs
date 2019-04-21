using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GPSControl : MonoBehaviour {

    private const string achiv1 = "CgkI-Zan2YIEEAIQAQ";
    private const string achiv2 = "CgkI-Zan2YIEEAIQAg";
    private const string achiv3 = "CgkI-Zan2YIEEAIQBA";
    private const string achiv4 = "CgkI-Zan2YIEEAIQBQ";
    private const string achiv5 = "CgkI-Zan2YIEEAIQBg";
    private const string leaderBoard = "CgkI-Zan2YIEEAIQAw";

	void Start () {

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {

            PlayGamesPlatform.Activate();
            Social.localUser.Authenticate((bool succes) =>
            {

            });

            if (PlayerPrefs.GetInt("Score") >= 100)
                getAchiv(achiv1);
            if (PlayerPrefs.GetInt("Gold") >= 50)
                getAchiv(achiv2);
            if (PlayerPrefs.GetInt("Gold") >= 100)
                getAchiv(achiv3);
            if (PlayerPrefs.GetInt("Score") >= 500)
                getAchiv(achiv4);
            if (PlayerPrefs.GetInt("Score") >= 1000)
                getAchiv(achiv5);

            Social.ReportScore(PlayerPrefs.GetInt("Score"), leaderBoard, (bool success) =>
            {
                // Удачно или нет?
            });

        }
	}

    private void getAchiv(string id)
    {
        Social.ReportProgress(id, 100.0f, (bool succes) =>
        {
            //
        });

       

    }

    public void butAchivs()
    {
        Social.ShowAchievementsUI();
    }

    public void butLeaderBoard()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderBoard);
    }
	


}

 

