using System.Collections;
using System.Collections.Generic;
using Game.Player.Health;
using UnityEngine;

namespace Game.AI.Health
{
    public class Drophp : MonoBehaviour {
        public GameObject healthbox;
        public Transform healthboxpos;
        public int boxdropchance;
        void Start()
        {
            if (boxdropchance <= 100)
            {
                healthbox.SetActive(true);
                Instantiate(healthbox, healthboxpos.position, healthboxpos.rotation);
            }

            healthbox.SetActive(false);
            boxdropchance = Random.Range(0, 100);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "player" && healthbox.activeSelf)
            {
                HealthbarScript.health -= 30;
                Destroy(healthbox);
            }
        }
    }
}

