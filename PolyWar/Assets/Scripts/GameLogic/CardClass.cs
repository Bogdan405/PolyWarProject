using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
namespace Card {

    public enum Element : byte
    {
        Automaton = 0,
        Undead = 1,
        Chemical = 2,
        Elemental = 3
    }

    public enum Model : byte
    {
        Sentry = 0,
        Enchanter = 1,
        Juggernaut = 2, 
        Wraith = 3,
        LordMantis = 4,
        Berserk = 5
    }


    public class CardClass
    {

        public int life;
        public int damage;
        public string fullName;
        public Model model;
        public Element element;
        public Animator anim;
        public GameObject ARModel;
        public bool empty;

        public void Factory(Model model, Element element)
        {
            this.model = model;
            this.element = element;
            this.fullName = GetElement() + GetModel();
            this.empty = false;

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

        public CardClass(Model model, Element element)
        {
            Factory(model, element);
        }
        public CardClass()
        {
            empty = true;
        }

        public int SubstractLife(int damage)
        {
            this.life = this.life - damage;
            if(this.life < 0)
            {
                return -1 * this.life;
            }
            return 0;
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
            return this.element.ToString();
        }

        public string GetModel()
        {
            return this.model.ToString();
        }

        public Model MGetModel()
        {
            return this.model;
        }
        public Element EGetElement()
        {
            return this.element;
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

        public void SetEmpty()
        {
            empty = true;
        }

        public bool IsEmpty()
        {
            return empty;
        }

        public bool IsAlive()
        {
            return this.life > 0;
        }
    }
}