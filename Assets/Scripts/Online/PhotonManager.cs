using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonManager : Photon.MonoBehaviour
{
    public PhotonManager Instance;
    [SerializeField] private Text test;
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject Camera;
    [SerializeField] private Transform SpawnPoint, Playerpoint;
    [SerializeField] private GameObject lobbycamera;
    private void Awake()
    {
        Instance = this;
        PhotonNetwork.sendRate = 60;
        PhotonNetwork.sendRateOnSerialize = 30;
    }
    private void Start()
    { if (Createroom.HostPlayer == true)
        {
            PhotonNetwork.Instantiate(Player.name, Playerpoint.position, Playerpoint.rotation, 0);
        }
        Playerpoint.transform.position = new Vector3(Random.Range(300, 600), (Random.Range(300, 600)), -12);
        PhotonNetwork.automaticallySyncScene = true;
        
    }

    public virtual void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(Player.name, Playerpoint.position, Playerpoint.rotation, 0);
        PhotonNetwork.Instantiate(Camera.name, SpawnPoint.position, SpawnPoint.rotation, 0);
        Debug.Log("Cloned");
        lobbycamera.SetActive(false);

    }
}