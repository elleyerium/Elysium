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
    public GameObject player, bot; //Гравець
    private float range = 2500;

    public void FixedUpdate()
    {
        if (Vector3.Distance(bot.transform.position, player.transform.position) < range && Time.time > nextrocket)
        {
            if (BotDifficult.noob)
                nextrocket = Time.time + Random.Range(6, 7);
            if (BotDifficult.abitharder)
                nextrocket = Time.time + Random.Range(8, 9);
            if (BotDifficult.impossible)
                nextrocket = Time.time + Random.Range(9, 10);

            GameObject clone = Instantiate(shot1, pos1.position, pos1.rotation);
            GameObject clone2 = Instantiate(shot1, pos2.position, pos2.rotation);
            clone.SetActive(true);
            clone2.SetActive(true);
            Destroy(clone, 5f);
            Destroy(clone2, 5f);
        }          
    }
}

   