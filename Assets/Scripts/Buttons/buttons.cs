using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{
    public GameObject gamemodechoose, Settingspanel, styling, Rate, Onlinefunc, setpan, welcome, start, scores, connected, stylingBTN, scoresBTN, MusicManager;
    

    public void StartGame()
    {
        gamemodechoose.SetActive(true);
        MusicManager.SetActive(false);

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
        Rate.SetActive(false);
        Onlinefunc.SetActive(false);
        setpan.SetActive(false);
        welcome.SetActive(false);
        start.SetActive(false);
        scores.SetActive(false);
        //connected.SetActive(false);
        stylingBTN.SetActive(false);
<<<<<<< HEAD
        scoresBTN.SetActive(true);
        MusicManager.SetActive(false);
=======
        //scoresBTN.SetActive(true);
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
    }
    public void Styling()
    {
        MusicManager.SetActive(false);
        Rate.SetActive(false);
        Onlinefunc.SetActive(false);
        setpan.SetActive(false);
        welcome.SetActive(false);
        start.SetActive(false);
<<<<<<< HEAD
        scores.SetActive(false);
=======
        //scores.SetActive(false);
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
        //connected.SetActive(false);
        stylingBTN.SetActive(false);
        styling.SetActive(true);
    }

    public void BackStyling()
    {
        MusicManager.SetActive(true);
        Rate.SetActive(true);
        Onlinefunc.SetActive(true);
        setpan.SetActive(true);
        welcome.SetActive(true);
        start.SetActive(true);
<<<<<<< HEAD
        scores.SetActive(true);
        //connected.SetActive(true);
        stylingBTN.SetActive(true);
        styling.SetActive(false);
        scoresBTN.SetActive(false);
=======
        //scores.SetActive(true);
        //connected.SetActive(true);
        stylingBTN.SetActive(true);
        styling.SetActive(false);
        //scoresBTN.SetActive(false);
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
    }

}
