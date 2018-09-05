using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShot : MonoBehaviour
{
    public static float lazernextFire;
    public Transform lazer1;
    public GameObject lazer;
    public float lazerammo;
    public static bool isblaster;

    public void Lazershoot()
        
    {
        if (Time.time > lazernextFire && Blastercount.Ammodownlazer > 0)
        {
            isblaster = true;
            lazernextFire = Time.time + 1f;
            GameObject clonelazer = Instantiate(lazer, lazer1.position, lazer1.rotation);
            clonelazer.SetActive(true);
            Destroy(clonelazer, 4f);
            Blastercount.Ammodownlazer -= 1;
            Debug.Log("Lazer count -1");
        }
    }


}
