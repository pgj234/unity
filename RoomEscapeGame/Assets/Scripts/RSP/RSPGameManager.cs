using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RSPGameManager : MonoBehaviour {
    public enum Hand {
        Scissors = 0,
        Rock = 1,
        Paper = 2,
        Max = 3
    }

    public enum GameResult {
        Win = 0,
        Draw = 1,
        Lose = 2
    }

    // public Image imgPcHand;
    public Sprite[] handSprites;
    public Text txtGameResult;
    // public Color[] gameResultTextColors;
    public Color[] gameResultBgColors;
    public Image backGround;
    public Text txtAllResult;
    int allGame;
    int allWin;
    int allDraw;
    int allLose;

    Hand[] pcHandPattern = new Hand[10];

    // 이것도 안되네
    // void OnGUI() {
    //     if (GUI.Button(new Rect(-150, -150, 200, 150), "단체전 가위")) {

    //     }
    //     if (GUI.Button(new Rect(0, -150, 200, 150), "단체전 바위")) {

    //     }
    //     if (GUI.Button(new Rect(150, -150, 200, 150), "단체전 보")) {
            
    //     }
    // }

    void Start() {
        GameInit();
    }

    // 게임 초기화
    void GameInit() {
        allGame = 0;
        allWin = 0;
        allDraw = 0;
        allLose = 0;
        txtGameResult.text = "";
    }

    IEnumerator IEShowGroupGameResult(int myHandInt) {
        int loopWin = 0;
        int loopLose = 0;

        GameResult result;
        Hand myHand = (Hand)myHandInt;

        for (int i = 0; i < pcHandPattern.Length; i++) {
            allGame++;

            int pcHandInt = Random.Range(0, (int)Hand.Max);
            Hand pcHand = (Hand)pcHandInt;

            if (myHandInt == pcHandInt){     // 비김
                result = GameResult.Draw;
                allDraw++;
            }
            else if ((myHand == Hand.Scissors && pcHand == Hand.Paper) ||
                        (myHand == Hand.Rock && pcHand == Hand.Scissors) ||
                        (myHand == Hand.Paper && pcHand == Hand.Rock)) {        // 이김
                result = GameResult.Win;
                loopWin++;
                allWin++;
            }
            else {      // 졌음
                result = GameResult.Lose;
                loopLose++;
                allLose++;
            }

            Debug.Log("이긴 횟수 : " + loopWin + ", " + "진 횟수 : " + loopLose);
            yield return new WaitForSeconds(0.5f);
        }

        if (loopWin > loopLose) {
            ResultFuc("이긴 횟수가 진 횟수보다 많음.", GameResult.Win);
        }
        else if (loopWin == loopLose) {
            ResultFuc("이긴 횟수와 진 횟수가 같음.", GameResult.Draw);
        }
        else {
            ResultFuc("이긴 횟수보다 진 횟수가 적음.", GameResult.Lose);
        }
    }
    
    IEnumerator IE = null;
    public void GroupClickMyHandButton(int myHandInt) {
        IE = IEShowGroupGameResult(myHandInt);
        StartCoroutine(IE);
    }

    public void ResetButton() {
        GameInit();
        ResultFuc("리셋 완료", GameResult.Draw);
    }

    void ResultFuc(string str, GameResult resultColor) {
        txtGameResult.text = str;
        backGround.color = gameResultBgColors[(int)resultColor];
        string resultText = "총 {0}회 대결\n<size=40><color=#00C8E5>승</color>   <color=#8C8C8C>무</color>   <color=#FF0000>패</color>\n{1} / {2} / {3}</size>";
        txtAllResult.text = string.Format(resultText, allGame, allWin, allDraw, allLose);
    }

    // public void ClickMyHandButton(int handInt) {
    //     allGame++;

    //     Hand myHand = (Hand)handInt;

    //     // Hand pcHand = (Hand)Random.Range(0, (int)Hand.Max);
    //     int pcHandInt = Random.Range(0, (int)Hand.Max);
    //     Hand pcHand = (Hand)pcHandInt;

    //     imgPcHand.sprite = handSprites[pcHandInt];
        

    //     // 이겼는지 졌는지 비겼는지 체크
    //     GameResult result;
    //     if (handInt == pcHandInt) {     // 비김
    //     result = GameResult.Draw;
    //         txtGameResult.text = "비겼다";
    //     }
    //     else if ((myHand == Hand.Scissors && pcHand == Hand.Paper) ||
    //                 (myHand == Hand.Rock && pcHand == Hand.Scissors) ||
    //                 (myHand == Hand.Paper && pcHand == Hand.Rock)) {        // 이김
    //         result = GameResult.Win;
    //         txtGameResult.text = "이겼다!";
    //         allWin++;
    //     }
    //     else {      // 졌음
    //         result = GameResult.Lose;
    //         txtGameResult.text = "졌다.";
    //         allLose++;
    //     }

    //     txtGameResult.color = gameResultTextColors[(int)result];
    //     string resultText = "총 {0}회 대결\n<size=40><color=#00C8E5>승</color>  패 : {1} / {2}</size>";
    //     txtAllResult.text = string.Format(resultText, allGame, allWin, allLose);
    // }
}
