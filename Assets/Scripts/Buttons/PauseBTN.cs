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
        Blastercount.Ammodownlazer = 90;
        AmmoCounter.AmmodownRocket = 20;
        Initiate.Fade("Main", Color.black, 2.5f);
        Time.timeScale = 1;
        

    }
    public void Exit()
    {
        Application.Quit();
        PlayerPrefs.Save();
    }
    public void Restart()
    {
        Blastercount.Ammodownlazer = 90;
        AmmoCounter.AmmodownRocket = 20;
        
        
        Initiate.Fade("bots", Color.black, 4.5f);
        Time.timeScale = 1;
    }
}
