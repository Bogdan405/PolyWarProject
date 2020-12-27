using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;


public class Battle : MonoBehaviour
{
    public void CommitBattle(CardClass cardDealing, CardClass cardReceiving)
    {
        int damageDealt = CalculateDamage(cardDealing.damage, cardDealing.element, cardReceiving.element);

        cardReceiving.SubstractLife(damageDealt);
    }

    public int CalculateDamage(int damage, Element elementDealing, Element elementReceiving)
    {
        if (elementDealing == elementReceiving)
            return damage;

        if (elementDealing == Element.Elemental && elementReceiving == Element.Undead)
            return (int) 1.5 * damage;

        if (elementDealing == Element.Elemental && elementReceiving == Element.Automaton)
            return (int) 1.0 * damage;

        if (elementDealing == Element.Elemental && elementReceiving == Element.Chemical)
            return (int) 0.5 * damage;


        if (elementDealing == Element.Undead && elementReceiving == Element.Automaton)
            return (int) 1.5 * damage;

        if (elementDealing == Element.Undead && elementReceiving == Element.Chemical)
            return (int) 1.0 * damage;

        if (elementDealing == Element.Undead && elementReceiving == Element.Elemental)
            return (int) 0.5 * damage;



        if (elementDealing == Element.Automaton && elementReceiving == Element.Chemical)
            return (int) 1.5 * damage;

        if (elementDealing == Element.Automaton && elementReceiving == Element.Elemental)
            return (int) 1.0 * damage;

        if (elementDealing == Element.Automaton && elementReceiving == Element.Undead)
            return (int) 0.5 * damage;

        

        if (elementDealing == Element.Chemical && elementReceiving == Element.Elemental)
            return (int) 1.5 * damage;

        if (elementDealing == Element.Chemical && elementReceiving == Element.Undead)
            return (int) 1.0 * damage;

        if (elementDealing == Element.Chemical && elementReceiving == Element.Automaton)
            return (int) 0.5 * damage;

        return 0;
    }
}
