using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player.CameraProperties
{
    public class Camerafollow : MonoBehaviour {

        [SerializeField]
        GameObject targetToFollow;
        [SerializeField]
        GameObject Bot;

        public void Update () {

            if (targetToFollow == null)
            {
                transform.position = new Vector3(Bot.transform.position.x,
                    Bot.transform.position.y - 1f,
                    transform.position.z);
            }
            else
            {
                transform.position = new Vector3(targetToFollow.transform.position.x,
                    targetToFollow.transform.position.y - 1f,
                    transform.position.z);
            }
        }
    }
}
