using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazokaBullet : MonoBehaviour {

    Rigidbody2D bazokaBulletRb;

    Collider2D boomRadCol;

    int bazokaDmg = 35;

    public float BazokaBulletPower;

    void Start() {
        bazokaBulletRb = GetComponent<Rigidbody2D>();

        bazokaBulletRb.AddForce(transform.up * 10f * BazokaBulletPower, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Floor" || col.tag == "Player") {
            Boom(bazokaDmg);
        }
    }

    void Boom(int dmg) {
        Debug.Log("탄 삭제");
        Destroy(this.gameObject);
        // 폭발 구현하기
    }
}