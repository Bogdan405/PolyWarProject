using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;
using GameUserInterface;
using PlayerTurn;
public class GameNetwork : MonoBehaviour
{
    private int players_ready = 0;
    public GameObject UI;
    public GameObject exitPanel;
    public GameObject exitText;
    public GameObject gameLogic;

    public void OnClickUpdateReadyPlayers()
    {
        PhotonView gamePV = PhotonView.Get(this);
        gamePV.RPC("updateReadyPlayers", RpcTarget.All);
    }

    [PunRPC]
    public void updateReadyPlayers()
    {
        players_ready++;
        if(players_ready == 2)
        {
            GameUI gameUI= UI.GetComponent<GameUI>();
            gameUI.ShowAllPlayersAreReady();
            PhotonView turnPV = PhotonView.Get(gameLogic);
            Turn turn = gameLogic.GetComponent<Turn>();
            turn.InitTurns();
            if (turn.IsMyTurn())
            {
                gameUI.SetPlayCard(true);
            }
        }
    }

    [PunRPC]
    public void ExitGame(string reason)
    {
        Text exitString = exitText.GetComponent<Text>();
        exitString.text = reason;
        HideUIOnExit();
    }


    public void OnClickSurrender()
    {
        PhotonView connPV = PhotonView.Get(this);
        connPV.RPC("ExitGame", RpcTarget.Others, "The opponent has surrendered");
        Text exitString = exitText.GetComponent<Text>();
        exitString.text = "You have surrendered!";
        HideUIOnExit();
    }

    public void HideUIOnExit()
    {
        exitPanel.SetActive(true);
        GameUI gameUI = UI.GetComponent<GameUI>();
        gameUI.OnClickHideUI();
        gameUI.setShowButton(false);
    }

    public void OnClickLeaveRoom()
    {
        SSTools.ShowMessage("Left game!",SSTools.Position.bottom,SSTools.Time.threeSecond);
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("MainMenu");
    }


}
