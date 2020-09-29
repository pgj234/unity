using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour {
    [SerializeField] Text info_Txt;

    public void SetInfoTxt(string str) {
        info_Txt.text = str;
    }
}
