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

    public int GetSelectedField()
    {
        if (string.Compare(lastSelectedCard, "Owl") == 0 || string.Compare(lastSelectedCard, "Elephant") == 0)
            return 0;
        if (string.Compare(lastSelectedCard, "Eagle") == 0 || string.Compare(lastSelectedCard, "Scorpion") == 0)
            return 1;
        if (string.Compare(lastSelectedCard, "Snake") == 0 || string.Compare(lastSelectedCard, "Boar") == 0)
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
    }

    public void Start()
    {
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
                    UI.GetComponent<GameUI>().UpdateSelectedButton(tracked.referenceImage.name);
                    Vector3 test = tracked.transform.position;
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.localScale = new Vector3(5, 5, 5);
                    _arTrackedImageManager.trackedImagePrefab = cube;
                    SSTools.ShowMessage(test.ToString(), SSTools.Position.middle, SSTools.Time.oneSecond);
                }
            }
        }

    }

    public void setReady()
    {
        announced_field_scanned = true;
    }
}
