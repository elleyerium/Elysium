using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blastercount : MonoBehaviour {
    public static int Ammodownlazer = 90;
    public static Text lazercount;


    void Start ()
    {
        lazercount = GetComponent<Text>();
    }


    void Update ()
    {
        lazercount.text = "" + Ammodownlazer;
    }
}
