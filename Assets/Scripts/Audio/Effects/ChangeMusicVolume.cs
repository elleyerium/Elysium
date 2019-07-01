using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Audio.Effects
{
    public class ChangeMusicVolume : MonoBehaviour
    {
        public Slider Volume;
        public AudioSource myMusic;

        void Update() => myMusic.volume = Volume.value;
    }
}
