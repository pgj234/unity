using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Manager : MonoBehaviour {

    void Start() {
        // 몬스터 생성
        Monster bead = new Monster("구슬동자", 10, 2);
        Monster capsl = new Monster("알약", 20, 5);
        Monster metal = new Monster("쇠기둥", 30, 10);

        // 몬스터 행동
        bead.Attack();
        capsl.Run();
        metal.Attack();
    }
}
