using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card { 

    public class CardClass : MonoBehaviour
    {

        public float life;
        public float damage;
        public string fullName;
        public Element element;
        public Animator anim;

        public CardClass()
        {

        }

        public void SubstractLife(float damage)
        {
            this.life = this.life - damage;
        }
        public float GetLife()
        {
            return this.life;
        }
        public float GetDamage()
        {
            return this.damage;
        }

        public string GetName()
        {
            return this.fullName;
        }

        public Element GetElement()
        {
            return this.element;
        }

        public void SetLife(float newLife)
        {
            this.life = newLife;
        }
        public void SetDamage(float newDamage)
        {
            this.damage = newDamage;
        }

        public void SetName(string newName)
        {
            this.fullName = newName;
        }

        public void SetElement(Element newElement)
        {
            this.element = newElement;
        }

        //De adaugat 3 functii
        //fara implementare cel mai probabil
        //cu fiecare animatie necesara




        public void fullSet(float newDamage, float newLife, string newName, Element newElement)
        {
            this.SetDamage(newDamage);
            this.SetLife(newLife);
            this.SetName(newName);
            this.SetElement(newElement);
        }



        void Start()
        {
            anim = GetComponent<Animator>();
            Debug.Log("Idle");
            anim.Play("Defend");
        }

        // Update is called once per frame
        void Update()
        {
          
            anim.Play("Defend");

        // TODO pentru celelalte 3 animatii avem nevoie de triggere specifice
        }
    }
}