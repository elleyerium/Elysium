using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public static int AmmodownRocket;
    [SerializeField]
    public static Text rocketcount;


   
    void Start ()
    {
        if (BotDifficult.noob)
            AmmodownRocket = 100;
        if (BotDifficult.abitharder)
            AmmodownRocket = 50;
        if (BotDifficult.impossible)
            AmmodownRocket = 30;


        rocketcount = GetComponent<Text>();
    }

    void Update ()
    {
        rocketcount.text = "" + AmmodownRocket; 
    }
}
