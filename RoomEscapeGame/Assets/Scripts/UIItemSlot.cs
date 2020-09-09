using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour {

    Image imgItem;

    public void UpdateSlot(Sprite item) {
        imgItem = GetComponent<Image>();
        imgItem.sprite = item;

        RectTransform rect = GetComponent<RectTransform>();
        // rect = imgItem.rectTransform;
        rect.sizeDelta = item.textureRect.size;
    }
}
