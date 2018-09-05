using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonManager : Photon.MonoBehaviour {
    [SerializeField] private Text test;
    [SerializeField] public GameObject Player;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private GameObject lobbycamera;
   private void Start()
    { 
        PhotonNetwork.JoinLobby();
    }
    void Update () {
        test.text = PhotonNetwork.connectionStateDetailed.ToString();
	}
    public virtual void OnJoinedLobby()
    {   
        Debug.Log(" We have joined to lobby");
        PhotonNetwork.JoinOrCreateRoom("Deathmatch", null, null);
    }
    public virtual void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(Player.name, SpawnPoint.position, SpawnPoint.rotation, 0);
        Debug.Log("Cloned");
        lobbycamera.SetActive(false);

    }
}
