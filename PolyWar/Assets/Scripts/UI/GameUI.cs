using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

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

        public void Start()
        {
            SSTools.ShowMessage("Scan the battlefield!", SSTools.Position.middle, SSTools.Time.fiveSecond);
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

    }
}