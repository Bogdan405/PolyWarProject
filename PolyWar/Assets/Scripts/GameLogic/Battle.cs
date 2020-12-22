using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;

public enum Element
{
    Automaton,
    Undead,
    Chemical,
    Elemental
}

public class Battle : MonoBehaviour
{
    public void CommitBattle(CardClass cardDealing, CardClass cardReceiving)
    {
        float damageDealt = CalculateDamage(cardDealing.damage, cardDealing.element, cardReceiving.element);

        cardReceiving.SubstractLife(damageDealt);

    }

    public float CalculateDamage(float damage, Element elementDealing, Element elementReceiving)
    {
        if (elementDealing == elementReceiving)
            return damage;

        if (elementDealing == Element.Elemental && elementReceiving == Element.Undead)
            return (float) 1.5 * damage;

        if (elementDealing == Element.Elemental && elementReceiving == Element.Automaton)
            return (float) 1.0 * damage;

        if (elementDealing == Element.Elemental && elementReceiving == Element.Chemical)
            return (float) 0.5 * damage;


        if (elementDealing == Element.Undead && elementReceiving == Element.Automaton)
            return (float) 1.5 * damage;

        if (elementDealing == Element.Undead && elementReceiving == Element.Chemical)
            return (float) 1.0 * damage;

        if (elementDealing == Element.Undead && elementReceiving == Element.Elemental)
            return (float) 0.5 * damage;



        if (elementDealing == Element.Automaton && elementReceiving == Element.Chemical)
            return (float) 1.5 * damage;

        if (elementDealing == Element.Automaton && elementReceiving == Element.Elemental)
            return (float) 1.0 * damage;

        if (elementDealing == Element.Automaton && elementReceiving == Element.Undead)
            return (float) 0.5 * damage;

        

        if (elementDealing == Element.Chemical && elementReceiving == Element.Elemental)
            return (float) 1.5 * damage;

        if (elementDealing == Element.Chemical && elementReceiving == Element.Undead)
            return (float) 1.0 * damage;

        if (elementDealing == Element.Chemical && elementReceiving == Element.Automaton)
            return (float) 0.5 * damage;

        return (float) 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
