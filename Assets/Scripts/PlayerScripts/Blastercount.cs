using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blastercount : MonoBehaviour {
    public static float Ammodownlazer;
    public static Text lazercount;


    void Start ()
    {
        if (BotDifficult.noob)
            Ammodownlazer = 250;
        if (BotDifficult.abitharder)
            Ammodownlazer = 90;
        if (BotDifficult.impossible)
            Ammodownlazer = 60;
        lazercount = GetComponent<Text>();
    }


    void Update ()
    {
        lazercount.text = "" + Ammodownlazer;
    }
}
