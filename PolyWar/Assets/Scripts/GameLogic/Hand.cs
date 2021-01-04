using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Pairs;

namespace Card
{
    public class Hand
    {
        Pair[] HandCards = {null,null,null,null,null};


        public int GetHandSize()
        {
            int counter=5;
            for (int index = 0; index < 5; index++)
            {
                if (HandCards[index] == null)
                {
                    counter--;
                }
            }
            return counter;
        }

        public void AddCard(int index,Deck PlayerDeck)
        {
            HandCards[index] = PlayerDeck.GetNextCard();
        }

        public Pair GetCard(int number)
        {
            Pair TheCard = HandCards[number];
            HandCards[number] = null;
            return TheCard;

        }

        public bool isEmptyPosition(int position)
        {
            if (HandCards[position] == null)
                return true;
            return false;
        }
        public void FillHand(Deck PlayerDeck)
        {
            for(int index = 0; index < 5; index++)
            {
                if(HandCards[index] == null)
                {
                    AddCard(index, PlayerDeck);
                }
            }
        }
    }
}