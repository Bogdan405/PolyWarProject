using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;
using Photon.Realtime;
using Photon.Pun;
using GameUserInterface;
using PlayerTurn;

public class Board : MonoBehaviour
{
    private CardClass[] enemyCards;
    private CardClass[] personalCards;
    private bool playedCardThisTurn;
    public GameObject UI;
    private int turnCounter;

    void Start()
    {
        enemyCards = new CardClass[3];
        personalCards = new CardClass[3];
        playedCardThisTurn = false;
        turnCounter = 0;


        enemyCards[0] = null;
        enemyCards[1] = this.gameObject.AddComponent<CardClass>() as CardClass;
        enemyCards[1].Factory(Model.Sentry, Element.Chemical);
        enemyCards[2] = null;
        personalCards[0] = this.gameObject.AddComponent<CardClass>() as CardClass;
        personalCards[0].Factory(Model.Wraith, Element.Undead);
        personalCards[1] = null;
        personalCards[2] = null;
    }

    public CardClass[] GetEnemyCards()
    {
        return enemyCards;
    }

    public CardClass[] GetPersonalCards()
    {
        return personalCards;
    }

    public bool GetPlayedCardThisTurn()
    {
        return playedCardThisTurn;
    }

    public void SetEnemyCard(int cardNumber, CardClass card)
    {
        enemyCards[cardNumber] = card;
    }

    public void SetPersonalCard(int cardNumber, CardClass card)
    {
        enemyCards[cardNumber] = card;
    }

    public void PlayCard()
    {
        //SetPersonalCard(2,Factory(Model.Sentry, Element.Chemical))
        personalCards[0].Factory(Model.Sentry, Element.Chemical);
        playedCardThisTurn = true;
        UI.GetComponent<GameUI>().SetEndTurnButton(true);
    }

    public void Fight()
    {
        PhotonView boardPV = PhotonView.Get(this);
        boardPV.RPC("HideUI", RpcTarget.All);
        System.Threading.Thread.Sleep(2000);

        boardPV.RPC("ShowUI", RpcTarget.All);
    }

    public void OnClickEndTurn()
    {
        PhotonView boardPV = PhotonView.Get(this);
        boardPV.RPC("ResetPlayerTurn", RpcTarget.All);
    }

    [PunRPC]
    public void HideUI()
    {
        UI.GetComponent<GameUI>().OnClickHideUI();
        UI.GetComponent<GameUI>().setShowButton(false);
    }

    [PunRPC]
    public void ShowUI()
    {
        UI.GetComponent<GameUI>().OnClickShowUI();
        UI.GetComponent<GameUI>().setShowButton(true);
    }

    [PunRPC]
    public void ResetPlayerTurn()
    {
        turnCounter++;
        if(turnCounter % 2 == 0)
        {
            Fight();
        }
        else
        {
            PhotonView boardPV = PhotonView.Get(this);
            boardPV.RPC("ChangeTurn", RpcTarget.All);
        }
        if(this.GetComponent<Turn>().IsMyTurn()){
            playedCardThisTurn = false;
        }
    }
}
