using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class MessageConsoleScript : MonoBehaviourPunCallbacks
{

    public GameObject console_message;

    [PunRPC]
    public void update_console(string msg)
    {
        Text console_msg = console_message.GetComponent<Text>();
        console_msg.text = msg;
    }
}
