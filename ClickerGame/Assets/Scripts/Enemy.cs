using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackAttribute {
    None,
    Water,
    Fire,
    Wind,
}

public class Enemy : MonoBehaviour {
    // 1. MaxHp, curHP
    // 2. Encounter(), GetHit(), Dead()

    [SerializeField] Animator animator;
    [SerializeField] GameObject effectDamagePrefab;
    [SerializeField] GameObject effectCoinPrefab;

    [Header("enemy info")]
    [SerializeField] AttackAttribute attackAttribute;
    [SerializeField] int baseCoin;

    static int lv;
    public static int Lv {
        set {
            lv = value;
            PlayerPrefs.SetInt("Enemy Level", lv);
        }

        get {
            return PlayerPrefs.GetInt("Enemy Level", 1);
        }
    }

    public int Coin {
        get {
            return baseCoin * Lv;
        }
    }

    int maxHp;
    int curHp;

    public bool isDead { private set; get; }

    public void Encounter(int maxHp) {
        this.maxHp = maxHp;
        curHp = maxHp;
        isDead = false;
    }

    public void DisAppear() {
        Destroy(gameObject);
    }

    public void GetHit(AttackInfo attackInfo) {
        if (isDead == true) {
            return;
        }

        int damage = attackInfo.GetDamage(attackAttribute);
        curHp -= damage;
        GameObject effectObj = Instantiate(effectDamagePrefab, transform);
        UIEffectText effectText = effectObj.GetComponent<UIEffectText>();
        effectText.UpdateText((damage * -1).ToString());

        if (curHp <= 0) {
            Dead();
        }
        else {
            animator.SetTrigger("GetHit");
        }
    }

    void Dead() {
        isDead = true;
        animator.SetTrigger("Die");
        
        Instantiate(effectCoinPrefab, transform);
        GameManager.Manager.UpdateEnemyDie(Coin);
        Destroy(gameObject, 2f);
    }
}
