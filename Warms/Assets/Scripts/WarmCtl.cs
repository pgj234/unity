using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmCtl : MonoBehaviour {
    Rigidbody2D warmRb;

    public float warmJumpPower = 130f;
    public float warmSpd = 1.3f;

    bool warmDirLeft = false;
    bool jump = false;

    void Start() {
        warmRb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision col) {
        if (col.collider.CompareTag("Floor") && Input.GetKeyDown(KeyCode.Space)) {
            jump = true;
        }
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            warmDirLeft = true;
            // 스프라이트 방향도 수정
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            warmDirLeft = false;
            // 스프라이트 방향도 수정
        }

        if (jump == true) {
            // 움츠러드는 애니메이션 넣으면 좋고
            Invoke("Jump", 0.5f);
            jump = false;
        }
        else {
            float hInput = Input.GetAxis("Horizontal");

            float xSpd = hInput * warmSpd;

            Vector3 newMove = new Vector3(hInput, 0f, 0f);
            newMove = newMove.normalized * warmSpd * Time.deltaTime;
            warmRb.position = transform.position + newMove;
        }
    }

    void Jump() {
        switch (warmDirLeft) {
            case false :
                warmRb.AddForce(Vector2.right * warmJumpPower *Time.deltaTime);
                break;
            case true :
                warmRb.AddForce(Vector2.left * warmJumpPower *Time.deltaTime);
                break;
        }
        
        warmRb.AddForce(Vector2.up * 4.5f * warmJumpPower * Time.deltaTime);

        Invoke("test", 3f);
    }

    void test() {
        jump = false;
    }
}
