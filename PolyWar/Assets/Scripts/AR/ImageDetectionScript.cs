using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using Photon.Realtime;
using Photon.Pun;

public class ImageDetectionScript : MonoBehaviour
{
    private ARTrackedImageManager _arTrackedImageManager;
    private Dictionary<string, bool> fieldScanned;
    private bool announced_field_scanned = false;
    public GameObject UI;
    public GameObject connection;

    private void Awake()
    {
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void Start()
    {
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
        foreach (var trackedImage in args.added)
        {
            fieldScanned[trackedImage.referenceImage.name] = true;
        }
        foreach(KeyValuePair<string,bool> el in fieldScanned)
        {
            if (el.Value == false)
            {
                return;
            }
        }
        if (announced_field_scanned == false)
        {   
            announced_field_scanned = true;
            PhotonView UIPV = PhotonView.Get(connection);
            UIPV.RPC("updateReadyPlayers", RpcTarget.All);
        }
        
    }

}
