using System;
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
using Random = System.Random;

public class RestartonDeath : MonoBehaviour
{
    public GameObject deathScreen;
    [SerializeField] Text CountOfKills, TotalScore, question, _answerField;
    public int _summ;

    void Start()
    {
        var ScoreDatas = Scores.Currently_score.ToString();
        WWWForm Server = new WWWForm();
        Server.AddField("scores", ScoreDatas);
        Server.AddField("username", PlayerPrefs.GetString("username"));
        string url = "http://elysium.lh1.in/ScoreParse.php";
        WWW www = new WWW(url, Server);

        //add to db of player
        PlayerPrefs.SetFloat("TotalScore", (PlayerPrefs.GetFloat("TotalScore") + Scores.Currently_score));
        //add to database list
        //Scoreinmenu.UserScores.Add(PlayerPrefs.GetString("username"));
        //Scoreinmenu.scores.Insert(2,Scores.Currently_score.ToString());
        //Scoreinmenu.scores.Insert(3,System.DateTime.Now.ToString());
        //Debug.Log(Scoreinmenu.scores);
        Question();
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

    public void Question()
    {
        var first = UnityEngine.Random.Range(0, 512);
        var second = UnityEngine.Random.Range(0, 1024);
        var summ = first + second;
        question.text = ("Solve this : " + first + " + " + second);
        _summ = summ;
        Debug.Log(first + "," + second);
        Debug.Log("Summ :" + summ);

    }

    public void Respawn()
    {
        var answer = _answerField;
        if (answer.text == _summ.ToString())
        { 
            deathScreen.SetActive(false);
            HealthbarScript.health = 100;
        }
        else
         Debug.Log("Please be correct");
    }
}