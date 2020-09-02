using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster {
    public string monName;
    public uint age;
    public int power;

    // 몬스터 생성자
    public Monster(string mMonName, uint mAge, int mPower) {
        this.monName = mMonName;
        this.age = mAge;
        this.power = mPower;
    }

    // 몬스터 공격
    public void Attack() {
        Debug.Log(monName + "[" + age + "] " + "의 데미지 : " + power);
    }

    // 몬스터 Run
    public void Run() {
        Debug.Log(monName + "[" + age + "] " + "가 도망! : ");
    }
}