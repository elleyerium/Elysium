using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{
    public GameObject AllItems,
        MusicManagerUI,
        gamemodechoose,
        Settingspanel,
        styling,
        Onlinefunc,
        setpan,
        welcome,
        start,
        scores,
        connected,
        stylingBTN,
        scoresBTN,
        MusicManager,
        PlayerStatus,
        MusicManagerPanel;


    public void StartGame()
    {
        setpan.SetActive(false);
        gamemodechoose.SetActive(true);
        MusicManagerPanel.SetActive(false);
        MusicManager.SetActive(false);
        PlayerStatus.SetActive(false);
    }
    public void Rating()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Elleyer.Elysium");
    }
    public void Settings()
    {
        AllItems.SetActive(false);
        MusicManagerPanel.SetActive(false);
        MusicManager.SetActive(false);
        Settingspanel.SetActive(true);
    }


    public void Scores()
    {
        Onlinefunc.SetActive(false);
        setpan.SetActive(false);
        //welcome.SetActive(false);
        start.SetActive(false);
        scores.SetActive(false);
        stylingBTN.SetActive(false);
        scoresBTN.SetActive(true);
        MusicManagerPanel.SetActive(false);
        MusicManager.SetActive(false);
        PlayerStatus.SetActive(false);
    }
    public void Styling()
    {
        MusicManagerPanel.SetActive(false);
        MusicManager.SetActive(false);
        Onlinefunc.SetActive(false);
        setpan.SetActive(false);
        start.SetActive(false);
        scores.SetActive(false);
        stylingBTN.SetActive(false);
        styling.SetActive(true);
        PlayerStatus.SetActive(false);
    }

    public void BackStyling()
    {
        MusicManagerPanel.SetActive(true);
        MusicManager.SetActive(true);
        Onlinefunc.SetActive(true);
        setpan.SetActive(true);
        //welcome.SetActive(true);
        start.SetActive(true);
        scores.SetActive(true);
        //connected.SetActive(true);
        stylingBTN.SetActive(true);
        styling.SetActive(false);
        scoresBTN.SetActive(false);
        PlayerStatus.SetActive(true);
    }

}
