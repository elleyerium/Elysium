using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotDifficult : MonoBehaviour {
    public static bool noob, abitharder,impossible;
    public Slider Difficult;
    public GameObject Panel;
    
    public void NoobMode()
    {
        abitharder = false;
        impossible = false;
        noob = true;
        if (noob)
        {
            Scores.ScoreMultipliyer = 0.3f;
            Blastercount.Ammodownlazer = 250;
            AmmoCounter.AmmodownRocket = 100;
        }
        
    }
    public void ABitHarder()
    {
        abitharder = true;
        noob = false;
        impossible = false;
        abitharder = true;
        if (abitharder)
        {
            Scores.ScoreMultipliyer = 1.1f;
            Blastercount.Ammodownlazer = 90;
            AmmoCounter.AmmodownRocket = 20;
        }
    }
    public void ImpossibleMode()
    {
        abitharder = false;
        noob = false;
        impossible = true;
        if (impossible)
        {
            Scores.ScoreMultipliyer = 2.3f;
            Blastercount.Ammodownlazer = 30;
            AmmoCounter.AmmodownRocket = 10;
        }
    }
    void Update()
    {
        if (Difficult.value == 1)
        {
            abitharder = false;
            impossible = false;
            noob = true;
            if (noob)
            {
                Scores.ScoreMultipliyer = 0.3f;
                Blastercount.Ammodownlazer = 250;
                AmmoCounter.AmmodownRocket = 100;
            }
        }
        if(Difficult.value == 2)
        {
            abitharder = true;
            noob = false;
            impossible = false;
            abitharder = true;
            if (abitharder)
            {
                Scores.ScoreMultipliyer = 1.1f;
                Blastercount.Ammodownlazer = 90;
                AmmoCounter.AmmodownRocket = 20;
            }
        }
        if(Difficult.value == 3)
        {
            abitharder = false;
            noob = false;
            impossible = true;
            if (impossible)
            {
                Scores.ScoreMultipliyer = 2.3f;
                Blastercount.Ammodownlazer = 30;
                AmmoCounter.AmmodownRocket = 10;
            }
        }

    }

    public void Play()
    {
        if (abitharder == false && noob == false && impossible == false)
        {
            Scores.ScoreMultipliyer = 1.1f;
            Blastercount.Ammodownlazer = 90;
            AmmoCounter.AmmodownRocket = 20;
        }

        Initiate.Fade("bots", Color.black, 4.5f);
        PlayerPrefs.SetInt("Play Counter", PlayerPrefs.GetInt("Play Counter") + 1);
   }

    public void Back()
    {
        Panel.SetActive(false);
        
    }
}
