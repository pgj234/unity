using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : OpenAbleProp, IClickAble {
    // 문 : 열쇠(아이템)가 있으면 문이 열리고 없으면 없다고 텍스트로 띄워주기

    public string doorName;
    public string keyName;
    public bool hasKey { get; private set; }

    // void OnEnable()    // 주로 초기화 코드를 작성

    protected override void Start() {      // 초기화

        base.Start();

        Close();
        hasKey = false;
    }

    public bool SetHasKey(string gotKey) {
        if (keyName == gotKey) {
            hasKey = true;

            GameManager.Manager.ShowNotice(doorName + "의 열쇠를 얻었습니다.");
        }

        return hasKey;
    }

    public void OnClick() {
        if (hasKey == true) {
            Open();
            GameManager.Manager.ShowEscape();
        }
        else {
            GameManager.Manager.ShowNotice("문이 잠겨있습니다.");
        }
    }
}
