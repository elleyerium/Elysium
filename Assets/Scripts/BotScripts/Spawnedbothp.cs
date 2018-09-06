using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawnedbothp: MonoBehaviour {
    public int hp;
    public static byte Countofkilled = 0;
    private int maxbothp = 100;
    public GameObject bot;
    public byte boxdropchance;

    void Start () {
        hp = maxbothp;
		
	}
	void Update () {
      if (hp <= 0)
        {
            Countofkilled += 1;
            Destroy(bot);
        }

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
     if(collider.gameObject.tag == "Rocketmissle")
        {
            hp -= 15;
        }
     if(collider.gameObject.tag == "blaster")
        {
            hp -= 25;
        }
    }

}
