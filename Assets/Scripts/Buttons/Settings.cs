using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using BeardedManStudios;

[Serializable]
public class Settings : MonoBehaviour
{

    public GameObject AllItems, MusicManagerUI, Global, Network, PlayerData,SnowSystem;
    public Toggle Checkboxparticle;
    public Text HighestScore, Times_Played,TotalScore,Ping, SensText;
    public Image CurrentlySelection;
    public static float SensitivityValue = 0.45f;
    bool ModeVisual, ModeStats, ModeNetwork;
    public Slider Sensitivity;

    void Start()
    { 
             Sensitivity.minValue = 0.1f;
             Sensitivity.maxValue = 1.0f;
        if (!PlayerPrefs.HasKey("Sensitivity"))
            Sensitivity.value = 0.45f;
        else 
            Sensitivity.value = PlayerPrefs.GetFloat("Sensitivity");
        
        TotalScore.text = "Total score :  " + PlayerPrefs.GetFloat("TotalScore").ToString("F2");
        HighestScore.text = "Highest score :  " + PlayerPrefs.GetFloat("Highest score").ToString("F2");
        Times_Played.text = "Times played :  " + PlayerPrefs.GetInt("Play Counter");
    }
    
    void Update()
    {
        SensitivityValue = Sensitivity.value;
        Ping.text = "Ping : " + PhotonNetwork.GetPing() + " ms";
        SensText.text = "Joystick sensitivity value is " + Sensitivity.value.ToString("F2") +"x";
    }
    public void Back()
    {    
        PlayerPrefs.SetFloat("Sensitivity", SensitivityValue);
        AllItems.SetActive(true);
        MusicManagerUI.SetActive(true);
        gameObject.SetActive(false);

    }
    public void Particleoff()
    {
        if (Checkboxparticle.isOn)
            SnowSystem.SetActive(true);
        else SnowSystem.SetActive(false);
    }
    public void VisualSettings()
    {
        ModeVisual = true;
        ModeStats = false;
        ModeNetwork = false;
        CurrentlySelection.transform.localPosition = new Vector3(0, 172.4f, -55);
        Global.SetActive(true);
        Network.SetActive(false);
        PlayerData.SetActive(false);

    }
    public void StatsSettings()
    {
        ModeStats = true;
        ModeVisual = false;
        ModeNetwork = false;
        CurrentlySelection.transform.localPosition = new Vector3(0, 13.3f, -55);
        Global.SetActive(false);
        Network.SetActive(false);
        PlayerData.SetActive(true);
    }
    public void NetworkSettings()
    {
        ModeNetwork = true;
        ModeVisual = false;
        ModeStats = false;
        CurrentlySelection.transform.localPosition = new Vector3(0, -148.5f, -55);
        Global.SetActive(false);
        Network.SetActive(true);
        PlayerData.SetActive(false);
    }
    public void LogOut()
    {
        PhotonNetwork.Disconnect();
    }
}