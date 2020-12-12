using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class ConnectToRoom : MonoBehaviourPunCallbacks
{
    private Text console_text;
    private Text playerNameText;
    public GameObject outputText;
    public GameObject playerName;
    public GameObject playerPlates;

    public  void Start()
    {
        console_text = outputText.GetComponent<Text>();
        playerNameText = playerName.GetComponent<Text>();
    }
    public void OnClickJoinRoom()
    {
        if (!PhotonNetwork.IsConnected)
        { 
            Debug.Log("No internet connection");
            return; 
        }
        if (PhotonNetwork.InRoom)
        {
            return;
        }
        string nickname = playerNameText.text;
        if (nickname == null)
        {
            nickname = "NoName";
        }
        PhotonNetwork.LocalPlayer.NickName = nickname;
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 2;
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(null, options);
        console_text.text = "Waiting for opponent...";
    }
    public override void OnJoinedRoom()
    {
        if (!PhotonNetwork.IsMasterClient)
            console_text.text = "Joined Room";
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PhotonView photonView_playerPlates = PhotonView.Get(playerPlates);
        PhotonView photonView_cosole = PhotonView.Get(outputText);
        photonView_playerPlates.RPC("update_names", RpcTarget.All);
        photonView_cosole.RPC("update_console", RpcTarget.All, "Everyone is ready!");
    }

    
}
