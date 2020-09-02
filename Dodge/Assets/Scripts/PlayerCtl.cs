using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtl : MonoBehaviour {
    Rigidbody playerRb;
    // Transform playerTr;
    public float spd = 10f;

    void Start() {
        // playerTr = GetComponent<Transform>();
        playerRb = GetComponent<Rigidbody>();
    }

    void Update() {     // 프레임당 번씩 호출
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        float xSpd = hInput * spd * Time.deltaTime;
        float zSpd = vInput * spd * Time.deltaTime;

        Vector3 newMove = new Vector3(hInput, vInput, 0f);
        newMove = newMove.normalized * spd * Time.deltaTime;
        playerRb.position = transform.position + newMove;

        // playerTr.position = new Vector3(playerTr.position.x + xSpd, playerTr.position.y + zSpd, 0f);

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
        GameManager manager = FindObjectOfType<GameManager>();
        manager.EndGame();

        gameObject.SetActive(false);
    }
}
