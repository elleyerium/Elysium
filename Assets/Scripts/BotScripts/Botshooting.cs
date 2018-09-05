using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botshooting : MonoBehaviour
{
    public float rocketRate; //частота вистрілів
    public float nextrocket; //наступна ракета
    public GameObject shot1; //Компонент 1 ракети
    public GameObject shot2; //Компонент 2 ракети
    public Transform pos1; //позиція 1 ракети
    public Transform pos2; //позиція 2 ракети
    public GameObject player; //Гравець
    private int range = 2500;

    public void Update()
    {
        if (Vector3.Distance(pos1.position, player.transform.position) <= range && (Vector3.Distance(pos2.position, player.transform.position) <= range && Time.time > nextrocket))
        {
           nextrocket = Time.time + Random.Range(7,15);
           GameObject clone = Instantiate(shot1, pos1.position, pos1.rotation);
           GameObject clone2 = Instantiate(shot1, pos2.position, pos2.rotation);
           clone.SetActive(true);
           clone2.SetActive(true);
           Destroy(clone, 5f);
           Destroy(clone2, 5f);
           Debug.Log("I h've been shooted from rocket missile");    
        }              
    }
}

   