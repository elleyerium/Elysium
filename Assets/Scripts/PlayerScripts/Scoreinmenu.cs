using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreinmenu : MonoBehaviour {
    public Text ShowMenuScore;
	void Start () {
        ShowMenuScore = GetComponent<Text>();
		
	}
	
	void Update () {
        ShowMenuScore.text = "Currently  score : " + Scores.Scoreup;
	}
}
