using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawnedbothp: MonoBehaviour {
    public float hp;
    private float maxbothp = 100f;
    public GameObject bot;
    public int boxdropchance;

    void Start () {
        hp = maxbothp;
		
	}
	void Update () {
      if (hp <= 0)
        {
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
