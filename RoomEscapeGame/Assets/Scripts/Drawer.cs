using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : OpenAbleProp, IClickAble {
    // - 서랍장 : 자물쇠가 있는 서랍장이면 안 열리고, 잠겼다고 알림.
    //           없으면 그냥 열리면서 서랍장 팝업이 뜸.

    public CombiLock combiLock;

    public GameObject drawerPopup;

    int curLockMessage = 0;

    string[] lockMessages = new string[] {
        "서랍이 잠겨있습니다.",     // 0
        "자물쇠를 풀어야 서랍을 열 수 있습니다.",     // 1
        "자물쇠를 먼저 풀어야합니다."     // 2
    };

    protected override void Start() {
        base.Start();
        Close();
        
        if (drawerPopup != null) {
            drawerPopup.SetActive(false);
        }
    }

    public void OnClick() {
        if (combiLock != null && combiLock.IsLock == true) {
            GameManager.Manager.ShowNotice(lockMessages[curLockMessage]);
            curLockMessage = (curLockMessage +1) % lockMessages.Length;
        }
        else {
            GameManager.Manager.ShowNotice("");
            Open();

            SetPopupOn(true);
        }
    }

    void SetPopupOn(bool isOn) {
        drawerPopup.SetActive(isOn);
        GameManager.Manager.SetPopupOn(isOn);
    }

    public void CloseDrawer() {
        SetPopupOn(false);
        Close();
    }
}
