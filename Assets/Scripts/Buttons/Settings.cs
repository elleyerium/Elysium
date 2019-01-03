using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

[Serializable]
public class Settings : MonoBehaviour
{

    public GameObject start,styling,scores,Settingspanel,text,Particlesky, toggles, musicManager;
    public Toggle Checkboxparticle;
    public Text HighestScore, Times_Played,TotalScore,Ping, sensValue;
    public Image Line;
    public static int PlayedCount;
    public static float SensitivityValue = 0.2f;
    bool ModeVisual, ModeStats, ModeNetwork = false;
    public Slider Sensitivity;

    void Start()
    {      
             Sensitivity.minValue = 0.1f;
             Sensitivity.maxValue = 1.0f;
        if (!PlayerPrefs.HasKey("Sensitivity"))
            Sensitivity.value = 0.2f;
        else 
            Sensitivity.value = PlayerPrefs.GetFloat("Sensitivity");
        
        TotalScore.text = ("Total  score :  " + PlayerPrefs.GetFloat("TotalScore").ToString("F2"));
        HighestScore.text = ("Highest  score :  " + PlayerPrefs.GetFloat("Highest score").ToString("F2"));
        Times_Played.text = ("Times  played :  " + PlayerPrefs.GetInt("Play Counter"));
        HighestScore.enabled = false;
        Times_Played.enabled = false;
        Ping.enabled = false;
        TotalScore.enabled = false;

    }
    
    void Update()
    {
        SensitivityValue = Sensitivity.value;
        sensValue.text = ("Joystick sensitivity : " + SensitivityValue.ToString("F2") + "x");
        PlayedCount = PlayerPrefs.GetInt("Play Counter");
        if (ModeVisual)
        {
            HighestScore.enabled = false;
            Times_Played.enabled = false;
            Ping.enabled = false;
            TotalScore.enabled = false;


        }
        if(ModeStats)
        {
            TotalScore.enabled = true;
            HighestScore.enabled = true;
            Times_Played.enabled = true;
            Ping.enabled = false;
            toggles.SetActive(false);
        }
        if(ModeNetwork)
        {
            TotalScore.enabled = false;
            HighestScore.enabled = false;
            Times_Played.enabled = false;
            Ping.enabled = true;
            toggles.SetActive(false);

        }
        start.SetActive(false);
        styling.SetActive(false);
<<<<<<< HEAD
        scores.SetActive(false);
=======
        //scores.SetActive(false);
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
        musicManager.SetActive(false);
        text.SetActive(false);
        Ping.text = "Ping :  " + PhotonNetwork.GetPing() + "  ms ";
        
    }
    public void Back()
    {
        Settingspanel.SetActive(false);
        start.SetActive(true);
        styling.SetActive(true);
        musicManager.SetActive(true);
<<<<<<< HEAD
        scores.SetActive(true);
=======
        //scores.SetActive(true);
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
        text.SetActive(true);
        PlayerPrefs.SetFloat("Sensitivity", SensitivityValue);
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
        Line.transform.position = new Vector3(-3.373f, 1.571f, -11.63f);
        toggles.SetActive(true);

    }
    public void StatsSettings()
    {
        ModeStats = true;
        ModeVisual = false;
        ModeNetwork = false;
        Line.transform.position = new Vector3(-3.373f, 0.50f, -11.63f);
    }
    public void NetworkSettings()
    {
        ModeNetwork = true;
        ModeVisual = false;
        ModeStats = false;
        Line.transform.position = new Vector3(-3.373f, -0.60f, -11.63f);
    }
    public void LogOut()
    {
        PhotonNetwork.Disconnect();
    }
}