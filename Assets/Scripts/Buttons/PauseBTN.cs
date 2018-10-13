using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBTN : MonoBehaviour
{ 
    public GameObject ResumeUI;
    public GameObject Pausebutton;

    public void PauseGame()
    {
        ResumeUI.SetActive(true);
        Pausebutton.SetActive(false);
        Time.timeScale = 0;
        
    }

    public void ResumeGame()
    {
        ResumeUI.SetActive(false);
        Pausebutton.SetActive(true);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        BotDifficult.abitharder = false;
        BotDifficult.noob = false;
        BotDifficult.impossible = false;
        Bots.botCounter = 0;
        if (BotDifficult.noob)
            AmmoCounter.AmmodownRocket = 999;
        if (BotDifficult.abitharder)
            AmmoCounter.AmmodownRocket = 20;
        if (BotDifficult.impossible)
            AmmoCounter.AmmodownRocket = 10;
        Initiate.Fade("Main", Color.black, 2.5f);
        Time.timeScale = 1;

        if (PhotonNetwork.inRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        

    }
    public void Exit()
    {
        if (PhotonNetwork.inRoom || PhotonNetwork.connected)
        {
            PhotonNetwork.LeaveRoom();
        }
        Application.Quit();
        PlayerPrefs.Save();
    }
    public void Restart()
    {
        Bots.botCounter = 0;
        if (BotDifficult.noob)
            AmmoCounter.AmmodownRocket = 999;
        if (BotDifficult.abitharder)
            AmmoCounter.AmmodownRocket = 20;
        if (BotDifficult.impossible)
            AmmoCounter.AmmodownRocket = 10;


        Initiate.Fade("bots", Color.black, 4.5f);
        Time.timeScale = 1;
    }
}
