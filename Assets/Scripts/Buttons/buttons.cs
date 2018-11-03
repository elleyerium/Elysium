using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{
    public GameObject gamemodechoose, Settingspanel, styling, Rate, Onlinefunc, setpan, welcome, start, scores, connected, stylingBTN;
    

    public void StartGame()
    {
        gamemodechoose.SetActive(true);

    }
    public void Rating()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Elleyer.Elysium");
    }
    public void Settings()
    {
        Settingspanel.SetActive(true);
    }


    public void Scores()
    {
     //
    }
    public void Styling()
    {
        Rate.SetActive(false);
        Onlinefunc.SetActive(false);
        setpan.SetActive(false);
        welcome.SetActive(false);
        start.SetActive(false);
        scores.SetActive(false);
        connected.SetActive(false);
        stylingBTN.SetActive(false);
        styling.SetActive(true);
    }

    public void BackStyling()
    {
        Rate.SetActive(true);
        Onlinefunc.SetActive(true);
        setpan.SetActive(true);
        welcome.SetActive(true);
        start.SetActive(true);
        scores.SetActive(true);
        connected.SetActive(true);
        stylingBTN.SetActive(true);
        styling.SetActive(false);
    }

}
