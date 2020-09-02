using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    // 1. 게임오버될 시 게임오바 패널(창을 최고 스코어와 함께)을 띄워준다.
    // 2. 게임이 시작된 이후부터 얼마나 시간이 지났는지 표시
    // 3. 최고로 왤 버틴 시간을 저장
    // 4. 게임오버가 됐을 떄 'R' 버튼을 누르면 게임이 재시작

    public GameObject gameoverPanel;
    public Text txtTime;
    public Text txtBestTime;
    float surviveTime;
    bool isGameover;

    void Start() {
        surviveTime = 0f;
        isGameover = false;
    }

    void Update() {
        if (isGameover == false) {
            surviveTime += Time.deltaTime;
            txtTime.text = "Time : " + (int)surviveTime;
        }

        if (Input.GetKeyUp(KeyCode.R) && isGameover == true) {
            SceneManager.LoadScene("Dodge");
        }
    }

    public void EndGame() {
        isGameover = true;

        gameoverPanel.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime", surviveTime);

        if (surviveTime >= bestTime) {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        txtBestTime.text = "최고 기록 : " + (int)bestTime;
    }
}