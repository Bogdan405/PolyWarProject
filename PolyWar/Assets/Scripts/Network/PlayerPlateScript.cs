using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class PlayerPlateScript : MonoBehaviourPunCallbacks
{

    public GameObject player1Name;
    public GameObject player2Name;


    [PunRPC]
    public void update_names()
    {
        Text p1Name = player1Name.GetComponent<Text>();
        Text p2Name = player2Name.GetComponent<Text>();
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player.IsMasterClient)
            {
                p1Name.text = player.NickName;
            }
            else
            {
                p2Name.text = player.NickName;
            }

        }
    }
}
