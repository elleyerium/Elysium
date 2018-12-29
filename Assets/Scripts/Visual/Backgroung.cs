using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroung : MonoBehaviour {

    public float Speed;
    public static Renderer r;

    void Start()
    {
       r = GetComponent<Renderer>();
    }

	void Update () {
        Vector2 offset = new Vector2(Time.time * Speed, Time.time * 0.2f);
        r.material.mainTextureOffset = offset;
    }
}
