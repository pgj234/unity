using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // 1. 물체를 클릭했을 때,
    //      문 : 열쇠가 있으면 열리고 없으면 없다고 텍스트로 띄워주기
    //      서랍장 : 자물쇠가 있는 서랍장이면 안 열리고 잠겼다고 알림. 없으면 그냥 열림
    //      자물쇠 : 잠김 상태면 자물쇠 팝업 띄워주고 열리면 사라짐.
    //      메시지 텍스트 : 인터렉션이 되는 물체를 클릭했을 때, 안내문구를 띄워줌.

    // 2. UI
    //      서랍장 내부 팝업 : 방금 누른 서랍장의 내부를 보여주기.
    //      자물쇠 팝업 : '잠김' OR '잠김해제' 상태를 텍스트로 보여줌,
    //                      버튼 키를 맞는 패스워드로 맞추면 잠김 해제.
    //      인벤토리 : 먹을 수 있는 아이템을 누르면 인벤토리로 들어옴.

    static GameManager manager;

    //프로퍼티
    public static GameManager Manager {
        get {
            return manager;
        }

        private set {
            if (manager == null) {
                manager = value;
            }
            else {
                Destroy(value.gameObject);
            }
        }
    }

    public GameObject itemSlotPrefab;
    public Transform inventoryTr;
    public GameObject escapePopup;
    public Text txtNotice;
    public List<Door> doors;

    bool isPopupOn;

    void Awake() {
        Manager = this;

        isPopupOn = false;
    }

    void Update() {
        if (isPopupOn == true) {
            return;
        } 

        if (Input.GetMouseButtonDown(0) == true) {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(mousePos, Vector2.zero);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);

            foreach(var hit in hits) {
                IClickAble clickAble = hit.transform.GetComponent<IClickAble>();
                if (clickAble != null) {
                    clickAble.OnClick();
                }
            }
        }
    }

    public void PutInItem(GameObject item) {
        string itemId = item.name;

        for (int i=0; i<doors.Count; i++) {
            if (doors[i].SetHasKey(itemId)) {
                item.SetActive(false);
            }
        }

        Image itemImg = item.GetComponent<Image>();
        GameObject slotObj = Instantiate(itemSlotPrefab, inventoryTr);

        RectTransform slotTr = slotObj.GetComponent<RectTransform>();
        slotTr.anchoredPosition = new Vector2(0f, 0f);

        UIItemSlot slot = slotObj.GetComponent<UIItemSlot>();
        slot.UpdateSlot(itemImg.sprite);
    }

    public void SetPopupOn(bool isOn) {
        isPopupOn = isOn;
    }

    public void ShowNotice(string notice) {
        txtNotice.text = notice;
    }

    public void ShowEscape() {
        escapePopup.SetActive(true);
        isPopupOn = true;
    }
}