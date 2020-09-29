using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StudyGeneric : MonoBehaviour {

    void Start() {
        TextDisplay td = new TextDisplay();
        td.ShowText(1, "이런", "식으로", "몇개든지", "넣을 수", "있습니다.");
        td.ShowText(1, "!!", "~~");

        GameObject aObj = new GameObject();
        GameObject bObj = new GameObject();
        GameObject[] objArray = new GameObject[2] {
            aObj, bObj
        };

        GenericClass<GameObject> objGc = new GenericClass<GameObject>(aObj, objArray);

        aObj.name = "aObj";
        bObj.name = "bObj";

        Debug.Log("---- obj generic class");
        objGc.ShowMyThing();

        Vector2 aVec = new Vector2(1f, 2f);
        Vector2 bVec = new Vector2(3f, 4f);
        Vector2[] vecArray = new Vector2[2] {
            aVec, bVec
        };

        GenericClass<Vector2> vecGc = new GenericClass<Vector2>(aVec, vecArray);

        Debug.Log("---- vector2 generic class");
        vecGc.ShowMyThing();
    }

    void TestGeneric() {
        int aInt = 7;
        float aFloat = Mathf.PI;
        char oneText = 'A';
        string textString = "ABCDEF~";
        Vector2 twoDPos = new Vector2(3f, 5f);
        Vector3 threeDPos = new Vector3(0f, 1f, 0f);

        Debug.Log("ShowLog<int, char, Vector2>(aInt, oneText, twoDPos);");
        ShowLog<int, char, Vector2>(aInt, oneText, twoDPos);

        Debug.Log("ShowLog<float, string, Vector3>(aFloat, textString, threeDPos)");
        ShowLog<float, string, Vector3>(aFloat, textString, threeDPos);
    }

    // 제네릭 메소드
    // : 임의의 매개변수 타입 T, U, P를 만들고, 다양한 타입의 값을 받아올 수 있음
    void ShowLog<T, U, P>(T num, U text, P vector)
        where T : struct
        // where U : IComparable<Char>, IEnumerable<char>
        where P : IEquatable<P>
    {
        Debug.Log("number : " + num);
        Debug.Log("text : " + text);
        Debug.Log("vector : " + vector.ToString());
    }
}
