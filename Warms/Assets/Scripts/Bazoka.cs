using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bazoka : MonoBehaviour {

    float angle;
    Vector3 dir;
    Warm warm;

    public GameObject bazokaBullet;

    [SerializeField] GameObject bazokaFireObj;
    [SerializeField] Image imgPower;

    [SerializeField] float curPower;
    [SerializeField] float maxPower;

    bool shot = false;

    void Start() {
        warm = transform.parent.GetComponent<Warm>();
        imgPower.fillAmount = 0f;
    }

    void Update() {
        if (warm.my_Turn == true && shot == false) {                                                 // 바주카 마우스 조준하기
            LookAtMouse();

            if (Input.GetKeyUp(KeyCode.Space) || curPower > maxPower) {                        // 바주카 발사
                imgPower.fillAmount = 0;
                GameObject obj = Instantiate(bazokaBullet, bazokaFireObj.transform.position, bazokaFireObj.transform.rotation);
                obj.GetComponent<BazokaBullet>().BazokaBulletPower = curPower;
                obj.transform.SetParent(null);
                obj.transform.localScale = new Vector3(0.2f, 0.1f, 1f);
                shot = true;
                curPower = 0.1f;
                Invoke("TEST", 1f);     // 테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트
            }
            else if (Input.GetKey(KeyCode.Space)) {             // 바주카 파워 모으기
                curPower += Time.deltaTime;
                imgPower.fillAmount = curPower / maxPower;
            }
        }
    }

    // 마우스 방향 바라보기
    void LookAtMouse() {
        dir =  Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void TEST() {
        shot = false;
        Debug.Log("샷 : " + shot);
    }
}