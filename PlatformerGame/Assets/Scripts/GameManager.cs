using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] Image[] imgHps;
    [SerializeField] Sprite[] hpIcons;      // 0 : 빈하트, 1 : 채워진 하트
    [SerializeField] Text txtCoin;

    Player player;

    void Start() {
        player = FindObjectOfType<Player>();

        player.UpdateHpAction += UpdateHpUI;

        UpdateCoinUi(player.coin);
        player.UpdateCoinAction += UpdateCoinUi;
    }

    void UpdateHpUI(int hp) {
        for (int i=0; i<imgHps.Length; i++) {
            if (i < hp) {
                imgHps[i].sprite = hpIcons[1];
            }
            else {
                imgHps[i].sprite = hpIcons[0];
            }
        }
    }

    void UpdateCoinUi(int coin) {
        txtCoin.text = coin.ToString();
    }
}
