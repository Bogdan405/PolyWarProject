using Photon.Realtime;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectToMaster : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected! Cause:" + cause.ToString());
    }
}
