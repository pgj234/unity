using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal {
    public string a_Name;
    public string sound;

    public Animal() {
        a_Name = "동물 이름";
        sound = "동물 사운드";
    }

    public Animal(string _name, string _sound) {
        this.a_Name = _name;
        this.sound = _sound;
    }

    public void PlaySound() {
        Debug.Log(a_Name + " : " + sound);
    }
}
