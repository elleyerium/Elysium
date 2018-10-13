using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour {
    public GameObject gamemodechoose,Settingspanel;

    public void StartGame()
    {
        gamemodechoose.SetActive(true);

    }
    public void Rating()
    {
        Application.OpenURL("https://google.com");
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
     //
    }

}
