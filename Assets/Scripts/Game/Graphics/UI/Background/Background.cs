using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Graphics.UI.Background
{
    public class Background : MonoBehaviour
    {

        public float Speed;
        public Material material;
        void Update ()
        {
            var offset = new Vector2(Time.time * Speed, Time.time * 0.2f);
            material.mainTextureOffset = offset;
        }
    }
}
