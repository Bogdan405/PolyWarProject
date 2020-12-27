using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using Card;

namespace GameUserInterface{ 
    public class GameUI : MonoBehaviour
    {
        public GameObject LeaveButton;
        public GameObject BoardButton;
        public GameObject TurnButton;
        public GameObject HideButton;
        public GameObject ShowButton;
        public GameObject SurrenderButton;
        public GameObject EnemyHPButton;
        public GameObject MyHPButton;
        public GameObject Battlefield;
        public GameObject GameLogic;
        private bool battlefieldShown = false;
        public void Start()
        {
            if (PhotonNetwork.InRoom) 
            {
                SSTools.ShowMessage("Scan the battlefield!", SSTools.Position.middle, SSTools.Time.fiveSecond);
            }
            else
            {
                SSTools.ShowMessage("Not Connected!", SSTools.Position.middle, SSTools.Time.fiveSecond);
            }
        }

        public void OnClickHideUI()
        {
            LeaveButton.SetActive(false);
            BoardButton.SetActive(false);
            TurnButton.SetActive(false);
            HideButton.SetActive(false);
            SurrenderButton.SetActive(false);
            EnemyHPButton.SetActive(false);
            MyHPButton.SetActive(false);
            ShowButton.SetActive(true);
        }

        public void setShowButton(bool value)
        {
            ShowButton.SetActive(value);
            HideButton.SetActive(value);
        }
        public void OnClickShowUI()
        {
            LeaveButton.SetActive(true);
            BoardButton.SetActive(true);
            TurnButton.SetActive(true);
            HideButton.SetActive(true);
            SurrenderButton.SetActive(true);
            EnemyHPButton.SetActive(true);
            MyHPButton.SetActive(true);
            ShowButton.SetActive(false);
        }

        public void ShowAllPlayersAreReady()
        {
            SSTools.ShowMessage("All players are ready!", SSTools.Position.middle, SSTools.Time.threeSecond);
        }
        
        public void OnClickBattlefield()
        {
            if (battlefieldShown)
            {
                battlefieldShown = false;
                Battlefield.SetActive(false);
            }         
            else
            {
                battlefieldShown = true;
                Battlefield.SetActive(true);
                CardClass[] myCards = GameLogic.GetComponent<Board>().GetPersonalCards();
                CardClass[] enemyCards = GameLogic.GetComponent<Board>().GetEnemyCards();
                Battlefield.GetComponent<BattlefieldUI>().UpdateBattleFieldUI(myCards,enemyCards);
            }
        }
    }
}