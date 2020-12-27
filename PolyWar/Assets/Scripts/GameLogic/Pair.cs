using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;

namespace Pairs {
public class Pair
{
        public Element element;
        public Model model;
        public Pair(Model model, Element element)
        {
            this.model = model;
            this.element = element;
        }

        public Pair( Element element, Model model)
        {
            this.model = model;
            this.element = element;
        }
    }
}