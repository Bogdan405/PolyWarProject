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
    private int playedCardsThisTurn;
    public GameObject UI;
    private int turnCounter;
    void Start()
    {
        enemyCards = new CardClass[3];
        personalCards = new CardClass[3];
        playedCardsThisTurn = 0;
        turnCounter = 0;


        enemyCards[0] = new CardClass();
        enemyCards[1] = new CardClass();
        enemyCards[2] = new CardClass();
        personalCards[0] = new CardClass();
        personalCards[1] = new CardClass();
        personalCards[2] = new CardClass();
    }

    public CardClass[] GetEnemyCards()
    {
        return enemyCards;
    }

    public CardClass[] GetPersonalCards()
    {
        return personalCards;
    }

    public int GetPlayedCardThisTurn()
    {
        return playedCardsThisTurn;
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
        // params position and card from AR taken
        if(this.GetComponent<Turn>().IsMyTurn() && playedCardsThisTurn < 3)
        {
            personalCards[0].Factory(Model.Sentry, Element.Chemical);
            playedCardsThisTurn ++;
            UI.GetComponent<GameUI>().SetEndTurnButton(true);
            if(playedCardsThisTurn == 3)
            {
                UI.GetComponent<GameUI>().SetPlayCard(false);
            }
        }
    }

    public void Fight()
    {
        //Animations for AR
        HideUI();
        for (int place = 0; place < 3; place++)
        {
            Battle.CommitBattle(personalCards[place], enemyCards[place]);
        }
        ShowUI();
    }

    public void OnClickEndTurn()
    {
        PhotonView boardPV = PhotonView.Get(this);
        boardPV.RPC("ResetPlayerTurn", RpcTarget.All,
            (byte)personalCards[0].MGetModel(), (byte)personalCards[0].EGetElement(), personalCards[0].GetLife(), personalCards[0].IsEmpty(),
            (byte)personalCards[1].MGetModel(), (byte)personalCards[1].EGetElement(), personalCards[1].GetLife(), personalCards[1].IsEmpty(),
            (byte)personalCards[2].MGetModel(), (byte)personalCards[2].EGetElement(), personalCards[2].GetLife(), personalCards[2].IsEmpty());
    }


    public void HideUI()
    {
        UI.GetComponent<GameUI>().OnClickHideUI();
        UI.GetComponent<GameUI>().setShowButton(false);
    }

    public void ShowUI()
    {
        UI.GetComponent<GameUI>().OnClickShowUI();
        UI.GetComponent<GameUI>().setShowButton(true);
    }

    [PunRPC]
    public void ResetPlayerTurn(byte m1, byte el1,int life1,bool empty1, byte m2, byte el2, int life2, bool empty2, byte m3, byte el3, int life3, bool empty3)
    {
        if (!this.GetComponent<Turn>().IsMyTurn())
        {
            if (!empty1)
            {
                enemyCards[0].Factory((Model)m1, (Element)el1);
                enemyCards[0].SetLife(life1);
            }
            if (!empty2)
            {
                enemyCards[1].Factory((Model)m2, (Element)el2);
                enemyCards[1].SetLife(life2);
            }
            if (!empty3)
            {
                enemyCards[2].Factory((Model)m3, (Element)el3);
                enemyCards[2].SetLife(life3);
            }
        }
        turnCounter++;
        if(turnCounter % 2 == 0)
        {
            Fight();
        }
        this.GetComponent<Turn>().ChangeTurn();
        UI.GetComponent<GameUI>().SetEndTurnButton(false);

        if(this.GetComponent<Turn>().IsMyTurn()){
            playedCardsThisTurn = 0;
        }
    }
}
