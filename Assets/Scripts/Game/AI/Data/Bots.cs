using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.AI.Data
{
    public class Bots : MonoBehaviour
    {
        [SerializeField]
        private Text Alive;
        public float maxbothp = 100f;
        public static int botCounter =0;
        public Transform Spawn1;
        public Transform Spawn2;
        [SerializeField] private Transform _enemyParent;
        public GameObject Botprefabclone;
        [SerializeField]
        private float SpawnDelay, SpawnMultiplier;

        public void Update()
        {
            Alive.text = "bots alive : " + botCounter;

            if (Time.time >= SpawnMultiplier && botCounter <=20)
            {
                SpawnDelay = Time.time + 2;
                SpawnMultiplier = SpawnDelay +10;
                SpawnIt();
                botCounter += 2;
                Debug.Log(botCounter);
            }

        }
        public void SpawnIt()
        {
            var SpawnItbot1 = Instantiate(Botprefabclone, Spawn1.position, Spawn1.rotation, _enemyParent);
            var SpawnItbot2 = Instantiate(Botprefabclone, Spawn2.position, Spawn2.rotation, _enemyParent);
            Debug.Log("Spawned from pos1");
            //Alive_Counter += 2;
        }
    }
}
