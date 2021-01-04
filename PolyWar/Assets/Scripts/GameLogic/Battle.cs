using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;

namespace Card { 
    public class Battle
    {
        public static int[] CommitBattle(CardClass firstCard, CardClass secondCard)
        {
            int[] life_reductions = { 0, 0 };
            if (!secondCard.IsEmpty())
            {
                life_reductions[1] = secondCard.SubstractLife(CalculateDamage(firstCard.damage, firstCard.element, secondCard.element));
            }
            else
            {
                life_reductions[1] = firstCard.damage;
            }
            if (!firstCard.IsEmpty())
            {
                life_reductions[0] = firstCard.SubstractLife(CalculateDamage(secondCard.damage, secondCard.element, firstCard.element));
            }
            else
            {
                life_reductions[0] = secondCard.damage;
            }
            return life_reductions;
        }

        public static int CalculateDamage(int damage, Element elementDealing, Element elementReceiving)
        {
            if (elementDealing == elementReceiving)
                return damage;

            if (elementDealing == Element.Elemental && elementReceiving == Element.Undead)
                return (int) (1.5 * damage);

            if (elementDealing == Element.Elemental && elementReceiving == Element.Automaton)
                return (int) (1.0 * damage);

            if (elementDealing == Element.Elemental && elementReceiving == Element.Chemical)
                return (int) (0.5 * damage);


            if (elementDealing == Element.Undead && elementReceiving == Element.Automaton)
                return (int) (1.5 * damage);

            if (elementDealing == Element.Undead && elementReceiving == Element.Chemical)
                return (int) (1.0 * damage);

            if (elementDealing == Element.Undead && elementReceiving == Element.Elemental)
                return (int) (0.5 * damage);



            if (elementDealing == Element.Automaton && elementReceiving == Element.Chemical)
                return (int) (1.5 * damage);

            if (elementDealing == Element.Automaton && elementReceiving == Element.Elemental)
                return (int)(1.0 * damage);

            if (elementDealing == Element.Automaton && elementReceiving == Element.Undead)
                return (int)(0.5 * damage);

        

            if (elementDealing == Element.Chemical && elementReceiving == Element.Elemental)
                return (int)(1.5 * damage);

            if (elementDealing == Element.Chemical && elementReceiving == Element.Undead)
                return (int)(1.0 * damage);

            if (elementDealing == Element.Chemical && elementReceiving == Element.Automaton)
                return (int)(0.5 * damage);

            return 0;
        }
    }
}