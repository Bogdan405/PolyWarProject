using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Card;

public class BattlefieldCardUI : MonoBehaviour
{
    public void initCard(CardClass card)
    {
        if( card != null)
        {
            GameObject element = this.transform.GetChild(0).gameObject;
            GameObject type = this.transform.GetChild(1).gameObject;
            GameObject attack = this.transform.GetChild(2).gameObject;
            GameObject life = this.transform.GetChild(3).gameObject;
            element.GetComponent<Text>().text = card.GetElement();
            type.GetComponent<Text>().text = card.GetModel();
            attack.GetComponent<Text>().text = card.GetDamage().ToString();
            life.GetComponent<Text>().text = card.GetLife().ToString();
        }
    }
}
