using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pairs;

public class InstantiationScript : MonoBehaviour
{
    GameObject ModelObj;

    [SerializeField]
    private GameObject UndeadEnchanterMod;
    public GameObject UndeadEnchanterModel = Resources.Load("Assets/Models/PrefabsModels/UndeadEnchanter") as GameObject;
    public GameObject AutomatonEnchanterModel = Resources.Load("Assets/Models/PrefabsModels/AutomatonEnchanter") as GameObject;
    public GameObject ChemicalEnchanterModel = Resources.Load("Assets/Models/PrefabsModels/ChemicalEnchanter") as GameObject;
    public GameObject ElementalEnchanterModel = Resources.Load("Assets/Models/PrefabsModels/ElementalEnchanter") as GameObject;

    public GameObject AutomatonSentryModel = Resources.Load("Assets/Models/PrefabsModels/AutomatonSentry") as GameObject;
    public GameObject ElementalSentryModel = Resources.Load("Assets/Models/PrefabsModels/ElementalSentry") as GameObject;
    public GameObject ChemicalSentryModel = Resources.Load("Assets/Models/PrefabsModels/ChemicalSentry") as GameObject;
    public GameObject UndeadSentryModel = Resources.Load("Assets/Models/PrefabsModels/UndeadSentry") as GameObject;

    public GameObject AutomatonJuggernautModel = Resources.Load("Assets/Models/PrefabsModels/AutomatonJuggernaut") as GameObject;
    public GameObject ElementalJuggernautModel = Resources.Load("Assets/Models/PrefabsModels/ElementalJuggernaut") as GameObject;
    public GameObject ChemicalJuggernautModel = Resources.Load("Assets/Models/PrefabsModels/ChemicalJuggernaut") as GameObject;
    public GameObject UndeadJuggernautModel = Resources.Load("Assets/Models/PrefabsModels/UndeadJuggernaut") as GameObject;

    public GameObject AutomatonWraithModel = Resources.Load("Assets/Models/PrefabsModels/AutomatonWraith") as GameObject;
    public GameObject ElementalWraithModel = Resources.Load("Assets/Models/PrefabsModels/ElementalWraith") as GameObject;
    public GameObject ChemicalWraithModel = Resources.Load("Assets/Models/PrefabsModels/ChemicalWraith") as GameObject;
    public GameObject UndeadWraithModel = Resources.Load("Assets/Models/PrefabsModels/UndeadWraith") as GameObject;

    public GameObject AutomatonLordMantisModel = Resources.Load("Assets/Models/PrefabsModels/AutomatonLordMantis") as GameObject;
    public GameObject ElementalLordMantisModel = Resources.Load("Assets/Models/PrefabsModels/ElementalLordMantis") as GameObject;
    public GameObject ChemicalLordMantisModel = Resources.Load("Assets/Models/PrefabsModels/ChemicalLordMantis") as GameObject;
    public GameObject UndeadLordMantisModel = Resources.Load("Assets/Models/PrefabsModels/UndeadLordMantis") as GameObject;

    public GameObject AutomatonBerserkModel = Resources.Load("Assets/Models/PrefabsModels/AutomatonBerserk") as GameObject;
    public GameObject ElementalBerserkModel = Resources.Load("Assets/Models/PrefabsModels/ElementalBerserk") as GameObject;
    public GameObject ChemicalBerserkModel = Resources.Load("Assets/Models/PrefabsModels/ChemicalBerserk") as GameObject;
    public GameObject UndeadBerserkModel = Resources.Load("Assets/Models/PrefabsModels/UndeadBerserk") as GameObject;

    //UnityEngine.Object AnimationPlayScript = Resources.Load("Assets/Scripts/AR/AnimationPlayScript");

    public GameObject MakeObj(Pair target) {
        if (target.element == Card.Element.Undead)
        {
            if (target.model == Card.Model.Sentry) {
                ModelObj = Instantiate(UndeadSentryModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                ModelObj = Instantiate(UndeadEnchanterModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                ModelObj = Instantiate(UndeadJuggernautModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                ModelObj = Instantiate(UndeadWraithModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                ModelObj = Instantiate(UndeadLordMantisModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else // if (target.model == Card.Model.Berserk)
            {
                ModelObj = Instantiate(UndeadBerserkModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
        }
        else if (target.element == Card.Element.Automaton)
        {
            if (target.model == Card.Model.Sentry)
            {
                ModelObj = Instantiate(AutomatonSentryModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                ModelObj = Instantiate(AutomatonEnchanterModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                ModelObj = Instantiate(AutomatonJuggernautModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                ModelObj = Instantiate(AutomatonWraithModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                ModelObj = Instantiate(AutomatonLordMantisModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else // if (target.model == Card.Model.Berserk)
            {
                ModelObj = Instantiate(AutomatonBerserkModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
        }
        else if (target.element == Card.Element.Elemental)
        {
            if (target.model == Card.Model.Sentry)
            {
                ModelObj = Instantiate(ElementalSentryModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                ModelObj = Instantiate(ElementalEnchanterModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                ModelObj = Instantiate(ElementalJuggernautModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                ModelObj = Instantiate(ElementalWraithModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                ModelObj = Instantiate(ElementalLordMantisModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else // if (target.model == Card.Model.Berserk)
            {
                ModelObj = Instantiate(ElementalBerserkModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
        }
        else // if(target.element == Card.Element.Chemical)
        {
            if (target.model == Card.Model.Sentry)
            {
                ModelObj = Instantiate(ChemicalSentryModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                ModelObj = Instantiate(ChemicalEnchanterModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                ModelObj = Instantiate(ChemicalJuggernautModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                ModelObj = Instantiate(ChemicalWraithModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                ModelObj = Instantiate(ChemicalLordMantisModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
            else //if (target.model == Card.Model.Berserk)
            {
                ModelObj = Instantiate(ChemicalBerserkModel, new Vector3(-9999, -9999, -9999), Quaternion.identity);
                return ModelObj;
            }
        }
    }
}
