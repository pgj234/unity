using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public int coinValue;

    void OnTriggerEnter2D(Collider2D col) {
        Player player = col.GetComponent<Player>();

        if (player != null) {
            player.GetCoin(coinValue);

            Destroy(gameObject);
        }
    }
}
