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
    public GameObject deathScreen, player;
    [SerializeField] private Transform main;
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioClip _ReBorn;
    [SerializeField] private GameObject _exp, AnswerField, _msg; 
    [SerializeField] Text CountOfKills, TotalScore, question, _answerField;
    private int _summ, _counter = 0;

    void Start()
    {
        SaveToDataBase();
        Question();
    }

    void SaveToDataBase()
    {
        //add to db of player
        //add to database list
        //Scoreinmenu.UserScores.Add(PlayerPrefs.GetString("username"));
        //Scoreinmenu.scores.Insert(2,Scores.Currently_score.ToString());
        //Scoreinmenu.scores.Insert(3,System.DateTime.Now.ToString());
        //Debug.Log(Scoreinmenu.scores);
        PlayerPrefs.SetFloat("TotalScore", (PlayerPrefs.GetFloat("TotalScore") + Scores.Currently_score));
    }
    void SendData()
    {
        var ScoreDatas = Scores.Currently_score.ToString();
        WWWForm Server = new WWWForm();
        Server.AddField("scores", ScoreDatas);
        Server.AddField("username", PlayerPrefs.GetString("username"));
        string url = "http://elysium.lh1.in/ScoreParse.php";
        WWW www = new WWW(url, Server);
    }
    void Update()
    {
        if (_counter >=1)
        {
            question.text = ("Have no more attempts!");
            AnswerField.SetActive(false);
        }
            
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
        SendData();
        BotDifficult.abitharder = false;
        BotDifficult.noob = false;
        BotDifficult.impossible = false;
        Bots.botCounter = 0;
        Initiate.Fade("Main", Color.black, 2.5f);
        Time.timeScale = 1;
        Blastercount.Ammodownlazer = 90;
        AmmoCounter.AmmodownRocket = 20;

    }

    void Question()
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
            _counter++;
            _exp.SetActive(true);
            _AudioSource.PlayOneShot(_ReBorn);
            HealthbarScript._respawner.SetActive(true);
            deathScreen.SetActive(false);
            HealthbarScript.health = 100;
            GameObject Error = Instantiate(_msg);
            Error.transform.SetParent(main, false);
            Destroy(Error,2.3f);
        }
        else
         Debug.Log("Wrong answer. Try again");
    }
}