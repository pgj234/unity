// using System.Collections;
// using System.Collections.Generic;
// using System;
// using UnityEngine;

// public class TestType : MonoBehaviour {

//     string who = "고영희";
//     string where = "카페를 갔다.";
//     int money = 3000000;

//     string text = "{3:yyyy.MM.dd}에 길을 가다 {0}를 만나서 {1}    돈 : [{2:0,000}]";

//     byte b; // string을 byte로 형변환, 반대도 가능  서버와 통신 할 때만

//     // StringBuilder sb = new StringBuilder();
//     // sb;
    
//     public const float SPEED_OF_MOVE = 10f; // const형은 대문자와 언더바로 표시

//     public readonly GameObject SOME_PREFAB = new GameObject();  // 인스턴스 타입은 const대신 readonly

//     public static string godName = "신";

//     void Start() {

//         TestType.godName = "뭐";
//         // object intObject;
//         // intObject = intNum;             // int -> object 박싱
//         // int newInt = (int)intObject;    // object -> int 언박싱

//         DateTime day = new DateTime(2020, 9, 3);

//         Debug.Log(string.Format(text, who, where, money, day));
//     }
// }