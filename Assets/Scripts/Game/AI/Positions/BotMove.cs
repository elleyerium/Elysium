using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI.Positions
{
    public class BotMove : MonoBehaviour
    {
        public GameObject target;
        float range = 2000f;
        float speed = 700f;
        float rotspeed = 200f;
        public GameObject player;
        public GameObject bot;
        Rigidbody2D botbody;
        public AudioSource AmmoSource;
        public AudioClip rocketAudio, blasterAudio;

        void Start()
        {
            botbody = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("player");

        }

        void FixedUpdate()
        {
            if (target == null)
            {
                Vector2 movewithoutplayer = (Vector2)transform.position;
                movewithoutplayer.Normalize();
                float value = Vector3.Cross(movewithoutplayer, transform.up).z;
                botbody.angularVelocity = rotspeed * value;
                botbody.velocity = speed * transform.up;
            }

            else
            {
                if (Vector3.Distance(bot.transform.position, target.transform.position) <= range)
                {
                    Vector2 movetotarget = (Vector2)transform.position - (Vector2)target.transform.position;
                    movetotarget.Normalize();
                    float value = Vector3.Cross(movetotarget, transform.up).z;
                    botbody.angularVelocity = Random.Range(100, 250) * value;
                    botbody.velocity = speed * transform.up;
                    if (Vector3.Distance(bot.transform.position, target.transform.position) <= 200)
                    {
                        botbody.angularVelocity = 0;

                    }
                }

                else
                {
                    Vector2 movetotarget = (Vector2)transform.position;
                    movetotarget.Normalize();
                    float value = Vector3.Cross(movetotarget, transform.right).z;
                    botbody.angularVelocity = Random.Range(1f, 1000f) * value;
                    botbody.velocity = Random.Range(1f, 1000f) * transform.up;
                }
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Rocketmissle")
            {
                AmmoSource.PlayOneShot(rocketAudio);
            }

            if (col.gameObject.tag == "blaster")
            {
                AmmoSource.PlayOneShot(blasterAudio);
            }
        }
    }
}

