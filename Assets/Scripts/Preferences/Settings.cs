using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Net.NetworkInformation;
using System.Text;
using Game.Online.Connector;
using Ping = System.Net.NetworkInformation.Ping;

namespace Preferences
{
   [Serializable]
  public class Settings : MonoBehaviour
  {

    public GameObject AllItems, MusicManagerUI,MusicManagerPanel, Global, Network, PlayerData,SnowSystem;
    public Toggle Checkboxparticle;
    public Text HighestScore, Times_Played,TotalScore,Ping,SensText;
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
        SensText.text = "Joystick sensitivity value is " + Sensitivity.value.ToString("F2") +"x";
    }
/*    public void Back()
    {
        PlayerPrefs.SetFloat("Sensitivity", SensitivityValue);
        AllItems.SetActive(true);
        MusicManagerUI.SetActive(true);
        MusicManagerPanel.SetActive(true);
        gameObject.SetActive(false);
    }*/
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
        Ping ping = new Ping();
        //ping.Send(ConnectMasterServer.ServerIp);
        ModeNetwork = true;
        ModeVisual = false;
        ModeStats = false;
        CurrentlySelection.transform.localPosition = new Vector3(0, -148.5f, -55);
        Global.SetActive(false);
        Network.SetActive(true);
        PlayerData.SetActive(false);
        StartCoroutine(PingGetter(ping));
    }

    IEnumerator PingGetter(Ping ping)
    {
        PingReply reply;
        string data = "pingrequest";
        byte[] buffer = Encoding.ASCII.GetBytes (data);
/*

        if (ConnectMasterServer.IsConnected)
        {
            reply = ping.Send(ConnectMasterServer.ServerIp, 250, buffer);
            Debug.Log("Connected!");
            if (reply.Status == IPStatus.Success)
            {
                Debug.Log(reply.Status + " " + reply.RoundtripTime);
                Ping.text = $"Network latency(ping): {reply.RoundtripTime.ToString()} ms";
            }
            else Ping.text = "Ping more than 150 ms!";
        }*/
        yield return new WaitForSeconds(5);
    }


    public void LogOut()
    {
        //ConnectMasterServer.Disconnect();
    }
  }
}
