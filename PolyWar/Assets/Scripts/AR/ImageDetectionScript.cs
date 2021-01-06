using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.XR.ARSubsystems;
using GameUserInterface;
using Card;
using Pairs;
public class ImageDetectionScript : MonoBehaviour
{
    private ARTrackedImageManager _arTrackedImageManager;
    private Dictionary<string, bool> fieldScanned;
    private Dictionary<string, bool> handScanned;
    private bool announced_field_scanned = false;
    public GameObject UI;
    public GameObject connection;
    public GameObject gameLogic;
    private string lastSelectedCard = null;
    private string lastSelectedField = null;
    private Dictionary<string,GameObject> handInstances;
    private Dictionary<string, GameObject> myFieldInstances;
    private Dictionary<string, GameObject> enemyFieldInstances;
    [SerializeField]
    private GameObject prefab;
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
    private enum FieldType
    {
        personalField,
        enemyField
    }
    public int GetSelectedCard()
    {
        if (string.Compare(lastSelectedCard,"Card1") == 0)
            return 0;
        if (string.Compare(lastSelectedCard, "Card2") == 0)
            return 1;
        if (string.Compare(lastSelectedCard, "Card3") == 0)
            return 2;
        if (string.Compare(lastSelectedCard, "Card4") == 0)
            return 3;
        if (string.Compare(lastSelectedCard, "Card5") == 0)
            return 4;
        return -1;
    }

    public int GetSelectedCard(string card)
    {
        if (string.Compare(card, "Card1") == 0)
            return 0;
        if (string.Compare(card, "Card2") == 0)
            return 1;
        if (string.Compare(card, "Card3") == 0)
            return 2;
        if (string.Compare(card, "Card4") == 0)
            return 3;
        if (string.Compare(card, "Card5") == 0)
            return 4;
        return -1;
    }

    public string GetSelectedCard(int pos)
    {
        if (pos == 0)
            return "Card1";
        if (pos == 1)
            return "Card2";
        if (pos == 2)
            return "Card3";
        if (pos == 3)
            return "Card4";
        if (pos == 4)
            return "Card5";
        return null;
    }

    private FieldType getFieldType(string fieldName)
    {
        if(string.Compare(lastSelectedField, "Owl") == 0 ||
            string.Compare(lastSelectedField, "Eagle") == 0 ||
            string.Compare(lastSelectedField, "Snake")==0)
        {
            return FieldType.personalField;
        }
        return FieldType.enemyField;
    }
    public int GetSelectedField()
    {
        if (string.Compare(lastSelectedField, "Owl") == 0 || string.Compare(lastSelectedField, "Elephant") == 0)
            return 0;
        if (string.Compare(lastSelectedField, "Eagle") == 0 || string.Compare(lastSelectedField, "Scorpion") == 0)
            return 1;
        if (string.Compare(lastSelectedField, "Snake") == 0 || string.Compare(lastSelectedField, "Boar") == 0)
            return 2;
        return -1;
    }
    public int GetSelectedField(string field)
    {
        if (string.Compare(field, "Owl") == 0 || string.Compare(field, "Elephant") == 0)
            return 0;
        if (string.Compare(field, "Eagle") == 0 || string.Compare(field, "Scorpion") == 0)
            return 1;
        if (string.Compare(field, "Snake") == 0 || string.Compare(field, "Boar") == 0)
            return 2;
        return -1;
    }

    public string GetSelectedEnemyField(int pos)
    {
        if (pos == 0)
            return "Elephant";
        if (pos == 1)
            return "Scorpion";
        if (pos == 2)
            return "Boar";
        return null;
    }

    public string GetSelectedPersonalField(int pos)
    {
        if (pos == 0)
            return "Owl";
        if (pos == 1)
            return "Eagle";
        if (pos == 2)
            return "Snake";
        return null;
    }

