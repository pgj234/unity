using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazokaExplosion : MonoBehaviour {

    // public float explosionStrength  = 100f;
    public float explosionRadius = 5f;
    // public float upwardsModifier = 0.0f;

    int bazokaDmg = 35;
 
    void Start() {
        Boom();
    }   
    
    // void Update() {
    //     transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
    // }
    
    void Boom() {
        ExplosionForce();
        // Destroy(gameObject);
    }
    
    void ExplosionForce() {
        Collider2D[] col2D = Physics2D.OverlapCircleAll(transform.position, 10.0f);

        foreach (Collider2D hit in col2D) {
            WarmCtl warmCtl = hit.GetComponent<WarmCtl>();

            if (warmCtl != null) {
                Rigidbody2D rb2D = hit.GetComponent<Rigidbody2D>();

                float x = explosionRadius - (rb2D.position.x - transform.position.x);
                float y = explosionRadius - (rb2D.position.y - transform.position.y);
                if (x > explosionRadius) {
                    x = -explosionRadius - (rb2D.position.x - transform.position.x);
                }

                if (y > explosionRadius) {
                    y = -explosionRadius - (rb2D.position.y - transform.position.y);
                }

                rb2D.AddForce(new Vector2(x, y) / 2, ForceMode2D.Impulse);
            }
        }
    }
}