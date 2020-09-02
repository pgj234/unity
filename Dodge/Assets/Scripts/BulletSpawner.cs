using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

    #region 오브젝트 OR 컴포넌트 public 변수 선언
    
    public GameObject[] enemyObj;
    public GameObject bulletPrefab;

    #endregion

    #region 오브젝트 OR 컴포넌트 private 변수 선언

    Transform target;

    #endregion

    #region 일반 public 변수 선언

    public float min_Fire_Delay = 0.5f;
    public float max_Fire_Delay = 1.5f;

    #endregion

    void Start() {
        target = FindObjectOfType<PlayerCtl>().transform;

        StartCoroutine(EnemyRandomDelayFire());
    }

    //총알 랜덤 주기로 발사
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
