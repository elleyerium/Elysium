using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {
    public static float Currently_score;
    public static float Scoreup = 0f;
    public Text Score;
    public static int Reset = 0;

	void Start ()
    {
        Score = GetComponent<Text>();
    }

    public void Update()
    {
        Currently_score = Scoreup;
        Score.text = "Score : " + Currently_score;

        if (Currently_score >= PlayerPrefs.GetFloat("Highest score"))
        {
            PlayerPrefs.SetFloat("Highest score", Currently_score);
        }

	}

    public void ResetScore()
    {
        Scoreup = 0;
    }

}
