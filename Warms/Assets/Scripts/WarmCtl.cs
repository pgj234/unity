using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmCtl : MonoBehaviour {
    Rigidbody2D warmRb;
    public GameObject bazokaObj;
    Bazoka bazoka;
    Equipment equipmentCs;

    public float warmJumpPower = 50f;
    public float warmSpd = 1.3f;

    bool warmDirLeft = false;
    bool isGround = false;
    bool jump = false;
    bool fire = false;

    GameObject equipment = null;
    public GameObject Equipment {
        set {
            if (equipment == null) {
                equipment = bazokaObj;
                equipmentCs = equipment.GetComponent<Bazoka>();
            }
            else {
                // equipment = value;
                // equipmentCs = equipment.GetComponent<Equipment>();
            }
        }
    }

    void Start() {
        warmRb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        //첫번째 충돌 지점이 콜라이더 위쪽 방향일 경우
        if (col.contacts[0].normal.y > 0.7f) {
            Debug.Log("바닥 충돌");
            isGround = true;
            jump = false;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        isGround = false;
    }
    
    // 좌우 이동, 점프, 장비 사용
    void Update() {

        //방향 전환
        if (Input.GetKey(KeyCode.LeftArrow) && jump == false) {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            warmDirLeft = true;
            // 스프라이트 방향도 수정
        }
        else if (Input.GetKey(KeyCode.RightArrow) && jump == false) {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            warmDirLeft = false;
            // 스프라이트 방향도 수정
        }

        // 점프 & 좌우 이동
        if (Input.GetKeyDown(KeyCode.Z) && jump == false) {
            // 움츠러드는 애니메이션 넣으면 좋고
            jump = true;
            Invoke("Jump", 0.3f);
        }
        else if (jump == false){
            float hInput = Input.GetAxis("Horizontal");

            float xSpd = hInput * warmSpd;

            Vector3 newMove = new Vector3(hInput, 0f, 0f);
            newMove = newMove.normalized * warmSpd * Time.deltaTime;
            warmRb.position = transform.position + newMove;
        }

        // 장비 사용
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("장비 사용");

            switch (warmDirLeft) {
            case false :
                // 우측 사용

                break;
            case true :
                // 좌측 사용
                break;
            }
        }
    }

    void Jump() {
        Debug.Log("점프");

        switch (warmDirLeft) {
            case false :
                warmRb.AddForce(Vector2.right * warmJumpPower);
                break;
            case true :
                warmRb.AddForce(Vector2.left * warmJumpPower);
                break;
        }
        
        warmRb.AddForce(Vector2.up * 4.5f * warmJumpPower);
    }
}