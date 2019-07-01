using System.Collections;
using System.Collections.Generic;
using Game.Difficult;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Player.Weapon
{
    public class AmmoCounter : MonoBehaviour
    {
        public static float AmmodownRocket;
        [SerializeField]
        public static Text rocketcount;



        void Start ()
        {
            if (BotDifficult.noob)
                AmmodownRocket = 100;
            if (BotDifficult.abitharder)
                AmmodownRocket = 50;
            if (BotDifficult.impossible)
                AmmodownRocket = 30;


            rocketcount = GetComponent<Text>();
        }

        void Update ()
        {
            rocketcount.text = "" + AmmodownRocket.ToString("F0");
        }
    }
}
