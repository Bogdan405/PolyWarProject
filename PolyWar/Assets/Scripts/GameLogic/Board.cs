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
        boardPV.RPC("ResetPlayerTurn", RpcTarget.All, personalCards);
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
    public void ResetPlayerTurn(CardClass[] cardsModified)
    {
        if (!this.GetComponent<Turn>().IsMyTurn())
        {
            enemyCards = cardsModified;
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
