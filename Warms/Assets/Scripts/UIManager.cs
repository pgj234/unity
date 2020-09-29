using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    
    [SerializeField] Text txtCurHp;

    public Warm warm;

    public void UpdateHpUI() {
        warm.UpdateHpUI += UpdateHpUIProcess;
    }

    public void UpdateHpUIProcess(int curHp) {
        txtCurHp.text = curHp.ToString();
    }
}
