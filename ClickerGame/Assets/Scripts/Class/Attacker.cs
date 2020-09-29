using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attacker : MonoBehaviour {

    [SerializeField] protected Animator animator;

    protected int lv;
    public int Lv {
        protected set {
            lv = value;
            PlayerPrefs.SetInt(GetSaveLevelKey(), lv);
        }

        get {
            return PlayerPrefs.GetInt(GetSaveLevelKey(), 1);
        }
    }

    [Header("attacker info")]
    [SerializeField] protected AttackAttribute attackAttribute;

    [SerializeField] protected int basicDamage;
    public int totalDamage{
        get {
            return basicDamage * Lv;
        }
    }

    protected Enemy target;

    protected abstract string GetSaveLevelKey();

    public void SetTarget(Enemy enemy) {
        target = enemy;
    }

    public void UpdateLevel(int upLevel) {
        Lv += upLevel;
    }

    public int GetNextDamage(int addLevel) {
        return (Lv + addLevel) * basicDamage;
    }

    protected virtual void Attack() {
        if (target == null) {
            return;
        }

        target.GetHit(new AttackInfo(attackAttribute, totalDamage));
    }
}
