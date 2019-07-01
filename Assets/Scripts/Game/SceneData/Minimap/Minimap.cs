using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.SceneData.Minimap
{
    public class Minimap : MonoBehaviour {

        public GameObject player;
        public GameObject bot;
        public GameObject playerbody;
        public GameObject botbody;

        void Update () {
            if ( bot != null)
            {
                player.transform.position = new Vector3(playerbody.transform.position.x,
                    playerbody.transform.position.y - 1f,
                    transform.position.z);
                bot.transform.position = new Vector3(botbody.transform.position.x,
                    botbody.transform.position.y - 1f,
                    transform.position.z);
            }
            else
            {
                player.transform.position = new Vector3(playerbody.transform.position.x,
                    playerbody.transform.position.y - 1f,
                    transform.position.z);
            }
        }
    }
}
