using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtl : MonoBehaviour {
    // Rigidbody playerRb;
    Transform playerTr;
    public float spd = 8f;

    void Start() {
        playerTr = GetComponent<Transform>();
        // playerRb = GetComponent<Rigidbody>();
    }

    void Update() {     // 프레임당 번씩 호출
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpd = xInput * spd * Time.deltaTime;
        float zSpd = zInput * spd * Time.deltaTime;

        playerTr.position = new Vector3(playerTr.position.x + xSpd, playerTr.position.y + zSpd, 0f);

        // transform.localPosition;

        // transform.localScale;

        // Vector3 newVelocity = new Vector3(xSpd, zSpd, 0f);
        // playerRb.velocity = newVelocity;

        // if (Input.GetKey(KeyCode.UpArrow) == true) {
        //     playerRb.AddForce(0f, 0f, spd * Time.deltaTime);
        // }

        // if (Input.GetKey(KeyCode.DownArrow) == true) {
        //     playerRb.AddForce(0f, 0f, -spd * Time.deltaTime);
        // }

        // if (Input.GetKey(KeyCode.LeftArrow) == true) {
        //     playerRb.AddForce(-spd * Time.deltaTime, 0f, 0f);
        // }

        // if (Input.GetKey(KeyCode.RightArrow) == true) {
        //     playerRb.AddForce(spd * Time.deltaTime, 0f, 0f);
        // }
    }

    public void Die() {
        gameObject.SetActive(false);
    }
}
