using System.Collections;
using System.Collections.Generic;
using Game.Player.Scoring;
using UnityEngine;

namespace Game.Player.Weapon
{
    public class Lazermove : MonoBehaviour {
        public float speed;
        public GameObject lazer;
        Rigidbody2D rb;


        void Start() =>
            rb = GetComponent<Rigidbody2D>();

        void Update()
        {
            var lazermove = transform.position;
            lazermove.Normalize();
            rb.velocity = transform.right * speed;
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if (CompareTag("bot"))
            {
                Destroy(lazer);
                LocalScoringByDifficulty.Scoreup += (Random.Range(9.0f, 11.30f) * LocalScoringByDifficulty.ScoreMultipliyer);
            }
            if(CompareTag("border"))
                Destroy(lazer);
        }
    }
}

