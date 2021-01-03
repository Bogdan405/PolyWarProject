using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.XR.ARSubsystems;
public class ImageDetectionScript : MonoBehaviour
{
    private ARTrackedImageManager _arTrackedImageManager;
    private Dictionary<string, bool> fieldScanned;
    private bool announced_field_scanned = false;
    public XRReferenceImageLibrary fieldLibrary;
    public XRReferenceImageLibrary handLibrary;
    public GameObject UI;
    public GameObject connection;
    public GameObject gameLogic;
    private bool lookingAtHand = false;

    private void Awake()
    {
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void Start()
    {
        fieldScanned = new Dictionary<string, bool>();
        fieldScanned.Add("Snake", false);
        fieldScanned.Add("Boar", false);
        fieldScanned.Add("Eagle", false);
        fieldScanned.Add("Owl", false);
        fieldScanned.Add("Elephant", false);
        fieldScanned.Add("Scorpion", false);
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
            foreach (var trackedImage in args.added)
            {
                SSTools.ShowMessage(trackedImage.referenceImage.name + " scanned", SSTools.Position.middle, SSTools.Time.oneSecond);
                fieldScanned[trackedImage.referenceImage.name] = true;
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
        }
        
        
    }

    public void SetHandLook()
    {
        lookingAtHand = true;
        _arTrackedImageManager.referenceLibrary = handLibrary;
    }

    public void SetFieldLook()
    {
        lookingAtHand = false;
    }
}
