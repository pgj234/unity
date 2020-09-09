using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce {
    public static void AddExplosionPower(float explosionRadius, float explosionStrength, Transform boomTr) {
        Collider2D[] col2D = Physics2D.OverlapCircleAll(boomTr.position, explosionRadius);

        foreach (Collider2D hit in col2D) {
            if (hit.gameObject.tag == "Player") {
                Rigidbody2D warmRb = hit.gameObject.GetComponent<Rigidbody2D>();
                Debug.Log("왐즈 히트");
                Debug.Log("폭발 반지름 : " + explosionRadius);
                Debug.Log("x 거리 : " + (warmRb.position.x - boomTr.position.x));
                Debug.Log("y 거리 : " + (warmRb.position.y - boomTr.position.y));

                float x = explosionRadius - (warmRb.position.x - boomTr.position.x);
                float y = explosionRadius - (warmRb.position.y - boomTr.position.y);
                if (x > explosionRadius) {
                    x = -explosionRadius - (warmRb.position.x - boomTr.position.x);
                }

                if (y > explosionRadius) {
                    y = -explosionRadius - (warmRb.position.y - boomTr.position.y);
                }

                warmRb.AddForce((new Vector2(x, y) / 2) * explosionStrength, ForceMode2D.Impulse);
            }
        }
    }
}
