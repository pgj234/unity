using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Manager : MonoBehaviour {

    void Start() {
        Monster monster_1 = new Monster("구슬동자", 10, 2);
        Monster monster_2 = new Monster("알약", 20, 5);
        Monster monster_3 = new Monster("쇠기둥", 30, 10);

        monster_1.Attack();
        monster_2.Run();
        monster_3.Attack();
    }
}
