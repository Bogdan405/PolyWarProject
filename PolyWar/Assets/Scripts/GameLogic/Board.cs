using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;
using Photon.Realtime;
using Photon.Pun;
using GameUserInterface;
using PlayerTurn;
using Pairs;
public class Board : MonoBehaviour
{
    private CardClass[] enemyCards;
    private CardClass[] personalCards;
    private int playedCardsThisTurn;
    public GameObject UI;
    public GameObject AR;
    private int turnCounter;
    private Deck personalDeck;
    private Hand personalHand;
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
        personalDeck = new Deck();
        personalDeck.GenerateDeck();
        personalHand = new Hand();
        personalHand.FillHand(personalDeck);
    }

    public CardClass[] GetEnemyCards()
    {
        return enemyCards;
    }

    public CardClass[] GetPersonalCards()
    {
        return personalCards;
    }


    public bool IsEmptyField(int position, bool enemy)
    {
        if (enemy)
        {
            return enemyCards[position].IsEmpty();
        }
        else
        {
            return personalCards[position].IsEmpty();
        }
        
    }


    public bool IsEmptyHand(int position)
    {

        return personalHand.isEmptyPosition(position);

    }
    public Pair getModelOfHand(int position)
    {
        return new Pair(personalHand.PeakCardElement(position), personalHand.PeakCardModel(position));
    }
    public Pair getModelOfField(int position,bool enemy)
    {
        if (!enemy)
        {
            return new Pair(personalCards[position].element, personalCards[position].model);
        }
        
        return new Pair(enemyCards[position].element, enemyCards[position].model);

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

    public bool isFullField()
    {
        for(int index = 0; index < 3; index++)
        {
            if (personalCards[index].IsEmpty())
            {
                return false;
            }
        }
        return true;
    }
    private bool isLegalFieldPos(int position)
    {
        if (personalCards[position].IsEmpty())
            return true;
        return false;
    }

    private bool isLegalCardPos(int position)
    {
        return !personalHand.isEmptyPosition(position);
    }

    public void OnClickPlayCard()
    {
        if (this.GetComponent<Turn>().IsMyTurn() && playedCardsThisTurn < 3)
        {
            if (personalHand.GetHandSize() == 0)
            {
                SSTools.ShowMessage("No more cards!", SSTools.Position.bottom, SSTools.Time.twoSecond);
                return;
            }
            int cardPos = 0;
            int fieldPos = 0;
            while (!isLegalFieldPos(fieldPos) && fieldPos<3)
            {
                fieldPos++;
            }
            if (isLegalFieldPos(fieldPos))
            {
                Pair card = personalHand.GetCard(cardPos);
                personalCards[fieldPos].Factory(card.model, card.element);
                playedCardsThisTurn++;
                UI.GetComponent<GameUI>().SetEndTurnButton(true);
                if (playedCardsThisTurn == 3)
                {
                    UI.GetComponent<GameUI>().SetPlayCard(false);
                }
            }
            else
            {
                SSTools.ShowMessage("Invalid Field or Card", SSTools.Position.middle, SSTools.Time.oneSecond);
            }

        }
    }
    public void PlayCard()
    {   
        if(this.GetComponent<Turn>().IsMyTurn() && playedCardsThisTurn < 3)
        {   
            if(personalHand.GetHandSize() == 0)
            {
                SSTools.ShowMessage("No more cards!", SSTools.Position.bottom, SSTools.Time.twoSecond);
                return;
            }
            int cardPos = AR.GetComponent<ImageDetectionScript>().GetSelectedCard();
            int fieldPos = AR.GetComponent<ImageDetectionScript>().GetSelectedField();
            if( cardPos == -1)
            {
                SSTools.ShowMessage("Card not selected!", SSTools.Position.bottom, SSTools.Time.twoSecond);
                return;
            }
            if (fieldPos == -1)
            {
                SSTools.ShowMessage("Field not selected!", SSTools.Position.bottom, SSTools.Time.twoSecond);
                return;
            }
            if(isLegalCardPos(cardPos) && isLegalFieldPos(fieldPos))
            {
                Pair card = personalHand.GetCard(cardPos);
                personalCards[fieldPos].Factory(card.model, card.element);
                playedCardsThisTurn++;
                UI.GetComponent<GameUI>().SetEndTurnButton(true);
                if (playedCardsThisTurn == 3)
                {
                    UI.GetComponent<GameUI>().SetPlayCard(false);
                }
            }
            else
            {
                SSTools.ShowMessage("Invalid Field or Card", SSTools.Position.middle, SSTools.Time.oneSecond);
            }
            
        }
    }

    public void Fight()
    {
        HideUI();
        for (int place = 0; place < 3; place++)
        {

            int[] life_decrease = this.GetComponent<Battle>().CommitBattle(personalCards[place], enemyCards[place],place);
            if (this.GetComponent<Turn>().IsMyTurn())
            {
                this.GetComponent<HP>().UpdateHPValues(HP.GetPersonalHP() - life_decrease[0], HP.GetEnemyHP() - life_decrease[1]);
            }
            
            
            if (!personalCards[place].IsAlive())
            {
                AR.GetComponent<ImageDetectionScript>().myFieldDeath(place);
                personalCards[place].SetEmpty();
            }
            if (!enemyCards[place].IsAlive())
            {
                AR.GetComponent<ImageDetectionScript>().enemyFieldDeath(place);
                enemyCards[place].SetEmpty();
            }
        }
        ShowUI();
    }


    public void OnClickEndTurn()
    {
        PhotonView boardPV = PhotonView.Get(this);
        personalHand.FillHand(personalDeck);
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
        else
        {
            this.GetComponent<Turn>().ChangeTurn();
        }
        
        UI.GetComponent<GameUI>().SetEndTurnButton(false);

        if(this.GetComponent<Turn>().IsMyTurn()){
            playedCardsThisTurn = 0;
            UI.GetComponent<GameUI>().SetPlayCard(true);    
        }
        else
        {
            UI.GetComponent<GameUI>().SetPlayCard(false);
        }
    }
}
