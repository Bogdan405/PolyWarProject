using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;
using GameUserInterface;
using PlayerName;

namespace PlayerTurn { 
    public class Turn : MonoBehaviour
    {   
        private enum TurnType{
            MasterTurn,
            NotMasterTurn,
            None
        }
        private TurnType currentTurn = TurnType.None;
        public GameObject turnPanel;

        public void OnClickInitTurns()
        {
            PhotonView turnPV = PhotonView.Get(this);
            turnPV.RPC("InitTurns", RpcTarget.All);
        }


        public void OnClickChangeTurn()
        {
            PhotonView turnPV = PhotonView.Get(this);
            turnPV.RPC("ChangeTurn", RpcTarget.All);
        }

        [PunRPC]
        public void InitTurns()
        {
            currentTurn = TurnType.MasterTurn;
            UpdateTurnPanel();
        }
    
        [PunRPC]
        public void ChangeTurn()
        {
            if(currentTurn == TurnType.MasterTurn)
            {
                currentTurn = TurnType.NotMasterTurn;
            }
            else
            {
                currentTurn = TurnType.MasterTurn;
            }
            UpdateTurnPanel();
        }

        public void UpdateTurnPanel()
        {
            Text panelText = turnPanel.GetComponent<Text>();
            if (IsMyTurn())
            {
                panelText.text = "Your Turn";
            }
            else
            {
                panelText.text = this.GetComponent<PlayerNames>().GetOpponentsName() +"'s Turn";
            }
        }

        public bool IsMyTurn()
        {
            if(PhotonNetwork.IsMasterClient && currentTurn == TurnType.MasterTurn)
            {
                return true;
            }
            else if (!PhotonNetwork.IsMasterClient && currentTurn == TurnType.NotMasterTurn)
            {
                return true;
            }
            return false;
        }

    }
}