    public string GetSelectedFieldString()
    {
        return lastSelectedField;
    }
    private void Awake()
    {
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        fieldScanned = new Dictionary<string, bool>();
        handScanned = new Dictionary<string, bool>();
        fieldScanned.Add("Snake", false);
        fieldScanned.Add("Boar", false);
        fieldScanned.Add("Eagle", false);
        fieldScanned.Add("Owl", false);
        fieldScanned.Add("Elephant", false);
        fieldScanned.Add("Scorpion", false);
        handScanned.Add("Card1", false);
        handScanned.Add("Card2", false);
        handScanned.Add("Card3", false);
        handScanned.Add("Card4", false);
        handScanned.Add("Card5", false);
        handInstances = new Dictionary<string, GameObject>();
        myFieldInstances = new Dictionary<string, GameObject>();
        enemyFieldInstances = new Dictionary<string, GameObject>();
    }

    public void Start()
    {
        
    }
    public void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        if(announced_field_scanned == false)
        {
            foreach (ARTrackedImage trackedImage in args.added)
            {
                if (fieldScanned.ContainsKey(trackedImage.referenceImage.name))
                { 
                    SSTools.ShowMessage(trackedImage.referenceImage.name + " scanned", SSTools.Position.middle, SSTools.Time.oneSecond);
                    fieldScanned[trackedImage.referenceImage.name] = true;
                }
                
            }
            foreach (string el in fieldScanned.Keys)
            {
                if (fieldScanned[el] == false)
                {
                    SSTools.ShowMessage("Please scan " + el, SSTools.Position.bottom, SSTools.Time.oneSecond);
                    return;
                }
            }
            SSTools.ShowMessage("Field Scanned!", SSTools.Position.middle, SSTools.Time.threeSecond);
            announced_field_scanned = true;
            PhotonView UIPV = PhotonView.Get(connection);
            UIPV.RPC("updateReadyPlayers", RpcTarget.All);
            return;
        }
    }
    public void Update()
    {
        if (announced_field_scanned)
        {
            foreach (ARTrackedImage tracked in _arTrackedImageManager.trackables)
            {
                if (tracked.trackingState == TrackingState.Tracking)
                {
                    if (handScanned.ContainsKey(tracked.referenceImage.name))
                    {
                        UI.GetComponent<GameUI>().UpdateSelectedButton(tracked.referenceImage.name);
                        lastSelectedCard = tracked.referenceImage.name;
                        int pos = GetSelectedCard(tracked.referenceImage.name);
                        /*if (handInstances[pos] == null)
                        {
                            SSTools.ShowMessage("des", SSTools.Position.bottom, SSTools.Time.threeSecond);

                        }*/
                        if (handInstances.ContainsKey(tracked.referenceImage.name))
                        {
                            if (gameLogic.GetComponent<Board>().IsEmptyHand(pos))
                            {
                                //SSTools.ShowMessage("null", SSTools.Position.middle, SSTools.Time.threeSecond);
                                
                                Destroy(handInstances[tracked.referenceImage.name]);
                                handInstances.Remove(tracked.referenceImage.name);
                            }
                            else
                            {
                                
                                
                                handInstances[tracked.referenceImage.name].transform.position = tracked.transform.localPosition;
                                //handInstances[tracked.referenceImage.name].transform.Rotate(new Vector3(-90,0,0));
                                handInstances[tracked.referenceImage.name].SetActive(true);
                            }
                        
                        }
                        else
                        {
                            if (!gameLogic.GetComponent<Board>().IsEmptyHand(pos))
                            {


                                //handInstances[tracked.referenceImage.name] = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
                                handInstances[tracked.referenceImage.name] = MakeObj(gameLogic.GetComponent<Board>().getModelOfHand(pos));
                                
                                handInstances[tracked.referenceImage.name].transform.position = tracked.transform.localPosition;
                                
                                //handInstances[tracked.referenceImage.name].transform.Rotate(new Vector3(-90,0,0));
                                handInstances[tracked.referenceImage.name].SetActive(true);
                            }
                        }
                    }
                    if(fieldScanned.ContainsKey(tracked.referenceImage.name))
                    {
                        UI.GetComponent<GameUI>().UpdateSelectedField(tracked.referenceImage.name);
                        lastSelectedField = tracked.referenceImage.name;
                        int pos = GetSelectedField(tracked.referenceImage.name);
                        if (getFieldType(tracked.referenceImage.name) == FieldType.enemyField)
                        {
                            if (enemyFieldInstances.ContainsKey(tracked.referenceImage.name))
                            {
                                if (gameLogic.GetComponent<Board>().IsEmptyField(pos,true))
                                {
                                    Destroy(enemyFieldInstances[tracked.referenceImage.name]);
                                    enemyFieldInstances.Remove(tracked.referenceImage.name);
                                }
                                else
                                {
                                    
                                    enemyFieldInstances[tracked.referenceImage.name].transform.position = tracked.transform.localPosition;
                                    //enemyFieldInstances[tracked.referenceImage.name].transform.Rotate(new Vector3(-90, 0, 0));
                                    enemyFieldInstances[tracked.referenceImage.name].SetActive(true);
                                }
                            }
                            else
                            {
                                if (!gameLogic.GetComponent<Board>().IsEmptyField(pos,true))
                                {
                                    enemyFieldInstances[tracked.referenceImage.name] =  MakeObj(gameLogic.GetComponent<Board>().getModelOfField(pos,true));
                                    
                                    enemyFieldInstances[tracked.referenceImage.name].transform.position = tracked.transform.localPosition;
                                    //enemyFieldInstances[tracked.referenceImage.name].transform.Rotate(new Vector3(-90, 0, 0));
                                    enemyFieldInstances[tracked.referenceImage.name].SetActive(true);
                                }
                            }

                        }
                        else
                        {
                            if (myFieldInstances.ContainsKey(tracked.referenceImage.name))
                            {
                                if (gameLogic.GetComponent<Board>().IsEmptyField(pos, false))
                                {
                                    Destroy(myFieldInstances[tracked.referenceImage.name]);
                                    myFieldInstances.Remove(tracked.referenceImage.name);
                                }
                                else
                                {
                                   
                                    myFieldInstances[tracked.referenceImage.name].transform.position = tracked.transform.localPosition;
                                    //myFieldInstances[tracked.referenceImage.name].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                                    myFieldInstances[tracked.referenceImage.name].SetActive(true);
                                }
                            }
                            else
                            {
                                if (!gameLogic.GetComponent<Board>().IsEmptyField(pos, false))
                                {
                                    myFieldInstances[tracked.referenceImage.name] = MakeObj(gameLogic.GetComponent<Board>().getModelOfField(pos,false));
                                    
                                    myFieldInstances[tracked.referenceImage.name].transform.position = tracked.transform.localPosition;
                                    //myFieldInstances[tracked.referenceImage.name].transform.Rotate(new Vector3(-90, 0, 0));
                                    myFieldInstances[tracked.referenceImage.name].SetActive(true);
                                }
                            }
                        }
                    }
                    
                    
                  
                }
                /*
                else
                {
                    if (handInstances.ContainsKey(tracked.referenceImage.name))
                    {
                        handInstances[tracked.referenceImage.name].SetActive(false);
                    }
                    if (enemyFieldInstances.ContainsKey(tracked.referenceImage.name))
                    {
                        enemyFieldInstances[tracked.referenceImage.name].SetActive(false);
                    }
                    if (myFieldInstances.ContainsKey(tracked.referenceImage.name))
                    {
                        myFieldInstances[tracked.referenceImage.name].SetActive(false);
                    }
                }
                */
            }
        }
    }

    public bool isMyFieldIdle(int pos)
    {
        string name = GetSelectedPersonalField(pos);
        if (myFieldInstances.ContainsKey(name))
        {
            return myFieldInstances[name].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle");
        }
        return true;
    }

    public bool isEnemyFieldIdle(int pos)
    {
        string name = GetSelectedEnemyField(pos);
        if (enemyFieldInstances.ContainsKey(name))
        {
            return enemyFieldInstances[name].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle");
        }
        return true;
    }
    public void myFieldAttack(int pos)
    {
        string name = GetSelectedPersonalField(pos);
        if (myFieldInstances.ContainsKey(name))
        {
            myFieldInstances[name].GetComponent<AnimationPlayScript>().playAttack();
        }
    }
    public void enemyFieldAttack(int pos)
    {
        string name = GetSelectedEnemyField(pos);
        if (enemyFieldInstances.ContainsKey(name))
        {
            enemyFieldInstances[name].GetComponent<AnimationPlayScript>().playAttack();
        }
    }
    public void myFieldDefend(int pos)
    {
        string name = GetSelectedPersonalField(pos);
        if (myFieldInstances.ContainsKey(name))
        {
            myFieldInstances[name].GetComponent<AnimationPlayScript>().playDefense();
        }
    }
    public void enemyFieldDefend(int pos)
    {
        string name = GetSelectedEnemyField(pos);
        if (enemyFieldInstances.ContainsKey(name))
        {
            enemyFieldInstances[name].GetComponent<AnimationPlayScript>().playDefense();
        }
    }
    public void myFieldDeath(int pos)
    {
        string name = GetSelectedPersonalField(pos);
        if (myFieldInstances.ContainsKey(name))
        {
            myFieldInstances[name].GetComponent<AnimationPlayScript>().playDeath();
        }
    }
    public void enemyFieldDeath(int pos)
    {
        string name = GetSelectedEnemyField(pos);
        if (enemyFieldInstances.ContainsKey(name))
        {
            enemyFieldInstances[name].GetComponent<AnimationPlayScript>().playDeath();
        }
    }
    public void setReady()
    {
        announced_field_scanned = true;
    }

    public GameObject MakeObj(Pair target)
    {
        if (target.element == Card.Element.Undead)
        {
            if (target.model == Card.Model.Sentry)
            {
                GameObject ModelObj = Instantiate(UndeadSentryModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                GameObject ModelObj = Instantiate(UndeadEnchanterModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                GameObject ModelObj = Instantiate(UndeadJuggernautModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                GameObject ModelObj = Instantiate(UndeadWraithModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                GameObject ModelObj = Instantiate(UndeadLordMantisModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else // if (target.model == Card.Model.Berserk)
            {
                GameObject ModelObj = Instantiate(UndeadBerserkModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
        }
        else if (target.element == Card.Element.Automaton)
        {
            if (target.model == Card.Model.Sentry)
            {
                GameObject ModelObj = Instantiate(AutomatonSentryModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                GameObject ModelObj = Instantiate(AutomatonEnchanterModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                GameObject ModelObj = Instantiate(AutomatonJuggernautModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                GameObject ModelObj = Instantiate(AutomatonWraithModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                GameObject ModelObj = Instantiate(AutomatonLordMantisModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else // if (target.model == Card.Model.Berserk)
            {
                GameObject ModelObj = Instantiate(AutomatonBerserkModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
        }
        else if (target.element == Card.Element.Elemental)
        {
            if (target.model == Card.Model.Sentry)
            {
                GameObject ModelObj = Instantiate(ElementalSentryModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                GameObject ModelObj = Instantiate(ElementalEnchanterModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                GameObject ModelObj = Instantiate(ElementalJuggernautModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                GameObject ModelObj = Instantiate(ElementalWraithModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                GameObject ModelObj = Instantiate(ElementalLordMantisModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else // if (target.model == Card.Model.Berserk)
            {
                GameObject ModelObj = Instantiate(ElementalBerserkModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
        }
        else // if(target.element == Card.Element.Chemical)
        {
            if (target.model == Card.Model.Sentry)
            {
                GameObject ModelObj = Instantiate(ChemicalSentryModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Enchanter)
            {
                GameObject ModelObj = Instantiate(ChemicalEnchanterModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Juggernaut)
            {
                GameObject ModelObj = Instantiate(ChemicalJuggernautModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.Wraith)
            {
                GameObject ModelObj = Instantiate(ChemicalWraithModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else if (target.model == Card.Model.LordMantis)
            {
                GameObject ModelObj = Instantiate(ChemicalLordMantisModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
            else //if (target.model == Card.Model.Berserk)
            {
                GameObject ModelObj = Instantiate(ChemicalBerserkModel, new Vector3(0, 0, 0), Quaternion.identity);
                return ModelObj;
            }
        }
    }

    public void OnClickSetAllInactive()
    {
        foreach(string key in myFieldInstances.Keys)
        {
            myFieldInstances[key].SetActive(false);
        }
        foreach (string key in enemyFieldInstances.Keys)
        {
            enemyFieldInstances[key].SetActive(false);
        }
        foreach (string key in handInstances.Keys)
        {
            handInstances[key].SetActive(false);
        }
    }
}
