using System.Collections;
using System.Collections.Generic;
using Game.Player.Scoring;
using UnityEngine;

namespace Game.Player.Weapon
{
	public class Cannon : MonoBehaviour {
		private void OnTriggerExit2D(Collider2D col)
		{
			if (CompareTag("bot"))
			{
				LocalScoringByDifficulty.Scoreup += (Random.Range(1f, 5f) * LocalScoringByDifficulty.ScoreMultipliyer);
			}

		}
	}
}
