using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazokaExplosion : MonoBehaviour {

    Animator animator;
    public float explosionStrength = 5f;
    float explosionRadius;

    int bazokaDmg = 35;
 
    void Start() {
        animator = GetComponent<Animator>();
        explosionRadius = GetComponent<CircleCollider2D>().radius;
        Boom();
    }
    
    void Boom() {
        ExplosionForce.AddExplosion(explosionRadius, explosionStrength, bazokaDmg, transform);
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length * 1.6f);
    }
}