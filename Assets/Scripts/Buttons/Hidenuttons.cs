using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidenuttons : MonoBehaviour
{
    public GameObject start, lobby, gamemodechoose, styling, scores, text, allbuttons;
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
        Initiate.Fade("bots", Color.black, 4.5f);
        gamemodechoose.SetActive(false);
        text.SetActive(true);
        PlayerPrefs.SetInt("Play Counter", Settings.PlayedCount +=1);
    }
    public void Back()
    {
        gamemodechoose.SetActive(false);
        Whattodo();
    }
    public void Onlineback()
    {
        Whattodo();
        allbuttons.SetActive(true);
        lobby.SetActive(false);
    }
    private void Whattodo()
    {
        start.SetActive(true);
        styling.SetActive(true);
        scores.SetActive(true);
        text.SetActive(true);
    }
    private void Whattodoonline()
    {
        start.SetActive(false);
        styling.SetActive(false);
        scores.SetActive(false);
        text.SetActive(false);
        
    }
}
