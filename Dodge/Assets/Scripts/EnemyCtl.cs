using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtl : MonoBehaviour {
    public GameObject[] enemyObj;
    public GameObject bulletPrefab;

    Transform target;
    Transform enemy_Grp_Tr;

    public float min_Fire_Delay = 0.5f;
    public float max_Fire_Delay = 1.5f;

    float ranNum = 1f;
    // float minCycleSpd = 30;
    float maxCycleSpd = 700;
    float cycleSpdChangeTime = 1.0f;

    float minEnemyGrpScale = 1.0f;
    float maxEnemyGrpScale = 1.5f;
    float enemyGrpScaleSpd = 0.5f;

    void Start() {
        target = FindObjectOfType<PlayerCtl>().transform;
        enemy_Grp_Tr = GetComponent<Transform>();

        StartCoroutine(EnemyCycleRandomSpd());
        StartCoroutine(EnemyGroupScaleMove());
        StartCoroutine(EnemyRandomDelayFire());
    }

    void Update() {
        enemy_Grp_Tr.Rotate(0f, 0f, ranNum * Time.deltaTime);
    }

    IEnumerator EnemyCycleRandomSpd() {
        while (true) {
            yield return new WaitForSeconds(cycleSpdChangeTime);

            ranNum = Random.Range(-maxCycleSpd, maxCycleSpd + 1f);
        }
    }

    IEnumerator EnemyGroupScaleMove() {
        bool expansion_On = true;

        while (true) {
            yield return new WaitForFixedUpdate();

            if (enemy_Grp_Tr.localScale.x < minEnemyGrpScale) {
                expansion_On = true;
            }
            else if (enemy_Grp_Tr.localScale.x > maxEnemyGrpScale) {
                expansion_On = false;
            }

            switch (expansion_On) {
                case true :
                    enemy_Grp_Tr.localScale = new Vector3(enemy_Grp_Tr.localScale.x + (enemyGrpScaleSpd * Time.deltaTime), enemy_Grp_Tr.localScale.y + (enemyGrpScaleSpd * Time.deltaTime), 1f);
                    break;
                case false :
                    enemy_Grp_Tr.localScale = new Vector3(enemy_Grp_Tr.localScale.x - (enemyGrpScaleSpd * Time.deltaTime), enemy_Grp_Tr.localScale.y - (enemyGrpScaleSpd * Time.deltaTime), 1f);
                    break;
            }
        }
    }

    IEnumerator EnemyRandomDelayFire() {
        float spawnRate = 0.0f;

        while (true) {
            spawnRate = Random.Range(min_Fire_Delay, max_Fire_Delay);

            yield return new WaitForSeconds(spawnRate);

            for (int i=0; i<enemyObj.Length; i++) {
                GameObject BulletObj = Instantiate(bulletPrefab, enemyObj[i].transform.position, enemyObj[i].transform.rotation);

                switch (i % 2) {
                    case 0 :
                        // 랜덤 각도로 발사
                        float ranRot = Random.Range(-70, 71);
                        BulletObj.transform.Rotate(ranRot, 0f, 0f);
                        break;
                    case 1 :
                        // 플레이어 저격
                        BulletObj.transform.LookAt(target);
                        break;
                }
            }
        }
    }
}