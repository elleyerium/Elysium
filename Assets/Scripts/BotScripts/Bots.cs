using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bots : MonoBehaviour
{
    [SerializeField]
    private Text Alive;
    public float maxbothp = 100f;
    public static int botCounter =0;
    public Transform Spawn1;
    public Transform Spawn2;
    public GameObject Botprefabclone;
    [SerializeField]
    private float SpawnDelay, SpawnMultiplier;

    public void Update()
   {
        Alive.text = ("bots alive : " + botCounter);

        if (Time.time >= SpawnMultiplier && botCounter <=10)
        {
            SpawnDelay = Time.time + 2;
            SpawnMultiplier = SpawnDelay +15;
            SpawnIt();
            botCounter += 2;
            Debug.Log(botCounter);

        }
        
   }
    public void SpawnIt()
    {
        GameObject SpawnItbot1 = Instantiate(Botprefabclone, Spawn1.position, Spawn1.rotation) as GameObject;
        GameObject SpawnItbot2 = Instantiate(Botprefabclone, Spawn2.position, Spawn2.rotation) as GameObject;
        Debug.Log("Spawned from pos1");
        //Alive_Counter += 2;
    }
}