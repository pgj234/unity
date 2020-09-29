using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplay {

    // params : 가변인자. 자료형은 무조건 어레이로, 마지막에 넣어줘야 함.  int a 는 보여주기용
    public void ShowText(int a, params string[] texts) {
        string textForShow = "";

        for (int i=0; i<texts.Length; i++) {
            textForShow = textForShow + " / " + textForShow;
        }

        Debug.Log(textForShow);
    }
}

public class GenericClass<T>
    where T : new() {
        
    T genericThing;
    T[] genericThings;

    public GenericClass(T thing, T[] things) {
        this.genericThing = thing;
        this.genericThings = things;
    }

    

    public void ShowMyThing() {
        Debug.Log(genericThing.ToString());

        for (int i=0; i<genericThings.Length; i++) {
            Debug.Log("genericThings : " + genericThings[i].ToString());
        }
    }
}