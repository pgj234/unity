using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {
    public Rigidbody rb;

    void Start() {
        rb.AddForce(0, 500, 0);
    }
}
