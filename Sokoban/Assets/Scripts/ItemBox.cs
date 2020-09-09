using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {
    public Color touchColor;

    Color originColor;

    Renderer renderer;

    void Start() {
        renderer = GetComponent<Renderer>();
        originColor = renderer.material.color;
    }

    // void OnTriggerEnter(Collider col) {
    //     // Debug.Log(col.gameObject.name + " 이 부딪힘");

    //     SetTouchColor(col.tag);
    // }

    void OnTriggerStay(Collider col) {
        SetTouchColor(col.tag);
    }

    void OnTriggerExit(Collider col) {
        if (col.tag == "Goal") {
            renderer.material.color = originColor;
        }
    }

    void SetTouchColor(string tag) {
        if (tag == "Goal") {
            renderer.material.color = touchColor;
        }
    }
}
