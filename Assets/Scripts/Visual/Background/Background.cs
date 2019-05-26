using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public float Speed;
    public Material material;
    void Update () 
	{
        Vector2 offset = new Vector2(Time.time * Speed, Time.time * 0.2f);
        material.mainTextureOffset = offset;
    }
}
