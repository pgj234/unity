using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazoka : MonoBehaviour {

    float angle;
    Vector3 dir;
    WarmCtl warmCtl;

    public GameObject bazokaBullet;

    GameObject bazokaFireObj;

    float power = 0.1f;
    float maxPower = 3f;

    bool shot = false;

    void Start() {
        warmCtl = transform.parent.GetComponent<WarmCtl>();
        bazokaFireObj = transform.GetChild(0).gameObject;
    }

    void Update() {
        if (warmCtl.my_Turn == true && shot == false) {                                                 // 바주카 마우스 조준하기
            dir =  Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            if (Input.GetKeyUp(KeyCode.Space) || power > maxPower) {                        // 바주카 발사
                GameObject obj = Instantiate(bazokaBullet, bazokaFireObj.transform);
                obj.GetComponent<BazokaBullet>().BazokaBulletPower = power;
                obj.transform.parent = null;
                obj.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
                shot = true;
                power = 0.1f;
                Invoke("TEST", 1f);
            }
            else if (Input.GetKey(KeyCode.Space)) {             // 바주카 파워 모으기
                power += Time.deltaTime;
                Debug.Log("바주카 파워 : " + power);
            }
        }
    }

    void TEST() {
        shot = false;
        Debug.Log("샷 : " + shot);
    }
}