using System;
using System.Collections;
using System.Collections.Generic;
using Game.Difficult;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

namespace Game.Player.Scoring
{
    public class LocalScoringByDifficulty : MonoBehaviour
    {
        public static string[] data;
        public static float ScoreMultipliyer;
        public static float Currently_score;
        public static float Scoreup = 0f;
        public Text Score;
        public static int Reset = 0;

        void Start()
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

        public static void GetScores(string username)
        {
            //ConnectMasterServer connector = new ConnectMasterServer(); //TODO: fix
            //connector.Request(username, TypeOfTags.GetScoreRequest.ToString());
        }
    }
}


