using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "bot")
		{
			Scores.Scoreup += (Random.Range(1f, 5f) * Scores.ScoreMultipliyer);
		}

	}
}
