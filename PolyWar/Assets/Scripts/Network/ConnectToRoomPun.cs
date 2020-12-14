using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using MainUI;
using UnityEngine.SceneManagement;

public class ConnectToRoomPun : MonoBehaviourPunCallbacks
{
    public GameObject nicknameObject;
    public GameObject UI;
    private MainMenuUI menuUI;
    private bool otherPlayerAccept = false;


    public void Start()
    {
        menuUI = UI.GetComponent<MainMenuUI>();
    }
    public void OnClickJoinRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SSTools.ShowMessage("Lost connection!", SSTools.Position.bottom, SSTools.Time.twoSecond);
            Application.Quit();
        }
        if (PhotonNetwork.InRoom)
        {
            SSTools.ShowMessage("Already searching!", SSTools.Position.bottom, SSTools.Time.twoSecond);
            return;
        }

        string nickname = GetNickname();
        if (nickname == "")
        {
            SSTools.ShowMessage("Enter a Nickname!", SSTools.Position.bottom, SSTools.Time.twoSecond);
            return;
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
        menuUI.DisableMainMenu();
        menuUI.EnableWaitingUI();
    }

    public override void OnJoinedRoom()
    {
        if (!PhotonNetwork.IsMasterClient) 
        {
            menuUI.DisableMainMenu();
            menuUI.EnableAcceptingUI();
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        menuUI.DisableWaitingUI();
        menuUI.EnableAcceptingUI();
    }

    private string GetNickname()
    {
        return nicknameObject.GetComponent<Text>().text;
    }

    public void OnClickLeaveRoom()
    {
        PhotonView UIPV = PhotonView.Get(UI);
        UIPV.RPC("ReturnMainMenu", RpcTarget.All);
        PhotonView connection = PhotonView.Get(this);
        connection.RPC("DestroyCurrentRoom", RpcTarget.All);
    }

    [PunRPC]
    public void DestroyCurrentRoom()
    {
        if (PhotonNetwork.IsMasterClient) {
            PhotonNetwork.DestroyAll();
        }
        PhotonNetwork.LeaveRoom();
    }


    [PunRPC]
    public void NotifyAcceptance()
    {
        if (!otherPlayerAccept)
        {
            otherPlayerAccept = true;
            SSTools.ShowMessage("Opponent Accepted!", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }   
    }

    [PunRPC]
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }


    public void OnClickAcceptGame()
    {
        PhotonView connection = PhotonView.Get(this);
        if (otherPlayerAccept)
        {
            connection.RPC("StartGame", RpcTarget.All);
        }
        else 
        {
            otherPlayerAccept = true;
            connection.RPC("NotifyAcceptance", RpcTarget.All);
            SSTools.ShowMessage("Accepted!", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
    }
}
