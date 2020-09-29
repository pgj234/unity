using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// struct : 값 타입, 상속 안됨, 매개변수가 없는 생성자를 만들 수 없음.
public struct AttackInfo {
    public AttackAttribute attribute;
    int damage;

    public AttackInfo(AttackAttribute attribute, int damage) {
        this.attribute = attribute;
        this.damage = damage;
    }

    public int GetDamage(AttackAttribute attackedAttribute) {
        int addAttack = GetAddDamage(attribute, attackedAttribute);

        if (addAttack == 1) {
            damage = Mathf.FloorToInt((float)damage * 1.5f);
        }
        else if (addAttack == -1) {
            damage = Mathf.FloorToInt((float)damage * 0.75f);
        }

        return damage;
    }

    // -1 : 데미지 감소 | 0 : 데미지 정상 | 1 : 데미지 증가
    int GetAddDamage(AttackAttribute my, AttackAttribute your) {
        switch (my) {
            case AttackAttribute.Fire :
                if (your == AttackAttribute.Wind) {
                    return 1;
                }
                else if (your == AttackAttribute.Water) {
                    return -1;
                }
                return 0;
            
            case AttackAttribute.Water :
                if (your == AttackAttribute.Fire) {
                    return 1;
                }
                else if (your == AttackAttribute.Wind) {
                    return -1;
                }
                return 0;

            case AttackAttribute.Wind :
                if (your == AttackAttribute.Water) {
                    return 1;
                }
                else if (your == AttackAttribute.Fire) {
                    return -1;
                }
                return 0;

            default :
                return 0;
        }
    }
}