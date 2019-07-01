using System.Collections;
using System.Collections.Generic;
using Game.Player.Scoring;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Online.Statistics.User.SpacePoints
{
    public class SPCounter : MonoBehaviour
    {
        public static float SP;

        void Update() =>
            SP = LocalScoringByDifficulty.Currently_score * 0.0011f;
    }
}
