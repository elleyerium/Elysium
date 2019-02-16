using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidenuttons : MonoBehaviour
{
    public GameObject start, lobby, gamemodechoose, styling, scores, text, allbuttons, paneldifficult, MusicManager, setPan,PlayerStatus;

    void Update()
    {
        Whattodoonline();
    }
    public void Online()
    {
        Whattodoonline();
        gamemodechoose.SetActive(false);
        lobby.SetActive(true);
        allbuttons.SetActive(false);
        PhotonNetwork.JoinLobby(TypedLobby.Default);

    }
    public void Offline()
    {
        paneldifficult.SetActive(true);
    }
    public void Back()
    {
        WhattodoBack();
        gamemodechoose.SetActive(false);
        PlayerStatus.SetActive(true);
        
    }
    public void Onlineback()
    {
        allbuttons.SetActive(true);
        Back();
        lobby.SetActive(false);
    }
    private void WhattodoBack()
    {
        setPan.SetActive(true);
        start.SetActive(true);
        styling.SetActive(true);
        scores.SetActive(true);
        MusicManager.SetActive(true);
    }
    private void Whattodoonline()
    {
        start.SetActive(false);
        styling.SetActive(false);
        scores.SetActive(false);
        
    }
}
