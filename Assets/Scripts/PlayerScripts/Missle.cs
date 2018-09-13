using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    
    public float speed = 5;
    public float rotationspeed = 200;
    public GameObject[] target;
    Rigidbody2D rb;
    public GameObject missle;
    public float bulletfife = 5f;
    public ParticleSystem Explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {


        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);


        if (Vector3.Distance(missle.transform.position, closestEnemy.transform.position) <= 1000)
        {   Vector2 point2Target = (Vector2)transform.position - (Vector2)closestEnemy.transform.position;
            point2Target.Normalize();
            float value = Vector3.Cross(point2Target, transform.right).z;
            rb.angularVelocity = rotationspeed * value;
            rb.velocity = transform.right * speed;
        }
        if(Vector3.Distance(missle.transform.position, closestEnemy.transform.position) > 1000)
        {  Vector2 point2Target = (Vector2)transform.position;
            point2Target.Normalize();
            float value = Vector3.Cross(point2Target, transform.right).z;
            rb.velocity = transform.right * speed;
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bot")
        {
            Instantiate(Explosion, other.transform.position, other.transform.rotation);
            Explosion.Play();
            Scores.Scoreup += Random.Range(3.7f, 5.2f);
            Destroy(missle);
        }
        else
        {
            Scores.Scoreup += 0;
            Destroy(missle);
        }
    }
}
