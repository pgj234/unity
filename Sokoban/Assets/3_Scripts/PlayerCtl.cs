using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtl : MonoBehaviour {

    public float playerMoveSpd = 7f;

    Rigidbody playeRb;

    void Start() {
        playeRb = GetComponent<Rigidbody>();
    }

    void Update() {
        PlayerMove();
    }

    // 캐릭터 무브
    void PlayerMove() {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 movePos = (new Vector3(hInput, 0f, vInput)).normalized;
        movePos = movePos * playerMoveSpd * Time.deltaTime;
        playeRb.MovePosition(transform.position + movePos);
    }
}
