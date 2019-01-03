using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        data[0] = PlayerPrefs.GetString("username");
        data[1] = Currently_score.ToString();
        data[2] = DateTime.Now.ToString();
        Debug.Log(data[0] + " " + data[1] + " " + data[2]);

    }

}
