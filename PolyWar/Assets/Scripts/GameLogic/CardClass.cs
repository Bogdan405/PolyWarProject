using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card {

    public enum Element
    {
        Automaton,
        Undead,
        Chemical,
        Elemental
    }

    public enum Model
    {
        Sentry,
        Enchanter,
        Juggernaut,
        Wraith,
        LordMantis,
        Berserk
    }


    public class CardClass : MonoBehaviour
    {

        public int life;
        public int damage;
        public string fullName;
        public Model model;
        public Element element;
        public Animator anim;

        public void Factory(Model model, Element element)
        {
            this.model = model;
            this.element = element;
            this.fullName = GetElement() + GetModel();


            if (model == Model.Sentry)
            {
                this.life = 200;
                this.damage = 75;
            }
            else if (model == Model.Enchanter)
            {
                this.life = 125;
                this.damage = 75;
            }
            else if (model == Model.Juggernaut)
            {
                this.life = 350;
                this.damage = 100;
            }
            else if (model == Model.Wraith)
            {
                this.life = 150;
                this.damage = 100;
            }
            else if (model == Model.LordMantis)
            {
                this.life = 300;
                this.damage = 200;
            }
            else // if (model == Model.Berserk)
            {
                this.life = 200;
                this.damage = 250;
            }   
        }

        public void SubstractLife(int damage)
        {
            this.life = this.life - damage;
        }
        public int GetLife()
        {
            return this.life;
        }
        public int GetDamage()
        {
            return this.damage;
        }

        public string GetName()
        {
            return this.fullName;
        }

        public string GetElement()
        {
            return nameof(this.element);
        }

        public string GetModel()
        {
            return nameof(this.model);
        }

        public void SetLife(int newLife)
        {
            this.life = newLife;
        }
        public void SetDamage(int newDamage)
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

        public void AttackAnimation(){
            anim.Play("Attack");
        }

        public void DefendAnimation(){
            anim.Play("Defend");
        }

        public void DeathAnimation(){
            anim.Play("Death");
        }

        public void IdleAnimation(){
            anim.Play("Idle");
        }
 
        void CardClass(Model model, Element element)
        {
            Factory(this.model, this.element);
            anim = GetComponent<Animator>();
        }


        
    }
}