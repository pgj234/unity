using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {
    public string human_Name;

    public char bloodType;

    public uint age;

    public float height;

    public bool isFemale;

    public void About_Me() {
        Debug.Log("내 이름은 " + human_Name);
        Debug.Log("내 혈액형은 " + bloodType);
        Debug.Log("내 나이는 " + age);
        Debug.Log("내 키는 " + height);
        Debug.Log("내가 여자야? " + isFemale);
    }
}