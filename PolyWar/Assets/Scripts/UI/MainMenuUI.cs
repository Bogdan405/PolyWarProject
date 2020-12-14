using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

namespace MainUI { 
    public class MainMenuUI : MonoBehaviourPunCallbacks
    {

        public GameObject accepting_addon;
        public GameObject waiting_addon;
        public GameObject start_button;
        public GameObject nickname_input;
        public GameObject how_to_play_button;


        
        public void DisableAllUiAddons()
        {
            accepting_addon.SetActive(false);
            waiting_addon.SetActive(false);
        }
        public void EnableAcceptingUI()
        {
            accepting_addon.SetActive(true);
        }
        public void DisableAcceptingUI()
        {
            accepting_addon.SetActive(false);
        }
        public void EnableWaitingUI()
        {
            waiting_addon.SetActive(true);
        }
        public void DisableWaitingUI()
        {
            waiting_addon.SetActive(false);
        }

        public void DisableMainMenu()
        {
            start_button.SetActive(false);
            nickname_input.SetActive(false);
            how_to_play_button.SetActive(false);
        }
        public void EnableMainMenu()
        {
            start_button.SetActive(true);
            nickname_input.SetActive(true);
            how_to_play_button.SetActive(true);
        }
        [PunRPC]
        public void ReturnMainMenu()
        {
            EnableMainMenu();
            accepting_addon.SetActive(false);
            waiting_addon.SetActive(false);
        }
    }
}