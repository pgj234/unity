using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEffectText : MonoBehaviour {

    [SerializeField] Text effectText;

    public void UpdateText(string str) {
        effectText.text = str;

        DestroySelf();
    }

    void DestroySelf() {
        Destroy(gameObject, 1f);
    }
}
