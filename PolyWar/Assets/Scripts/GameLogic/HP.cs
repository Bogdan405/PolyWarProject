using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using PlayerName;
public class HP : MonoBehaviour
{
    private const int startingHP = 1000;
    public static int personalHP;
    public static int enemyHP;
    public GameObject personalHPText;
    public GameObject enemyHPText;

    // Start is called before the first frame update
    void Start()
    {
        SetPersonalHP(startingHP);
        SetEnemyHP(startingHP);
        UpdateDisplayedHP();
    }


    public void OnClicktestLowerHP()
    {
        UpdateHPValues(personalHP - 1, enemyHP - 1);
    }

    static void SetPersonalHP(int value)
    {
        personalHP = value;
    }

    static void SetEnemyHP(int value)
    {
        enemyHP = value;
    }

    static int GetPersonalHP()
    {
        return personalHP;
    }

    static int GetEnemyHP()
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
        personalHPText.GetComponent<Text>().text = this.GetComponent<PlayerNames>().GetMyName()+ "'s HP\n" + personalHP;
        enemyHPText.GetComponent<Text>().text = this.GetComponent<PlayerNames>().GetOpponentsName() +"'s HP\n" + enemyHP;
    }

    [PunRPC]
    public void UpdateHPForEnemy(int newEnemyHP, int newPersonalHP)
    {
        SetPersonalHP(newPersonalHP);
        SetEnemyHP(newEnemyHP);
        UpdateDisplayedHP();
    }
}
