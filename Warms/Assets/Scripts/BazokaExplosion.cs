using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazokaExplosion : MonoBehaviour {

    public float explosionStrength = 5f;
    float explosionRadius;

    int bazokaDmg = 35;
 
    void Start() {
        explosionRadius = GetComponent<CircleCollider2D>().radius;
        Boom();
    }
    
    void Boom() {
        ExplosionForce.AddExplosionPower(explosionRadius, explosionStrength, transform);
        // Destroy(gameObject);
    }
    
    
}