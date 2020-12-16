using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using GameUserInterface;

public class GameNetwork : MonoBehaviour
{
    private int players_ready = 0;
    public GameObject UI;


    public void Start()
    {

    }


    [PunRPC]
    public void updateReadyPlayers()
    {
        players_ready++;
        if(players_ready == 2)
        {
            GameUI gameUI= UI.GetComponent<GameUI>();
            gameUI.ShowAllPlayersAreReady();
        }
    }
}
