using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonManager : Photon.MonoBehaviour
{
    public PhotonManager Instance;
    public GameObject Panel;
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
    {
        
        PhotonNetwork.automaticallySyncScene = true;
        
    }
    void Update()
    {
        if (PhotonNetwork.room.PlayerCount <= 1)
            Panel.SetActive(true);
        else
            Panel.SetActive(false);

        Playerpoint.transform.position = new Vector3(Random.Range(0, 2000), (Random.Range(1000, 2000)), -12);
    }
    public virtual void OnJoinedRoom()
    {
        //PhotonNetwork.Instantiate(Player.name, Playerpoint.position, Playerpoint.rotation, 0);
        PhotonNetwork.Instantiate(Player.name, Playerpoint.position, Playerpoint.rotation, 0);
        PhotonNetwork.Instantiate(Camera.name, SpawnPoint.position, SpawnPoint.rotation, 0);
        Debug.Log("Cloned");
        lobbycamera.SetActive(false);

    }
}