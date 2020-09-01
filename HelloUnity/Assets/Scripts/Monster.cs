using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster {
    public string mon_Name;
    public uint age;
    public int power;

    public Monster(string _mon_Name, uint _age, int _power) {
        this.mon_Name = _mon_Name;
        this.age = _age;
        this.power = _power;
    }

    public void Attack() {
        Debug.Log(mon_Name + "[" + age + "] " + "의 데미지 : " + power);
    }

    public void Run() {
        Debug.Log(mon_Name + "[" + age + "] " + "가 도망! : ");
    }
}