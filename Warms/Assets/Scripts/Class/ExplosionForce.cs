using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce {
    public static void AddExplosion(float explosionRadius, float explosionStrength, int damage, Transform boomTr) {
        Collider2D[] col2D = Physics2D.OverlapCircleAll(boomTr.position, explosionRadius);

        foreach (Collider2D hit in col2D) {
            Warm warm = hit.gameObject.GetComponent<Warm>();
            
            if (warm != null) {
                Rigidbody2D warmRb = hit.gameObject.transform.parent.GetComponent<Rigidbody2D>();

                float x = explosionRadius - (warmRb.position.x - boomTr.position.x);
                float y = explosionRadius - (warmRb.position.y - boomTr.position.y);
                
                if (x > explosionRadius) {
                    x = -explosionRadius - (warmRb.position.x - boomTr.position.x);
                }

                if (y > explosionRadius) {
                    y = -explosionRadius - (warmRb.position.y - boomTr.position.y);
                }

                HpDeal(warm, damage);
                // warm.UpdateHp += HpDeal;

                warmRb.AddForce((new Vector2(x, y) / 2) * explosionStrength, ForceMode2D.Impulse);
            }
        }
    }

    static void HpDeal(Warm warm, int damage) {
        warm.HP -= damage;
        Debug.Log("웜즈 현재 체력 : " + warm.HP);
    }
}
