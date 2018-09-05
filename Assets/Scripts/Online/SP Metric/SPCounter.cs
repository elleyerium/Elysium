using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPCounter : MonoBehaviour
{
    public static float SP;

    void Start()
    {

    }

    void Update()
    {
        SP = (Scores.Currently_score * 0.0011f);

    }
}
