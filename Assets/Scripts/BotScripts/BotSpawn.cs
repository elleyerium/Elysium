using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawn : MonoBehaviour

{
    public float nextSpawn;
    public Transform Spawn1; //точка 1 спавну
    public Transform Spawn2;
    private GameObject SpawnItbot; //Те, що спавнимо 
    [SerializeField]
    private float SpawnDelay;
    private float SpawnMultiplier;
    public GameObject Botprefabclone;


    public void Update()
    {
        if(Time.time >= SpawnMultiplier && Bots.botCounter <=25)
        {            
            SpawnDelay = Time.time + 2;
            SpawnMultiplier = SpawnDelay * 1.5f;
            SpawnIt();
        }

    }
    public void SpawnIt()
    {
        Botprefabclone = Instantiate(SpawnItbot, Spawn1.position, Spawn1.rotation) as GameObject;
        Destroy(Botprefabclone, 4);
        Debug.Log("Spawned from pos1");

    }
}