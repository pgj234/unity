using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour {
    bool isOpen = false;    // 값 타입(값이 무조건 있어야 되는 타입, 그릇이 공유?가 안됨[그냥 값]
    bool isReallyOpen = false;

    Animal someAnimal = null;   //인스턴스 타입 (값이 없어도 되는 타입, 그릇이 공유?가 됨[주소 값])
    Animal otherAnimal = null;

    void Start() {
        // Animal tom = new Animal("톰", "야옹~");
        // Animal jerry = new Animal("제리", "찍찍!");

        // tom.PlaySound();
        // jerry.PlaySound();

        // someAnimal = tom;

        // someAnimal.PlaySound();

        // 값 타입
        isOpen = true;
        isReallyOpen = isOpen;
        Debug.Log("is Really open? : " + isReallyOpen);

        isOpen = false;
        Debug.Log("is Really open? 2 : " + isReallyOpen);

        // 인스턴스 타입
        Animal a = new Animal("A 동물", "짹짹");
        someAnimal = a;
        otherAnimal = someAnimal;

        otherAnimal.PlaySound();
        
        someAnimal.a_Name = "Some 동물";
        otherAnimal.PlaySound();
    }
}