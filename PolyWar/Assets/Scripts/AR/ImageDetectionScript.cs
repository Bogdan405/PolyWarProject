using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.XR.ARSubsystems;
using GameUserInterface;
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
    GameObject[] handInstances = { null,null,null, null, null };
    GameObject[] myFieldInstances = { null,null,null};
    GameObject[] enemyFieldInstances = { null,null,null};

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
                        if (handInstances[pos] == null)
                        {
                            SSTools.ShowMessage("des", SSTools.Position.bottom, SSTools.Time.threeSecond);

                        }
                        if (handInstances[pos] != null)
                        {
                            if (gameLogic.GetComponent<Board>().IsEmptyHand(pos))
                            {
                                SSTools.ShowMessage("null", SSTools.Position.middle, SSTools.Time.threeSecond);
                                Destroy(handInstances[pos]);
                                handInstances[pos] = null;
                            }
                            else
                            {
                                
                                handInstances[pos].SetActive(true);
                                handInstances[pos].transform.position = tracked.transform.localPosition;
                                handInstances[pos].SetActive(true);
                            }
                        
                        }
                        else
                        {
                            if (!gameLogic.GetComponent<Board>().IsEmptyHand(pos))
                            {
                                
                                handInstances.SetValue(gameLogic.GetComponent<Board>().getModelOfHand(pos),pos);
                                handInstances[pos].SetActive(true);
                                handInstances[pos].transform.position = tracked.transform.localPosition;
                                handInstances[pos].SetActive(true);
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
                            if (enemyFieldInstances[pos] != null)
                            {
                                if (gameLogic.GetComponent<Board>().IsEmptyField(pos,true))
                                {
                                    Destroy(enemyFieldInstances[pos]);
                                    enemyFieldInstances[pos] = null;
                                }
                                else
                                {
                                    enemyFieldInstances[pos].SetActive(true);
                                    enemyFieldInstances[pos].transform.position = tracked.transform.localPosition;
                                    enemyFieldInstances[pos].SetActive(true);
                                }
                            }
                            else
                            {
                                if (!gameLogic.GetComponent<Board>().IsEmptyField(pos,true))
                                {
                                    enemyFieldInstances[pos] = gameLogic.GetComponent<Board>().getModelOfField(pos,true);
                                    enemyFieldInstances[pos].SetActive(true);
                                    enemyFieldInstances[pos].transform.position = tracked.transform.localPosition;
                                    enemyFieldInstances[pos].SetActive(true);
                                }
                            }

                        }
                        else
                        {
                            if (myFieldInstances[pos] != null)
                            {
                                if (gameLogic.GetComponent<Board>().IsEmptyField(pos, false))
                                {
                                    Destroy(myFieldInstances[pos]);
                                    myFieldInstances[pos] = null;
                                }
                                else
                                {
                                    myFieldInstances[pos].SetActive(true);
                                    myFieldInstances[pos].transform.position = tracked.transform.localPosition;
                                    myFieldInstances[pos].SetActive(true);
                                }
                            }
                            else
                            {
                                if (!gameLogic.GetComponent<Board>().IsEmptyField(pos, false))
                                {
                                    myFieldInstances[pos] = gameLogic.GetComponent<Board>().getModelOfField(pos,false);
                                    myFieldInstances[pos].SetActive(true);
                                    myFieldInstances[pos].transform.position = tracked.transform.localPosition;
                                    myFieldInstances[pos].SetActive(true);
                                }
                            }
                        }
                    }
                    
                    
                    //inst_placeable.transform.position = tracked.transform.localPosition;
                    //inst_placeable.SetActive(true);
                    //inst_placeable.transform.localPosition = new Vector3(0, 0, 0);
                    //SSTools.ShowMessage(tracked.transform.localScale.ToString(),SSTools.Position.middle,SSTools.Time.threeSecond);
                    //SSTools.ShowMessage(tracked.transform.position.ToString(),SSTools.Position.bottom,SSTools.Time.threeSecond);
                    //SSTools.ShowMessage(tracked.transform.rotation.ToString(),SSTools.Position.top,SSTools.Time.threeSecond);

                }
                /*
                else
                {
                    if (handScanned.ContainsKey(tracked.referenceImage.name))
                    {
                        int pos = GetSelectedCard(tracked.referenceImage.name);
                        if (handInstances[pos] != null)
                        {
                            handInstances[pos].SetActive(false);
                        }
                    }
                    if (fieldScanned.ContainsKey(tracked.referenceImage.name))
                    {
                        int pos = GetSelectedField(tracked.referenceImage.name);
                        if (getFieldType(tracked.referenceImage.name) == FieldType.enemyField)
                        {
                            if (enemyFieldInstances[pos] != null)
                            {
                                enemyFieldInstances[pos].SetActive(false);
                            }
                        }
                        else
                        {
                            if (myFieldInstances[pos] != null)
                            {
                                myFieldInstances[pos].SetActive(false);
                            }
                        }
                    }
                }
                */
            }
        }
    }

    public void setReady()
    {
        announced_field_scanned = true;
    }
}
