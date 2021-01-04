using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pairs;

public class InstantiationScript : MonoBehaviour
{
    public GameObject ModelObj = new GameObject();


    // UnityEngine.Object EnchanterAnimator = Resources.Load("Assets/Models/EnchanterAnimator");

    public GameObject UndeadEnchanterModel = Resources.Load("Assets/Models/UndeadEnchanter") as GameObject;
    public GameObject AutomatonEnchanterModel = Resources.Load("Assets/Models/AutomatonEnchanter") as GameObject;
    public GameObject ChemicalEnchanterModel = Resources.Load("Assets/Models/ChemicalEnchanter") as GameObject;
    public GameObject ElementalEnchanterModel = Resources.Load("Assets/Models/ElementalEnchanter") as GameObject;

    public GameObject AutomatonSentryModel = Resources.Load("Assets/Models/AutomatonSentry") as GameObject;
    public GameObject ElementalSentryModel = Resources.Load("Assets/Models/ElementalSentry") as GameObject;
    public GameObject ChemicalSentryModel = Resources.Load("Assets/Models/ChemicalSentry") as GameObject;
    public GameObject UndeadSentryModel = Resources.Load("Assets/Models/UndeadSentry") as GameObject;

    public GameObject AutomatonJuggernautModel = Resources.Load("Assets/Models/AutomatonJuggernaut") as GameObject;
    public GameObject ElementalJuggernautModel = Resources.Load("Assets/Models/ElementalJuggernaut") as GameObject;
    public GameObject ChemicalJuggernautModel = Resources.Load("Assets/Models/ChemicalJuggernaut") as GameObject;
    public GameObject UndeadJuggernautModel = Resources.Load("Assets/Models/UndeadJuggernaut") as GameObject;

    public GameObject AutomatonWraithModel = Resources.Load("Assets/Models/AutomatonWraith") as GameObject;
    public GameObject ElementalWraithModel = Resources.Load("Assets/Models/ElementalWraith") as GameObject;
    public GameObject ChemicalWraithModel = Resources.Load("Assets/Models/ChemicalWraith") as GameObject;
    public GameObject UndeadWraithModel = Resources.Load("Assets/Models/UndeadWraith") as GameObject;

    public GameObject AutomatonLordMantisModel = Resources.Load("Assets/Models/AutomatonLordMantis") as GameObject;
    public GameObject ElementalLordMantisModel = Resources.Load("Assets/Models/ElementalLordMantis") as GameObject;
    public GameObject ChemicalLordMantisModel = Resources.Load("Assets/Models/ChemicalLordMantis") as GameObject;
    public GameObject UndeadLordMantisModel = Resources.Load("Assets/Models/UndeadLordMantis") as GameObject;

    public GameObject AutomatonBerserkModel = Resources.Load("Assets/Models/AutomatonBerserk") as GameObject;
    public GameObject ElementalBerserkModel = Resources.Load("Assets/Models/ElementalBerserk") as GameObject;
    public GameObject ChemicalBerserkModel = Resources.Load("Assets/Models/ChemicalBerserk") as GameObject;
    public GameObject UndeadBerserkModel = Resources.Load("Assets/Models/UndeadBerserk") as GameObject;

    //UnityEngine.Object AnimationPlayScript = Resources.Load("Assets/Scripts/AR/AnimationPlayScript");

    public Object MakeObj(Pair target) {
        if (target.element == Card.Element.Undead)
        {
            if (target.model == Card.Model.Sentry) {
                //GameObject.AddComponent(typeof(AnimationPlayScript)) as AnimationPlayScript;
                // asta still ar trebui facut : ModelObj.AddComponent<EnchanterAnimator>();
                ModelObj = Instantiate(UndeadSentryModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                ModelObj = Instantiate(UndeadEnchanterModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                ModelObj = Instantiate(UndeadJuggernautModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                ModelObj = Instantiate(UndeadWraithModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                ModelObj = Instantiate(UndeadLordMantisModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else // if (target.model == Card.Model.Berserk)
            {
                ModelObj = Instantiate(UndeadBerserkModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
        }
        else if (target.element == Card.Element.Automaton)
        {
            if (target.model == Card.Model.Sentry)
            {
                ModelObj = Instantiate(AutomatonSentryModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                ModelObj = Instantiate(AutomatonEnchanterModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                ModelObj = Instantiate(AutomatonJuggernautModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                ModelObj = Instantiate(AutomatonWraithModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                ModelObj = Instantiate(AutomatonLordMantisModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else // if (target.model == Card.Model.Berserk)
            {
                ModelObj = Instantiate(AutomatonBerserkModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
        }
        else if (target.element == Card.Element.Elemental)
        {
            if (target.model == Card.Model.Sentry)
            {
                ModelObj = Instantiate(ElementalSentryModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                ModelObj = Instantiate(ElementalEnchanterModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                ModelObj = Instantiate(ElementalJuggernautModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                ModelObj = Instantiate(ElementalWraithModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                ModelObj = Instantiate(ElementalLordMantisModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else // if (target.model == Card.Model.Berserk)
            {
                ModelObj = Instantiate(ElementalBerserkModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
        }
        else // if(target.element == Card.Element.Chemical)
        {
            if (target.model == Card.Model.Sentry)
            {
                ModelObj = Instantiate(ChemicalSentryModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                ModelObj = Instantiate(ChemicalEnchanterModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                ModelObj = Instantiate(ChemicalJuggernautModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                ModelObj = Instantiate(ChemicalWraithModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                ModelObj = Instantiate(ChemicalLordMantisModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
            else //if (target.model == Card.Model.Berserk)
            {
                ModelObj = Instantiate(ChemicalBerserkModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                ModelObj.AddComponent<AnimationPlayScript>();
                return ModelObj;
            }
        }
    }
}
