using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using PlayerName;
using GameUserInterface;
public class HP : MonoBehaviour
{
    private const int startingHP = 1000;
    public static int personalHP;
    public static int enemyHP;
    public GameObject personalHPText;
    public GameObject enemyHPText;
    public GameObject gameNetwork;
    public GameObject exitText;
    public GameObject UI;
    public GameObject exitPanel;

    // Start is called before the first frame update
    void Start()
    {
        SetPersonalHP(startingHP);
        SetEnemyHP(startingHP);
        UpdateDisplayedHP();
    }


    public void OnClicktestLowerHP()
    {
        UpdateHPValues(personalHP - 999, enemyHP - 999);
    }

    static void SetPersonalHP(int value)
    {
        personalHP = value;
    }

    static void SetEnemyHP(int value)
    {
        enemyHP = value;
    }

    public static int GetPersonalHP()
    {
        return personalHP;
    }

    public static int GetEnemyHP()
    {
        return enemyHP;
    }

    public void UpdateHPValues(int newPersonalHP, int newEnemyHP)
    {
        SetPersonalHP(newPersonalHP);
        SetEnemyHP(newEnemyHP);
        UpdateDisplayedHP();
        PhotonView GLPV = PhotonView.Get(this);
        GLPV.RPC("UpdateHPForEnemy", RpcTarget.Others, personalHP, enemyHP);
    }

    public void UpdateDisplayedHP()
    {
        if(personalHP < 0)
        {
            personalHP = 0;
        }
        if(enemyHP < 0)
        {
            enemyHP = 0;
        }
        personalHPText.GetComponent<Text>().text = this.GetComponent<PlayerNames>().GetMyName()+ "'s HP\n" + personalHP;
        enemyHPText.GetComponent<Text>().text = this.GetComponent<PlayerNames>().GetOpponentsName() +"'s HP\n" + enemyHP;
        if(personalHP == 0 && enemyHP == 0)
        {
            PhotonView connPV = PhotonView.Get(gameNetwork);
            connPV.RPC("ExitGame", RpcTarget.Others, "Draw!");
            Text exitString = exitText.GetComponent<Text>();
            exitString.text = "Draw!";
            HideUIOnGameEnd();
        }
        if (personalHP == 0 && enemyHP > 0)
        {
            PhotonView connPV = PhotonView.Get(gameNetwork);
            connPV.RPC("ExitGame", RpcTarget.Others, "You won!");
            Text exitString = exitText.GetComponent<Text>();
            exitString.text = "You lost!";
            HideUIOnGameEnd();
        }
        if (enemyHP == 0 && personalHP > 0)
        {
            PhotonView connPV = PhotonView.Get(gameNetwork);
            connPV.RPC("ExitGame", RpcTarget.Others, "You lost!");
            Text exitString = exitText.GetComponent<Text>();
            exitString.text = "You won!";
            HideUIOnGameEnd();
        }
    }

    public void HideUIOnGameEnd()
    {
        exitPanel.SetActive(true);
        GameUI gameUI = UI.GetComponent<GameUI>();
        gameUI.OnClickHideUI();
        gameUI.setShowButton(false);
    }

    [PunRPC]
    public void UpdateHPForEnemy(int newEnemyHP, int newPersonalHP)
    {
        SetPersonalHP(newPersonalHP);
        SetEnemyHP(newEnemyHP);
        UpdateDisplayedHP();
    }
}
