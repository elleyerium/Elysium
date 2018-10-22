using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using UnityEngine.SocialPlatforms.Impl;

public class RestartonDeath : MonoBehaviour
{
    public GameObject deathScreen;
    [SerializeField]
    Text CountOfKills, TotalScore;
    void Start()
    {
        var ScoreDatas = Scores.Currently_score.ToString();
        WWWForm Server = new WWWForm();
        Server.AddField("scores", ScoreDatas);
        Server.AddField("username", PlayerPrefs.GetString("username"));
        string url = "http://elysium.lh1.in/ScoreParse.php";
        WWW www = new WWW(url, Server);
        
        PlayerPrefs.SetFloat("TotalScore", (PlayerPrefs.GetFloat("TotalScore") + Scores.Currently_score));
    }
    void Update()
    {
        CountOfKills.text = ("Destroyed bots : " + Spawnedbothp.Countofkilled);
        TotalScore.text = ("Total score : " + Scores.Currently_score); 
    }
    public void RestartGame()
    {
        Bots.botCounter = 0;
        Initiate.Fade("bots", Color.black, 4.5f);
        Time.timeScale = 1;
        Blastercount.Ammodownlazer = 90;
        AmmoCounter.AmmodownRocket = 20;
    }
    public void Mainmenu()
    {
        BotDifficult.abitharder = false;
        BotDifficult.noob = false;
        BotDifficult.impossible = false;

        Bots.botCounter = 0;
        Initiate.Fade("Main", Color.black, 2.5f);
        Time.timeScale = 1;
        Blastercount.Ammodownlazer = 90;
        AmmoCounter.AmmodownRocket = 20;

    }
}