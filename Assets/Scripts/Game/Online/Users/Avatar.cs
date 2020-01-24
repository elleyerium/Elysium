using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Game.Online.Users
{
    public class Avatar : MonoBehaviour
    {
        public Image UserAvatar;

        public static Sprite GetTextureFromServer(byte[] buffer)
        {
            var texture = new Texture2D(54, 54);
            texture.LoadImage(buffer, false);
            return Sprite.Create(texture, new Rect(0,0,texture.width, texture.height), Vector2.zero);
        }
    }
}