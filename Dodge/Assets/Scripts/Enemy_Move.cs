using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour {
    public Transform enemy_Grp_Tr;
    float ranNum = 1f;

    void Start() {
        StartCoroutine(EnemyCycle());
    }

    void Update() {
        enemy_Grp_Tr.Rotate(0f, 0f, 10f *ranNum * Time.deltaTime);
    }

    IEnumerator EnemyCycle() {
        while (true) {
            yield return new WaitForSeconds(1f);

            ranNum = Random.Range(5, 70);
        }
    }
}
