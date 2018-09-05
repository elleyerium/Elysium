using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazermove : MonoBehaviour {
    public float speed;
    public GameObject lazer;
    Rigidbody2D rb;
    public float lazernextFire;
    public Transform lazer1;

    void Start() {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update() {
        Vector2 lazermove = (Vector2)transform.position;
        lazermove.Normalize();
        rb.velocity = transform.right * speed;



    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "bot")
        {
            Destroy(lazer);
            Scores.Scoreup += Random.Range(9.0f, 11.30f);
        }

        if(col.gameObject.tag == "border")
        {
            Destroy(lazer);
            Scores.Scoreup -= 0;
        }
      
    }
}
