using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BotLazer : MonoBehaviour {
    public float speed;
    public GameObject botlazer;
    Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();

    }
	

	void FixedUpdate () {
        Vector2 road = (Vector2)transform.position;
        road.Normalize();
        rb.velocity = transform.right * speed;
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "player")
        {
            HealthbarScript.health -= 14;
            Destroy(botlazer);
        }

        if(col.gameObject.tag == "border")
        Destroy(botlazer);
    }
}


