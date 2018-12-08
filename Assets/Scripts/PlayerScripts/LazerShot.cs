using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LazerShot : MonoBehaviour
{
    public static float lazernextFire;
    [SerializeField] public Transform lazer1;
    public GameObject lazer, Zero_ammo;
    private float _lazerfirstammo;
    private Image Fill;
    [SerializeField] private Button _hold;
    private bool pointerDown;

    void Start()
    {
        _lazerfirstammo = Blastercount.Ammodownlazer;
    }

void Update()
    {
        if (pointerDown)
        {
            if (Time.time > lazernextFire && Blastercount.Ammodownlazer > 0)
            {
                lazernextFire = Time.time + 0.3f;
                GameObject clonelazer = Instantiate(lazer, lazer1.position, lazer1.rotation);
                clonelazer.SetActive(true);
                Destroy(clonelazer, 4f);
                Blastercount.Ammodownlazer -= 1;
                Debug.Log("Lazer count -1");
                
                if (Blastercount.Ammodownlazer <= 0)
                {
                    Zero_ammo.SetActive(true);
                }
            }
        }
        else if (Blastercount.Ammodownlazer < _lazerfirstammo && pointerDown == false )
        {
            var ammo = Blastercount.Ammodownlazer += 1 * Time.deltaTime;
            Blastercount.Ammodownlazer = Mathf.RoundToInt(ammo);
        }
    }

    public void IsPressed()
    {
        pointerDown = true;
    }

    public void IsUnPressed()
    {
        pointerDown = false;
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
