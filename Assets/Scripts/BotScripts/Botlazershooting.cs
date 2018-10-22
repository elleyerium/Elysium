using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botlazershooting : MonoBehaviour
{
        public float speed;
        public GameObject botlazer;
        public float nextLazer;
        public Transform lazerpos;
        public int range;

    public void Update()
    {
            if (Time.time > nextLazer)
            {
                nextLazer = Time.time + 4;
                GameObject cloneshot = Instantiate(botlazer, lazerpos.position, lazerpos.rotation);
                cloneshot.SetActive(true);
                Destroy(cloneshot, 3f);
            }

     }

}