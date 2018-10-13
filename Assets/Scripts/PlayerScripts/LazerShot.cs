using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazerShot : MonoBehaviour
{
    public static float lazernextFire;
    [SerializeField]
    public Transform lazer1;
    public GameObject lazer, Zero_ammo;
    public float lazerammo;
    private Image Fill;


    

    public void Lazershoot()
        
    {
        if (Time.time > lazernextFire && Blastercount.Ammodownlazer > 0)
        {
            //isblaster = true;
            lazernextFire = Time.time + 1f;
            GameObject clonelazer = Instantiate(lazer, lazer1.position, lazer1.rotation);
            clonelazer.SetActive(true);
            Destroy(clonelazer, 4f);
            Blastercount.Ammodownlazer -= 1;
            Debug.Log("Lazer count -1");
        }
        if (Blastercount.Ammodownlazer <= 0)
        {
            Zero_ammo.SetActive(true);
        }
    }

    public void OnlineBlaster()
    {
        if(Time.time > lazernextFire)
        {
            lazernextFire = Time.time + 1;
            GameObject lazer = PhotonNetwork.Instantiate("PlayerBlaster", lazer1.position, lazer1.rotation, 0);
            lazer.SetActive(true);
            
        }
    }



}
