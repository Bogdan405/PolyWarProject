using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClass : MonoBehaviour
{

    public int life;
    public int damage;
    public string fullName;
    public short element;


    public int getLife()
    {
        return this.life;
    }
    public int getDamage()
    {
        return this.damage;
    }

    public string getName()
    {
        return this.fullName;
    }

    public short getElement()
    {
        return this.element;
    }

    public void setLife(int newLife)
    {
        this.life = newLife;
    }
    public void setDamage(int newDamage)
    {
        this.damage = newDamage;
    }

    public void setName(string newName)
    {
        this.fullName = newName;
    }

    public void setElement(short newElement)
    {
        this.element = newElement;
    }

    //De adaugat 3 functii
    //fara implementare cel mai probabil
    //cu fiecare animatie necesara

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
