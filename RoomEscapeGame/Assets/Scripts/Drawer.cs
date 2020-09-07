using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour {
    // - 서랍장 : 자물쇠가 있는 서랍장이면 안 열리고, 잠겼다고 알림.
    //           없으면 그냥 열리면서 서랍장 팝업이 뜸.

    public Sprite openDrawerSprite;
    public Sprite closeDrawerSprite;

    public CombiLock combiLock;

    public GameObject drawerPopup;

    SpriteRenderer renderer;

    int curLockMessage = 0;

    string[] lockMessages = new string[] {
        "서랍이 잠겨있습니다.",     // 0
        "자물쇠를 풀어야 서랍을 열 수 있습니다.",     // 1
        "자물쇠를 먼저 풀어야합니다."     // 2
    };

    void Start() {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = closeDrawerSprite;

        if (drawerPopup != null) {
            drawerPopup.SetActive(false);
        }
    }

    public void ClickDrawer() {
        if (combiLock != null && combiLock.IsLock == true) {
            GameManager.Manager.ShowNotice(lockMessages[curLockMessage]);
            curLockMessage = (curLockMessage +1) % lockMessages.Length;
        }
        else {
            GameManager.Manager.ShowNotice("");
            renderer.sprite = openDrawerSprite;

            SetPopupOn(true);
        }
    }

    void SetPopupOn(bool isOn) {
        drawerPopup.SetActive(isOn);
        GameManager.Manager.SetPopupOn(isOn);
    }

    public void CloseDrawer() {
        SetPopupOn(false);
        renderer.sprite = closeDrawerSprite;
    }
}
