using System.Collections;
using System.Collections.Generic;
using Game.Graphics.Effects;
using Game.Player.Scoring;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Difficult
{
    public class BotDifficult : MonoBehaviour {
        public static bool noob, abitharder,impossible;
        public Slider Difficult;
        public GameObject Panel;

        public void Play()
        {
            if (Difficult.value == 1)
            {
                abitharder = false;
                impossible = false;
                noob = true;
                if (noob)
                    LocalScoringByDifficulty.ScoreMultipliyer = 0.3f;
            }
            if(Difficult.value == 2)
            {
                abitharder = true;
                noob = false;
                impossible = false;
                abitharder = true;
                if (abitharder)
                    LocalScoringByDifficulty.ScoreMultipliyer = 1.1f;
            }
            if(Difficult.value == 3)
            {
                abitharder = false;
                noob = false;
                impossible = true;
                if (impossible)
                    LocalScoringByDifficulty.ScoreMultipliyer = 2.3f;
            }

            if (abitharder == false && noob == false && impossible == false)
            {
                LocalScoringByDifficulty.ScoreMultipliyer = 1.1f;
            }

            Initiate.Fade("bots", Color.black, 4.5f);
            PlayerPrefs.SetInt("Play Counter", PlayerPrefs.GetInt("Play Counter") + 1);
        }

        public void Back()
        {
            Panel.SetActive(false);
        }
    }
}
