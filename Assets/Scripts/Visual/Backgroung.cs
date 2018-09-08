using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroung : MonoBehaviour {

    public float Speed;

	void Update () {
        Vector2 offset = new Vector2(Time.time * Speed, Time.time * 0.2f);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
