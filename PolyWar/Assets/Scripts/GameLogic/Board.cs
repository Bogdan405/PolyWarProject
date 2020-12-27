using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;
using Photon.Realtime;
using Photon.Pun;

public class Board : MonoBehaviour
{
    private CardClass[] enemyCards;
    private CardClass[] personalCards;
    private bool playedCardThisTurn;
    private GameObject gameUI;
    private GameObject turn;

    void Start()
    {
        enemyCards = new CardClass[3];
        personalCards = new CardClass[3];
        playedCardThisTurn = false;
        


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

    }

    public void Fight()
    {

    }

    public void OnClickEndTurn()
    {

    }

    [PunRPC]
    public void HideUI()
    {

    }

    [PunRPC]
    public void ResetPlayerTurn()
    {

    }
}
