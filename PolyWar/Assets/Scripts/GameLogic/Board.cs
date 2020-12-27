using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;

public class Board : MonoBehaviour
{
    private CardClass[] enemyCards;
    private CardClass[] personalCards;

    void Start()
    {
        enemyCards = new CardClass[3];
        personalCards = new CardClass[3];

        enemyCards[0] = null;
        enemyCards[1] = new CardClass(Model.Sentry, Element.Automaton);
        enemyCards[2] = new CardClass(Model.Juggernaut, Element.Chemical);

        personalCards[0] = new CardClass(Model.Sentry, Element.Chemical);
        personalCards[1] = new CardClass(Model.Wraith, Element.Undead);
        personalCards[2] = new CardClass(Model.Enchanter, Element.Automaton);
    }

    public CardClass[] GetEnemyCards()
    {
        return enemyCards;
    }

    public CardClass[] GetPersonalCards()
    {
        return personalCards;
    }

    public void SetEnemyCard(int cardNumber, CardClass card)
    {
        enemyCards[cardNumber] = card;
    }

    public void SetPersonalCard(int cardNumber, CardClass card)
    {
        enemyCards[cardNumber] = card;
    }

    public void CheckIfCanEndTurn()
    {
        
    }
}
