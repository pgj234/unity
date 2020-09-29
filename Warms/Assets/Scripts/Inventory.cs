using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    [SerializeField] Transform inventoryTr;

    [SerializeField] GameObject[] itemSlot_Btn;

    bool openInventory;
    bool inventoryMoving;

    Vector3 inventoryHidePosition;
    Vector3 inventoryDiscoverPosition;

    void Start() {
        Init();
    }

    void Update() {

        // 인벤토리 여는 키 누름
        if (inventoryMoving == false && Input.GetKeyDown(KeyCode.I)) {
            inventoryMoving = true;
        }

        // 인벤토리 열기
        if (inventoryMoving == true) {

            switch(openInventory) {
                case false :
                    inventoryTr.localPosition = Vector3.Lerp(inventoryTr.localPosition, inventoryDiscoverPosition, 0.2f);
                    
                    if (inventoryTr.localPosition.x < inventoryDiscoverPosition.x + 0.1f) {
                        openInventory = true;
                        inventoryMoving = false;
                    }

                    break;
                case true :
                    inventoryTr.localPosition = Vector3.Lerp(inventoryTr.localPosition, inventoryHidePosition, 0.2f);

                    if (inventoryTr.localPosition.x >= inventoryHidePosition.x - 0.1f) {
                        openInventory = false;
                        inventoryMoving = false;
                    }

                    break;
            }
        }
    }

    void Init() {
        inventoryMoving = false;
        openInventory = false;
        inventoryTr = GetComponent<Transform>();
        inventoryHidePosition = inventoryTr.localPosition;
        inventoryDiscoverPosition = new Vector3(inventoryHidePosition.x - 200f, inventoryHidePosition.y, inventoryHidePosition.z);

        for (int i=3; i<itemSlot_Btn.Length; i++) {
            itemSlot_Btn[i].GetComponent<Button>().interactable = false;
        }
    }
}
