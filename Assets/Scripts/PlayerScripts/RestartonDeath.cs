using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartonDeath : MonoBehaviour
{
    public GameObject deathScreen;
    [SerializeField]
    Text CountOfKills, TotalScore;
    void Update()
    {
        CountOfKills.text = ("Destroyed bots : " + Spawnedbothp.Countofkilled);
        TotalScore.text = ("Total score : " + Scores.Currently_score); 
    }
    public void RestartGame()
    {
        Initiate.Fade("bots", Color.black, 4.5f);
        Time.timeScale = 1;
        Blastercount.Ammodownlazer = 90;
        AmmoCounter.AmmodownRocket = 20;
    }
    public void Mainmenu()
    {

        Initiate.Fade("Main", Color.black, 2.5f);
        Time.timeScale = 1;
        Blastercount.Ammodownlazer = 90;
        AmmoCounter.AmmodownRocket = 20;

    }
}