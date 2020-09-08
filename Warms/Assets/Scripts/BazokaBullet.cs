﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazokaBullet : MonoBehaviour {

    public GameObject bazokaExplosionObj;

    Rigidbody2D bazokaBulletRb;

    [HideInInspector]
    public float BazokaBulletPower;

    void Start() {
        bazokaBulletRb = GetComponent<Rigidbody2D>();
        
        bazokaBulletRb.AddForce(transform.up * 10f * BazokaBulletPower, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col) {

        if (col.tag == "Floor" || col.tag == "Player") {
            GameObject obj = Instantiate(bazokaExplosionObj, transform.position, Quaternion.identity);
            obj.transform.SetParent(null);
            Destroy(this.gameObject);
        }
    }

    void Update() {
        transform.up = bazokaBulletRb.velocity * Time.deltaTime;
    }
}