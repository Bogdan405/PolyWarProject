using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pairs;

public class InstantiationScript : MonoBehaviour
{
      
    [SerializeField]
    private GameObject UndeadEnchanterModel;
    [SerializeField]
    private GameObject AutomatonEnchanterModel;
    [SerializeField]
    private GameObject ChemicalEnchanterModel;
    [SerializeField]
    private GameObject ElementalEnchanterModel;

    [SerializeField]
    private GameObject AutomatonSentryModel;
    [SerializeField]
    private GameObject ElementalSentryModel;
    [SerializeField]
    private GameObject ChemicalSentryModel;
    [SerializeField]
    private GameObject UndeadSentryModel;

    [SerializeField]
    private GameObject AutomatonJuggernautModel;
    [SerializeField]
    private GameObject ElementalJuggernautModel;
    [SerializeField]
    private GameObject ChemicalJuggernautModel;
    [SerializeField]
    private GameObject UndeadJuggernautModel;

    [SerializeField]
    private GameObject AutomatonWraithModel;
    [SerializeField]
    private GameObject ElementalWraithModel;
    [SerializeField]
    private GameObject ChemicalWraithModel;
    [SerializeField]
    private GameObject UndeadWraithModel;

    [SerializeField]
    private GameObject AutomatonLordMantisModel;
    [SerializeField]
    private GameObject ElementalLordMantisModel;
    [SerializeField]
    private GameObject ChemicalLordMantisModel;
    [SerializeField]
    private GameObject UndeadLordMantisModel;

    [SerializeField]
    private GameObject AutomatonBerserkModel;
    [SerializeField]
    private GameObject ElementalBerserkModel;
    [SerializeField]
    private GameObject ChemicalBerserkModel;
    [SerializeField]
    private GameObject UndeadBerserkModel;

    //UnityEngine.Object AnimationPlayScript = Resources.Load("Assets/Scripts/AR/AnimationPlayScript");

    public GameObject MakeObj(Pair target) {
        if (target.element == Card.Element.Undead)
        {
            if (target.model == Card.Model.Sentry) {
                GameObject ModelObj = Instantiate(UndeadSentryModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                GameObject ModelObj = Instantiate(UndeadEnchanterModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                GameObject ModelObj = Instantiate(UndeadJuggernautModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                GameObject ModelObj = Instantiate(UndeadWraithModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                GameObject ModelObj = Instantiate(UndeadLordMantisModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else // if (target.model == Card.Model.Berserk)
            {
                GameObject ModelObj = Instantiate(UndeadBerserkModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
        }
        else if (target.element == Card.Element.Automaton)
        {
            if (target.model == Card.Model.Sentry)
            {
                GameObject ModelObj = Instantiate(AutomatonSentryModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                GameObject ModelObj = Instantiate(AutomatonEnchanterModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                GameObject ModelObj = Instantiate(AutomatonJuggernautModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                GameObject ModelObj = Instantiate(AutomatonWraithModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                GameObject ModelObj = Instantiate(AutomatonLordMantisModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else // if (target.model == Card.Model.Berserk)
            {
                GameObject ModelObj = Instantiate(AutomatonBerserkModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
        }
        else if (target.element == Card.Element.Elemental)
        {
            if (target.model == Card.Model.Sentry)
            {
                GameObject ModelObj = Instantiate(ElementalSentryModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                GameObject ModelObj = Instantiate(ElementalEnchanterModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                GameObject ModelObj = Instantiate(ElementalJuggernautModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                GameObject ModelObj = Instantiate(ElementalWraithModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                GameObject ModelObj = Instantiate(ElementalLordMantisModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else // if (target.model == Card.Model.Berserk)
            {
                GameObject ModelObj = Instantiate(ElementalBerserkModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
        }
        else // if(target.element == Card.Element.Chemical)
        {
            if (target.model == Card.Model.Sentry)
            {
                GameObject ModelObj = Instantiate(ChemicalSentryModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                GameObject ModelObj = Instantiate(ChemicalEnchanterModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                GameObject ModelObj = Instantiate(ChemicalJuggernautModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                GameObject ModelObj = Instantiate(ChemicalWraithModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                GameObject ModelObj = Instantiate(ChemicalLordMantisModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else //if (target.model == Card.Model.Berserk)
            {
                GameObject ModelObj = Instantiate(ChemicalBerserkModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
        }
    }
}
