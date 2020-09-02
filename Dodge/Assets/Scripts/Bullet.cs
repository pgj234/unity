using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float spd = 650f;
    Rigidbody bulletRb;

    void Start() {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * spd * Time.deltaTime;
        
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            PlayerCtl player = col.GetComponent<PlayerCtl>();

            if (player != null) {
                player.Die();
            }
        }
    }
}