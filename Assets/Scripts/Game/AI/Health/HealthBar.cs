using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.AI.Health
{
    public class HealthBar : MonoBehaviour {
        [SerializeField]
        Image HealthBarFill;

        public int hp;

        int MaxBotHp = 100;

        void Start()
        {
            hp = MaxBotHp;
        }
        void Update()
        {

            HealthBarFill.fillAmount = hp / MaxBotHp;
        }
    }
}

