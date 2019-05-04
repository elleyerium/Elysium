using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSerialize : MonoBehaviour
{

	public GameObject rank, nickname, score;
	public void SetScore(string rank, string nickname, string score)
	{
		this.rank.GetComponent<Text>().text = rank;
		this.nickname.GetComponent<Text>().text = nickname;
		this.score.GetComponent<Text>().text = score;
	}
}
