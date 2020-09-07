using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILockPopup : MonoBehaviour {
        //  - 자물쇠 팝업 : '잠김' OR '잠김해제' 상태를 텍스트로 보여줌,
        //                  버튼 키를 맞는 패스워드로 맞추면 잠김해제.

    public Text txtLockState;

    public Image[] imgLockButtons;
    public Sprite[] colorButtonSprites;

    CombiLock combiLock;
    CombiLock.LockButton[] password;
    CombiLock.LockButton[] curButtons;

    public void InitPopup(CombiLock combiLock, CombiLock.LockButton[] pw) {
        this.combiLock = combiLock;
        password = pw;
        txtLockState.text = "잠금";

        curButtons = new CombiLock.LockButton[pw.Length];

        for (int i=0; i<curButtons.Length; i++) {
            curButtons[i] = CombiLock.LockButton.Red;
            int ci = (int)curButtons[i];
            imgLockButtons[i].sprite = colorButtonSprites[ci];
        }
    }

    public void ClickLockButton(int index) {
        int nextButtonNum = ((int)curButtons[index] +1) % (int)CombiLock.LockButton.MAX;
        curButtons[index] = (CombiLock.LockButton)nextButtonNum;

        imgLockButtons[index].sprite = colorButtonSprites[nextButtonNum];

        // check
        int check = 0;
        for (int i=0; i<curButtons.Length; i++) {
            if (curButtons[i] == password[i]) {
                check++;
            }
        }

        if (check == password.Length) {
            // unlock
            txtLockState.text = "잠금해제";
            combiLock.Unlock();
        }
    }
}