using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // 
    char[][] stage = new char[10][] {
        //             0    1    2    3    4    5    6    7    8    9
        new char[10] {'W', 'W', 'W', 'W', 'W', '.', 'W', 'W', 'W', '.'},    // 0
        new char[10] {'W', '.', '.', '.', 'W', '.', 'W', 'G', 'W', '.'},    // 1
        new char[10] {'W', '.', 'I', '.', 'W', '.', 'W', 'G', 'W', '.'},    // 2
        new char[10] {'W', '.', 'I', '.', 'W', '.', 'W', 'G', 'W', '.'},    // 3
        new char[10] {'W', 'W', 'W', '.', 'W', 'W', 'W', '.', 'W', '.'},    // 4
        new char[10] {'.', 'W', 'W', '.', '.', 'P', '.', '.', 'W', '.'},    // 5
        new char[10] {'.', 'W', '.', 'I', '.', 'W', '.', '.', 'W', '.'},    // 6
        new char[10] {'.', 'W', '.', '.', '.', 'W', 'W', 'W', 'W', '.'},    // 7
        new char[10] {'.', 'W', 'W', 'W', 'W', 'W', '.', '.', '.', '.'},    // 8
        new char[10] {'.', '.', '.', '.', '.', '.', '.', '.', '.', '.'}     // 9
    };
    
    public Transform stageTr;
    public GameObject wallPrefab;

    void Start() {
        for (int i=0; i<stage.Length; i++) {
            for (int j=0; j<stage[i].Length; j++) {
                if (stage[i][j] == 'W') {
                    GameObject wallObj = Instantiate(wallPrefab, stageTr);

                    Vector3 newPos = new Vector3(j, 0.5f, -i);
                    Vector3 correction = new Vector3(stage[i].Length * 0.5f, 0f, -(stage[j].Length * 0.5f));
                    wallObj.transform.localPosition = newPos - correction - new Vector3(-0.5f, 0f, 0.5f);
                }
            }
        }
    }
}
