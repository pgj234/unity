using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour, Mover {
    bool moveIng = true;
    float time = 0f;

    void Update() {
        if (moveIng == true) {
            time += Time.deltaTime;
            
            Move();
        }
    }

    public void Move() {
        if ((int)time % 2 == 0) {
            transform.position = new Vector3(transform.position.x + 0.2f, 0f, 0f);
        }
        else if ((int)time % 2 == 1) {
            transform.position = new Vector3(transform.position.x - 0.2f, 0f, 0f);
        }
    }

    public void Stop() {
        moveIng = false;
    }
}