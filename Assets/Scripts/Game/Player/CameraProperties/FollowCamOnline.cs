using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player.CameraProperties
{
    public class FollowCamOnline : MonoBehaviour
    {
        GameObject targetToFollow;

        void Start() =>
            targetToFollow = GameObject.FindWithTag("player");

        public void Update()
        {


            transform.position = new Vector3(targetToFollow.transform.position.x,
                targetToFollow.transform.position.y - 1f,
                transform.position.z);

        }
    }
}

