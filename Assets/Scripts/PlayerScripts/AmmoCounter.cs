using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public static int AmmodownRocket = 20;
    [SerializeField]
    public static Text rocketcount;


   
    void Start ()
    {
        rocketcount = GetComponent<Text>();
     }

    void Update ()
    {
        rocketcount.text = "" + AmmodownRocket; 
    }
}
