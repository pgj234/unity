using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField] Text txtKillCount;
    [SerializeField] Image gaugeTime;
    [SerializeField] Text txtCoin;

    [Header("LevelUp Buttons")]
    [SerializeField] Text txtPlayerLevelInfo;
    [SerializeField] Text txtPlayerLevelUpPrice;
    [SerializeField] Text txtEnemyLevelInfo;
    [SerializeField] Text txtEnemyLevelUpPrice;
    [SerializeField] Text txtPetLevelInfo;
    [SerializeField] Text txtPetLevelUpPrice;

    void Start() {
        txtCoin.text = PlayerPrefs.GetInt("Coin", 0).ToString();
    }

    public void UpdateKillCount(int killCnt) {
        txtKillCount.text = killCnt.ToString();
    }

    public void UpdateTime(float maxTime, float spendTime) {
        float leftTime = (maxTime - spendTime) / maxTime;
        gaugeTime.fillAmount = leftTime;
    }

    public void UpdateCoin(int coinNum) {
        txtCoin.text = coinNum.ToString();
    }

    string GetAttackerLevelInfo(int curLevel, int curDamage, int nextDamage) {
        return string.Format("Lv. {0} > <b>{1}</b>\n<size=40>(DMG : {2} > {3})</size>", curLevel, curLevel +1, curDamage, nextDamage);
    }

    public void UpdatePlayerLevelUpButton(int curLevel, int curDamage, int nextDamage, int price) {
        txtPlayerLevelInfo.text = GetAttackerLevelInfo(curLevel, curDamage, nextDamage);

        txtPlayerLevelUpPrice.text = price.ToString();
    }

    public void UpdateEnemyLevelUpButton(int price) {
        string info = string.Format("Lv. {0} > <b>{1}</b>\n<size=40>({2}배 추가 획득)</size>", Enemy.Lv, Enemy.Lv +1, Enemy.Lv);

        txtEnemyLevelInfo.text = info;
        txtEnemyLevelUpPrice.text = price.ToString();
    }

    public void UpdatePetLevelUpButton(int curLevel, int curDamage, int nextDamage, int price) {
        txtPetLevelInfo.text = GetAttackerLevelInfo(curLevel, curDamage, nextDamage);
        txtPetLevelUpPrice.text = price.ToString();
    }
}