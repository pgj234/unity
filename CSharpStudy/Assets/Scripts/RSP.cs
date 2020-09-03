using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSP : MonoBehaviour {

    // enum : 열거형, 값 타입
    public enum Hand : int {
        Kai = 0,
        Bawi = 1,
        Bo = 2,
        Max = 3
    }

    public enum GameResult {
        Win,
        Draw,
        Lose
    }

    // 0 : 가위, 1  : 바위, 2 : 보

    public Hand player;  // 플레이어가 낸 가위바위보 값

    public Hand com;     // 컴퓨터가 낸 가위바위보 값
    public Hand[] coms;       //컴퓨터들이 낸 가위바위보 값
    public int numOfComs = 10;

    void Start() {
        coms = new Hand[numOfComs];

        // var aaa = "aa";
    }

    void OnGUI() {
        //테스트 해보기 위한 GUI 생성 용도로 많이 쓴다고 함
        if (GUI.Button(new Rect(10, 10, 300, 100), "가위")) {
            com = GetRandomPcHand();
            StartGame(Hand.Kai, com);
        }

        if (GUI.Button(new Rect(10, 120, 300, 100), "바위")) {
            com = GetRandomPcHand();
            StartGame(Hand.Bawi, com);
        }

        if (GUI.Button(new Rect(10, 230, 300, 100), "보")) {
            com = GetRandomPcHand();
            StartGame(Hand.Bo, com);
        }

        if (GUI.Button(new Rect(320, 10, 300, 100), "단체전 가위")) {
            DoGroupGame(Hand.Kai);
        }

        if (GUI.Button(new Rect(320, 120, 300, 100), "단체전 바위")) {
            DoGroupGame(Hand.Bawi);
        }

        if (GUI.Button(new Rect(320, 230, 300, 100), "단체전 보")) {
            DoGroupGame(Hand.Bo);
        }
    }

    void DoGroupGame(Hand playerHand) {
        int winCount = 0;
        int loseCount = 0;
        for (int i = 0; i< coms.Length; i++) {
                coms[i] = GetRandomPcHand();
                GameResult curResult = StartGame(playerHand, coms[i]);

                if (curResult == GameResult.Win) {
                    winCount++;
                }
                else if (curResult == GameResult.Lose) {
                    loseCount++;
                }
            }

            Debug.Log("총" + coms.LongLength + "번의 게임에서 " + winCount + "번 이겼다!");
            Debug.Log(loseCount + "번 졌다!");

            foreach (var h in coms) {
                if (h == Hand.Kai) goto KAI;
                if (h == Hand.Bawi) goto BAWI;
                if (h == Hand.Bawi) goto BO;
            }

            KAI:
            Debug.Log("가위");
            BAWI:
            Debug.Log("바위");
            BO:
            Debug.Log("보");
            Debug.Log("뭔갈 내긴 했네");
    }

    // string GetHandText(int rsp) {

    // }

    Hand GetRandomPcHand() {
        return (Hand)Random.Range(0, (int)Hand.Max);        //int hand???
    }

    GameResult StartGame(Hand playerHand, Hand pcHand) {
        com = GetRandomPcHand();

        player = playerHand;

        Debug.Log("나는 <" + player + "> 를 냈다!");
        Debug.Log("컴퓨터는 <" + com + "> 를 냈다!");

        GameResult result;
        if (com == player) {
            result = GameResult.Draw;
        }
        else if ((com == Hand.Kai && player == Hand.Bawi) || (com == Hand.Bawi && player == Hand.Bo) || (com == Hand.Bo && player == Hand.Kai)) {
            result = GameResult.Win;
        }
        else {
            result = GameResult.Lose;
        }

        ShowResult(result);
        return result;
    }

    void ShowResult(GameResult result) {
        // string gameResult = (isWin) ? "내가 이겼다!" : "졌다.";
        switch (result) {
            case GameResult.Lose :
                Debug.Log("내가 졌다.");
                break;
            case GameResult.Draw :
                Debug.Log("비겼다.");
                break;
            case GameResult.Win :
                Debug.Log("내가 이겼다.");
                break;
        }
    }
}
