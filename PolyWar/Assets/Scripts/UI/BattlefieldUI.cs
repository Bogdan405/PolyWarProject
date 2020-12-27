using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;

public class BattlefieldUI : MonoBehaviour
{
    public GameObject myCard1;
    public GameObject myCard2;
    public GameObject myCard3;
    public GameObject enemyCard1;
    public GameObject enemyCard2;
    public GameObject enemyCard3;

    public void UpdateBattleFieldUI(CardClass[] myCards, CardClass[] enemyCards)
    {
        UpdateBattlefieldCard(myCards[0], myCard1);
        UpdateBattlefieldCard(myCards[1], myCard2);
        UpdateBattlefieldCard(myCards[2], myCard3);
        UpdateBattlefieldCard(enemyCards[0], enemyCard1);
        UpdateBattlefieldCard(enemyCards[1], enemyCard2);
        UpdateBattlefieldCard(enemyCards[2], enemyCard3);


    }

    private void UpdateBattlefieldCard(CardClass card,GameObject uicard)
    {
        uicard.GetComponent<BattlefieldCardUI>().initCard(card);
    }
}
