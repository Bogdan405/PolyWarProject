using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;


namespace PlayerName { 
    public class PlayerNames : MonoBehaviour
    {

        private string myName;
        private string opponentName;

        void Start()
        {
            foreach(Player player in PhotonNetwork.PlayerList)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    if (player.IsMasterClient)
                    {
                        myName = player.NickName;
                    }
                    else
                    {
                        opponentName = player.NickName;
                    }     
                }
                else if (!PhotonNetwork.IsMasterClient)
                {
                    if (player.IsMasterClient)
                    {
                        opponentName = player.NickName;
                    }
                    else if (!PhotonNetwork.IsMasterClient && !player.IsMasterClient)
                    {
                        myName = player.NickName;
                    }
                } 
            }
        }

        public string GetMyName()
        {
            return myName;
        }

        public string GetOpponentsName()
        {
            return opponentName;
        }

    }
}