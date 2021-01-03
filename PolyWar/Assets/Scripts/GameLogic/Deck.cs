using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;
using System;
using Pairs;

public class Deck
{
    List<Pair> cards = new List<Pair>();

    public void GenerateDeck()
    {
        AddGenerals();
        AddMinions();

        System.Random rng = new System.Random();

        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Pair value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }

    }
    /*
    public Pair GetNextCard()
    {
        Pair TheCard = this.cards.ElementAt(0);
        this.cards.RemoveAt(0);
        return TheCard;
    }*/

    public Pair GenerateOneMinion()
    {
        System.Random rnd = new System.Random();
        int potato = rnd.Next(1, 17);
        Pair potatoCard;

        if (potato == 1) { potatoCard = new Pair(Model.Sentry, Element.Automaton); }
        else if (potato == 2) { potatoCard = new Pair(Model.Sentry, Element.Elemental); }
        else if (potato == 3) { potatoCard = new Pair(Model.Sentry, Element.Chemical); }
        else if (potato == 4) { potatoCard = new Pair(Model.Sentry, Element.Undead); }
        else if (potato == 5) { potatoCard = new Pair(Model.Enchanter, Element.Automaton); }
        else if (potato == 6) { potatoCard = new Pair(Model.Enchanter, Element.Elemental); }
        else if (potato == 7) { potatoCard = new Pair(Model.Enchanter, Element.Chemical); }
        else if (potato == 8) { potatoCard = new Pair(Model.Enchanter, Element.Undead); }
        else if (potato == 9) { potatoCard = new Pair(Model.Juggernaut, Element.Automaton); }
        else if (potato == 10) { potatoCard = new Pair(Model.Juggernaut, Element.Elemental); }
        else if (potato == 11) { potatoCard = new Pair(Model.Juggernaut, Element.Chemical); }
        else if (potato == 12) { potatoCard = new Pair(Model.Juggernaut, Element.Undead); }
        else if (potato == 13) { potatoCard = new Pair(Model.Wraith, Element.Automaton); }
        else if (potato == 14) { potatoCard = new Pair(Model.Wraith, Element.Elemental); }
        else if (potato == 15) { potatoCard = new Pair(Model.Wraith, Element.Chemical); }
        else { potatoCard = new Pair(Model.Wraith, Element.Undead); }

        return potatoCard;
    }

    public Pair GenerateOneGeneral()
    {
        System.Random rnd = new System.Random();
        Pair general1;
        int general = rnd.Next(1, 9);

        if (general == 1) { general1 = new Pair(Model.LordMantis, Element.Automaton); }
        else if (general == 2) { general1 = new Pair(Model.LordMantis, Element.Elemental); }
        else if (general == 3) { general1 = new Pair(Model.LordMantis, Element.Chemical); }
        else if (general == 4) { general1 = new Pair(Model.LordMantis, Element.Undead); }
        else if (general == 5) { general1 = new Pair(Model.Berserk, Element.Automaton); }
        else if (general == 6) { general1 = new Pair(Model.Berserk, Element.Elemental); }
        else if (general == 7) { general1 = new Pair(Model.Berserk, Element.Chemical); }
        else { general1 = new Pair(Model.Berserk, Element.Undead); }

        return general1;
    }

    public void AddGenerals(){
        System.Random rnd = new System.Random();
        Pair general1;
        int general  = rnd.Next(1, 9);
        
        if(general == 1){general1 = new Pair(Model.LordMantis, Element.Automaton);}
        else if(general == 2){general1 = new Pair(Model.LordMantis, Element.Elemental);}
        else if(general == 3){general1 = new Pair   (Model.LordMantis, Element.Chemical);}
        else if(general == 4){general1 = new Pair(Model.LordMantis, Element.Undead);}
        else if(general == 5){general1 = new Pair(Model.Berserk, Element.Automaton);}
        else if(general == 6){general1 = new Pair(Model.Berserk, Element.Elemental);}
        else if(general == 7){general1 = new Pair(Model.Berserk, Element.Chemical);}
        else {general1 = new Pair(Model.Berserk, Element.Undead);}
        
        cards.Add(general1);
        
        general  = rnd.Next(1, 9);
        Pair general2;

        if (general == 1){general2 = new Pair(Model.LordMantis, Element.Automaton);}
        else if(general == 2){general2 = new Pair(Model.LordMantis, Element.Elemental);}
        else if(general == 3){general2 = new Pair(Model.LordMantis, Element.Chemical);}
        else if(general == 4){general2 = new Pair(Model.LordMantis, Element.Undead);}
        else if(general == 5){general2 = new Pair(Model.Berserk, Element.Automaton);}
        else if(general == 6){general2 = new Pair(Model.Berserk, Element.Elemental);}
        else if(general == 7){general2 = new Pair(Model.Berserk, Element.Chemical);}
        else{general2 = new Pair(Model.Berserk, Element.Undead);}

        
        cards.Add(general2);
    }

    public void AddMinions(){

        System.Random rnd = new System.Random();


        for (int i = 0; i < 18; i++)
        {
            int potato = rnd.Next(1, 17);
            Pair potatoCard;

            if (potato == 1) { potatoCard = new Pair(Model.Sentry, Element.Automaton); }
            else if (potato == 2) { potatoCard = new Pair(Model.Sentry, Element.Elemental); }
            else if (potato == 3) { potatoCard = new Pair(Model.Sentry, Element.Chemical); }
            else if (potato == 4) { potatoCard = new Pair(Model.Sentry, Element.Undead); }
            else if (potato == 5) { potatoCard = new Pair(Model.Enchanter, Element.Automaton); }
            else if (potato == 6) { potatoCard = new Pair(Model.Enchanter, Element.Elemental); }
            else if (potato == 7) { potatoCard = new Pair(Model.Enchanter, Element.Chemical); }
            else if (potato == 8) { potatoCard = new Pair(Model.Enchanter, Element.Undead); }
            else if (potato == 9) { potatoCard = new Pair(Model.Juggernaut, Element.Automaton); }
            else if (potato == 10) { potatoCard = new Pair(Model.Juggernaut, Element.Elemental); }
            else if (potato == 11) { potatoCard = new Pair(Model.Juggernaut, Element.Chemical); }
            else if (potato == 12) { potatoCard = new Pair(Model.Juggernaut, Element.Undead); }
            else if (potato == 13) { potatoCard = new Pair(Model.Wraith, Element.Automaton); }
            else if (potato == 14) { potatoCard = new Pair(Model.Wraith, Element.Elemental); }
            else if (potato == 15) { potatoCard = new Pair(Model.Wraith, Element.Chemical); }
            else { potatoCard = new Pair(Model.Wraith, Element.Undead); }
            
            cards.Add(potatoCard);
        }
    }
 

}
