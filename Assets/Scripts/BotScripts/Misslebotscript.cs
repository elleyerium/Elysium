using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misslebotscript : MonoBehaviour
{
    public float speed = 5;
    public float rotationspeed = 200;
    public GameObject target;
    Rigidbody2D rb;
    public GameObject missle;
    public float bulletfife = 5f;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player");
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            Vector2 ptarget = (Vector2)transform.position;
            ptarget.Normalize();
            float floated = Vector3.Cross(ptarget, transform.right).z;

            rb.angularVelocity = rotationspeed * floated;

            rb.velocity = transform.right * speed;
        }
        else
        {
            Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
            point2Target.Normalize();
            float value = Vector3.Cross(point2Target, transform.right).z;

            rb.angularVelocity = rotationspeed * value;

            rb.velocity = transform.right * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            HealthbarScript.health -= 2;
            Destroy(missle);
        }

        if(col.gameObject.tag == "border")
        Destroy(missle);   
    }
}
