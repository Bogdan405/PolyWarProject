using Photon.Realtime;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ConnectToMasterPun : MonoBehaviourPunCallbacks
{
    public
    void Start()
    {
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = "eu";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        SSTools.ShowMessage("Connected to Server!", SSTools.Position.bottom,SSTools.Time.twoSecond);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        SSTools.ShowMessage("Cannot connect to Server!", SSTools.Position.top, SSTools.Time.twoSecond);
        Application.Quit();
    }
}
