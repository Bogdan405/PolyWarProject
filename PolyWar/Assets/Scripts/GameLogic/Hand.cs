using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Pairs;

namespace Card
{
    public class Hand
    {
        List<Pair> HandCards = new List<Pair>();


        public int GetHandSize()
        {
            return this.HandCards.Count;
        }

        public void AddCard(Deck PlayerDeck)
        {
            HandCards.Add(PlayerDeck.GetNextCard());
        }

        public Pair GetCard(int number)
        {
            Pair TheCard = this.HandCards.ElementAt(number);
            this.HandCards.RemoveAt(number);
            return TheCard;

        }

        public void FillHand(Deck PlayerDeck)
        {
            while (this.GetHandSize() < 5)
            {
                this.AddCard(PlayerDeck);
            }
        }
    }
}