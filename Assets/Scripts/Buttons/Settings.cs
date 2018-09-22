using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

[Serializable]
public class Settings : MonoBehaviour
{

    public GameObject start,styling,scores,Settingspanel,text,Particlesky, toggles;
    public Toggle Checkboxparticle;
    public Text HighestScore, Times_Played, Ping;
    public Image Line;
    public static int PlayedCount;
    bool ModeVisual, ModeStats, ModeNetwork = false;

    void Start()
    { 
        HighestScore.text = ("Highest  score :  " + PlayerPrefs.GetFloat("Highest score"));
        Times_Played.text = ("Times  played :  " + PlayerPrefs.GetInt("Play Counter"));
        HighestScore.enabled = false;
        Times_Played.enabled = false;
        Ping.enabled = false;

    }
    
    void Update()
    {
        PlayedCount = PlayerPrefs.GetInt("Play Counter");
        if (ModeVisual)
        {
            HighestScore.enabled = false;
            Times_Played.enabled = false;
            Ping.enabled = false;
            
           
        }
        if(ModeStats)
        {

            HighestScore.enabled = true;
            Times_Played.enabled = true;
            Ping.enabled = false;
            toggles.SetActive(false);
        }
        if(ModeNetwork)
        {
            HighestScore.enabled = false;
            Times_Played.enabled = false;
            Ping.enabled = true;
            toggles.SetActive(false);

        }
        start.SetActive(false);
        styling.SetActive(false);
        scores.SetActive(false);
        text.SetActive(false);
        Ping.text = "Ping :  " + PhotonNetwork.GetPing() + "  ms ";
        
    }
    public void Back()
    {
        Settingspanel.SetActive(false);
        start.SetActive(true);
        styling.SetActive(true);
        scores.SetActive(true);
        text.SetActive(true);
    }
    public void Particleoff()
    { 
            Particlesky.SetActive(false);
        
        if (Checkboxparticle.isOn == true)
        {
            Particlesky.SetActive(true);
        }
    }
    public void VisualSettings()
    {
        ModeVisual = true;
        ModeStats = false;
        ModeNetwork = false;
        Line.transform.position = new Vector3(-3.373f, 1.571f, -55f);
        toggles.SetActive(true);

    }
    public void StatsSettings()
    {
        ModeStats = true;
        ModeVisual = false;
        ModeNetwork = false;
        Line.transform.position = new Vector3(-3.373f, 0.50f, -55f);
    }
    public void NetworkSettings()
    {
        ModeNetwork = true;
        ModeVisual = false;
        ModeStats = false;
        Line.transform.position = new Vector3(-3.373f, -0.60f, -55f);
    }
    public void LogOut()
    {
        PhotonNetwork.Disconnect();
    }
}