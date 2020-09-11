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
    public GameObject itemBoxPrefab;
    public GameObject goalPrefab;

    public MoveAbleProp moveAbleProp;

    List<MoveAbleProp> itemBoxs;
    Dictionary<Vector3, GameObject> goalDic;

    void Start() {
        itemBoxs = new List<MoveAbleProp>();
        goalDic = new Dictionary<Vector3, GameObject>();

        for (int i=0; i<stage.Length; i++) {
            for (int j=0; j<stage[i].Length; j++) {
                switch (stage[i][j]) {
                    case 'P' :
                        SetPropPosition(moveAbleProp.gameObject, j, i);
                        moveAbleProp.Init(j, i);
                        break;
                    case 'W' :
                        LeavePropOnStage(wallPrefab, j, i);
                        break;
                    case 'I' :
                        GameObject item = LeavePropOnStage(itemBoxPrefab, j, i);
                        MoveAbleProp moveAbleItem = item.GetComponent<MoveAbleProp>();
                        moveAbleItem.Init(j, i);
                        itemBoxs.Add(moveAbleItem);
                        break;
                    case 'G' :
                        GameObject goalObj = LeavePropOnStage(goalPrefab, j, i);
                        goalDic.Add(new Vector3(j, 0, i), goalObj);
                        break;
                }
            }
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            // 플레이어 위치 : [5][5]
            // 플레이어의 위 : [4][5]

            Vector3 upVector = new Vector3(0f, 0f, 1f);
            
            MovePlayer(upVector);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            Vector3 downVector = new Vector3(0f, 0f, -1f);

            MovePlayer(downVector);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Vector3 leftVector = new Vector3(-1f, 0f, 0f);

            MovePlayer(leftVector);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Vector3 rightVector = new Vector3(1f, 0f, 0f);

            MovePlayer(rightVector);
        }
    }

    void MovePlayer(Vector3 dir) {
        int moveZ = (int)(moveAbleProp.myPos.z - dir.z);
        int moveX = (int)(moveAbleProp.myPos.x + dir.x);
        char destination = stage[moveZ][moveX];

        switch (destination) {
            case 'W' :
                break;
            case 'I' :
                int nextX = (int)(moveX + dir.x);
                int nextZ = (int)(moveZ - dir.z);
                char nextItem = stage[nextZ][nextX];

                if ((nextItem == 'W' || nextItem == 'I') == false) {    // 플에이어가 아이템을 밀 수 있음.
                    if (nextItem != 'G') {
                        stage[moveZ][moveX] = 'P';
                        stage[nextZ][nextX] = 'I';
                        moveAbleProp.Move(dir);

                        foreach (MoveAbleProp i in itemBoxs) {
                            if (i.myPos.x == moveX && i.myPos.z == moveZ) {
                                i.Move(dir);
                            }
                        }
                    }
                    else {
                        stage[moveZ][moveX] = 'P';
                        stage[nextZ][nextX] = '.';
                        moveAbleProp.Move(dir);

                        foreach (MoveAbleProp item in itemBoxs) {
                            if (item.myPos.x == moveX && item.myPos.z == moveZ) {
                                item.gameObject.SetActive(false);
                            }
                        }

                        Vector3 goalKey = new Vector3(nextX, 0f, nextZ);

                        if (goalDic.ContainsKey(goalKey) == true) {
                            goalDic[goalKey].SetActive(false);
                        }
                        else {
                            Debug.LogError("에러 : Goal 오브젝트가 없음");
                        }
                    }
                }

                break;
            case '.' :
            case 'P' :
            case 'G' :
                moveAbleProp.Move(dir);
                break;
        }
    }

    GameObject LeavePropOnStage(GameObject propPrefab, int x, int z) {
        GameObject propObj = Instantiate(propPrefab, stageTr);

        SetPropPosition(propObj, x, z);

        return propObj;
    }

    void SetPropPosition(GameObject propObj, int x, int z) {
        Vector3 newPos = new Vector3(x, 0f, -z);
        Vector3 correction = new Vector3(stage[z].Length * 0.5f, 0f, -(stage.Length * 0.5f));
        propObj.transform.localPosition = newPos - correction - new Vector3(-0.5f, 0f, 0.5f);
    }
}