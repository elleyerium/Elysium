using System.Collections;
using System.Collections.Generic;
using Game.Difficult;
using Game.Player.Health;
using UnityEngine;

namespace Game.AI.Weapon
{
    public class Misslebotscript : MonoBehaviour
    {
        public float speed = 5;
        public float rotationspeed = 200;
        public GameObject target;
        Rigidbody2D rb;
        public GameObject missle;
        public float bulletfife = 5f;
        public ParticleSystem Explosion;

        void Start()
        {
            target = GameObject.FindGameObjectWithTag("player");
            rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            if (target == null)
            {
                Vector2 ptarget = (Vector2)transform.position;
                ptarget.Normalize();
                float floated = Vector3.Cross(ptarget, transform.right).z;

                rb.angularVelocity = rotationspeed * floated;

                rb.velocity = transform.right * speed;
            }
            else
            {
                Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
                point2Target.Normalize();
                float value = Vector3.Cross(point2Target, transform.right).z;

                rb.angularVelocity = rotationspeed * value;

                rb.velocity = transform.right * speed;
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "player")
            {
                Instantiate(Explosion, col.transform.position, col.transform.rotation);
                Explosion.Play();
                /*if (BotDifficult.impossible)
                    HealthbarScript.health -= 15;
                if(BotDifficult.abitharder)
                    HealthbarScript.health -= 5;
                if (BotDifficult.noob)
                    HealthbarScript.health -= 2;*/

                Destroy(missle);
            }

            if(col.gameObject.tag == "border")
                Destroy(missle);
        }
    }
}
