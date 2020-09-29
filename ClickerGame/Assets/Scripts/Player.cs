using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Attacker {
    // 1. 레벨, 공격력
    // 2. 공격(), 레벨업()    

    protected override string GetSaveLevelKey() {
        return "Player Level";
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Attack();
        }
    }
    
    protected override void Attack() {
        base.Attack();

        animator.SetTrigger("Attack");
    }
}
