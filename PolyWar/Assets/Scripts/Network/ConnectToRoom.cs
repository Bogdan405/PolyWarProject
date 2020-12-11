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
    public GameObject player1Name;
    public GameObject player2Name;

    public  void Start()
    {
        console_text = outputText.GetComponent<Text>();
        playerNameText = playerName.GetComponent<Text>();
    }
    public void OnClickJoinRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;
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
        Debug.Log(newPlayer.NickName);
    }
}
