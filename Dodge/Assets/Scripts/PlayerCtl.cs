using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtl : MonoBehaviour {
    public Rigidbody playerRb;
    public float spd = 8f;

    void Update() {     // 프레임당 번씩 호출
        if (Input.Getkey(KeyCode.UpArrow) == true) {
            playerRb.AddForce(0f, 0f, spd * Time.deltaTime);
        }

        if (Input.Getkey(KeyCode.DownArrow) == true) {
            playerRb.AddForce(0f, 0f, -spd * Time.deltaTime);
        }

        if (Input.Getkey(KeyCode.LeftArrow) == true) {
            playerRb.AddForce(-spd * Time.deltaTime, 0f, 0f);
        }

        if (Input.Getkey(KeyCode.RightArrow) == true) {
            playerRb.AddForce(spd * Time.deltaTime, 0f, 0f);
        }
    }
}
