using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public static string[] data;
    public static float ScoreMultipliyer;
    public static float Currently_score;
    public static float Scoreup = 0f;
    public Text Score;
    public static int Reset = 0;

	void Start ()
	{
        if (BotDifficult.noob)
            ScoreMultipliyer = 0.3f;
        if (BotDifficult.abitharder)
            ScoreMultipliyer = 1.1f;
        if (BotDifficult.impossible)
            ScoreMultipliyer = 2.3f;

        Score = GetComponent<Text>();
    }

    public void Update()
    {
        Currently_score = Scoreup;
        Score.text = "Score : " + Currently_score.ToString("F2");
	}

    public void ResetScore()
    {
        Scoreup = 0;
    }

    public static void SerializeScore()
    {
        data = new string[3];
        if (!PlayerPrefs.HasKey("username") || PlayerPrefs.GetString("username") == null)
            data[0] = PlayerPrefs.GetString("username");
        else data[0] = "Guest";
        data[1] = Currently_score.ToString("F2");
        data[2] = DateTime.Now.ToString();
        string send = data[0] + "               " + data[1] + "               " + data[2];
        for (int i = 0; i <= 10; i++)
        {
            if(!PlayerPrefs.HasKey("Position" + i))
            {
                PlayerPrefs.SetString("Position" + i, send);
                Debug.Log(PlayerPrefs.GetString("Position"));
                for (int p = 0; p <= 10; p++)
                {
                    Debug.Log(" " + PlayerPrefs.HasKey("Position" + p));
                }

                i = 11;
            }
                
        }

    }

}
