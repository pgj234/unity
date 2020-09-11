using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster {     // 추상 클래스

    protected string monster_Name;
    protected int monster_Hp;
    protected int monster_Damage;
    public string monster_Sound;

    public Monster(string monsterName) {
        this.monster_Name = monsterName;
    }

    protected void Attack() {
        Debug.Log("몬스터 공격");
    }

    protected void Talk() {
        Debug.Log(monster_Sound + "몬스터 talk");
    }

    protected void Eat() {
        Debug.Log("몬스터 식사");
    }

    public abstract void Sleep(string sleepSound);

    public virtual void FindPlayerAction() {
        Debug.Log("플레이어 인카운터");
    }
}

public class Slime : Monster {
    int defence;

    public Slime(string monsterName, string monsterSound, int monsterDefence) : base(monsterName) {
        this.monster_Sound = monsterSound;
        this.defence = monsterDefence;
    }

    public override void FindPlayerAction() {
        base.FindPlayerAction();    // 부모가 구현해둔 메소드

        Talk();
        Attack();
    }

    public void DoOnlySlime() {
        Debug.Log("슬라임은 물렁물렁");
    }

    public override void Sleep(string sleepSound) {
        Debug.Log(sleepSound);
        Debug.Log(sleepSound);
    }

    public void ShootBow() {

    }
}

public sealed class Skeleton : Monster, IArchor, IWalkable {
    public int walkedDistance {
        get{ return 1; }
    }

    public void Walk() {
        Debug.Log("해골은 달그락 달그락 걷는다");
    }

    int defence;

    public Skeleton(string monsterName, int monsterHp, int monsterDefence) : base(monsterName) {
        this.monster_Hp = monsterHp;
        this.defence = monsterDefence;
    }

    public override void FindPlayerAction() {
        Eat();
        Attack();
    }

    public void DoOnlySkeleton() {
        Debug.Log("해골은 달그락달그락");
    }

    public override void Sleep(string sleepSound) {
        Debug.Log(sleepSound + "Zzzzz...");
    }

    public void ShootBow() {
        Debug.Log("해골궁수가 활을 쐈다");
    }
}
