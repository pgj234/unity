using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

[CustomEditor(typeof(StageLevelManager))]
public class StageLevelEditor : Editor {
    public override void OnInspectorGUI() {
        StageLevelManager manager = target as StageLevelManager;;

        GUILayout.Space(10);
        
        manager.editTilePrefab = EditorGUILayout.ObjectField("타일 프리팹", manager.editTilePrefab, typeof(GameObject)) as GameObject;

        manager.wallPrefab = EditorGUILayout.ObjectField("Wall 프리팹", manager.wallPrefab, typeof(GameObject)) as GameObject;

        manager.itemBoxPrefab = EditorGUILayout.ObjectField("ItemBox Prefab", manager.itemBoxPrefab, typeof(GameObject)) as GameObject;

        manager.goalPrefab = EditorGUILayout.ObjectField("Goal 프리팹", manager.goalPrefab, typeof(GameObject)) as GameObject;

        manager.playerPrefab = EditorGUILayout.ObjectField("플레이어 프리팹", manager.playerPrefab, typeof(GameObject)) as GameObject;

        GUILayout.Space(20);

        manager.stageSize = EditorGUILayout.IntSlider("size", manager.stageSize, 5, 12);

        EditorGUILayout.BeginHorizontal();
        
        manager.stageId = EditorGUILayout.IntField("ID", manager.stageId);

        if (GUILayout.Button("Create Level")) {
            CreateLevel(manager);
        }

        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Clean Up")) {
            CleanUp(manager);
        }

        GUILayout.Space(20);

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Save Stage")) {
            Save(manager);
        }

        if (GUILayout.Button("Load Stage")) {
            Load(manager);
        }

        EditorGUILayout.EndHorizontal();
    }

    void CreateLevel(StageLevelManager manager) {
        manager.CreateNewStage();
    }

    void CleanUp(StageLevelManager manager) {
        manager.CleanUpStage();
    }

    void Save(StageLevelManager manager) {
        string title = "Save";
        string message = "저장 할까요?";

        if (EditorUtility.DisplayDialog(title, message, "OK", "Cancel")) {
            string fileName = "stage-" + manager.stageId;
            string path = EditorUtility.SaveFilePanel("title", Application.dataPath + "/Resources/Stage/", fileName, "xml");

            if (path.Length < 0) {
                return;
            }

            StageLevelManager.StageInfo stage = StageSerialize(manager);

            if (stage != null) {
                XmlSerializer ser = new XmlSerializer(typeof(StageLevelManager.StageInfo));
                StreamWriter writer = new StreamWriter(path);
                ser.Serialize(writer, stage);
                writer.Close();

                AssetDatabase.Refresh();
            }
        }
    }

    StageLevelManager.StageInfo StageSerialize(StageLevelManager manager) {
        var stage = new StageLevelManager.StageInfo();

        var stageCells = new List<StageLevelManager.StageCell>();
        int tileCnt = manager.stageTiles.Count;

        for (int i = 0; i< tileCnt; i++) {
            stageCells.Add(manager.stageTiles[i].GetCell());
        }

        stage.id = manager.stageId;
        stage.size = manager.stageSize;
        stage.cells = stageCells.ToArray();

        return stage;
    }
    
    void Load(StageLevelManager manager) {
        string title = "Load";
        string message = "파일을 불러올까요?";

        if (EditorUtility.DisplayDialog(title, message, "예", "아니오")) {
            string path = EditorUtility.OpenFilePanel(title, Application.dataPath + "/Resources/Stage/", "xml");

            if (path.Length < 0) {
                return;
            }

            WWW www = new WWW("file://" + path);

            XmlSerializer ser = new XmlSerializer(typeof(StageLevelManager.StageInfo));
            var info = ser.Deserialize(new StringReader(www.text)) as StageLevelManager.StageInfo;

            manager.LoadStage(info);
        }
    }

    void OnSceneGUI() {
        int id = GUIUtility.GetControlID(FocusType.Passive);
        HandleUtility.AddDefaultControl(id);

        StageLevelManager manager = target as StageLevelManager;

        Handles.BeginGUI();

        ShowSceneGUI(manager);
        PickTileEdit(manager);

        Handles.EndGUI();
    }

    void ShowSceneGUI(StageLevelManager manager) {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.black;
        style.fontSize = 20;

        GUI.Label(new Rect(20f, 20f, 120f, 30f), "EDIT TILE : " + manager.curEditType, style);

        if (GUI.Button(new Rect(20f, 70f, 100f, 30f), "None")) {
            manager.curEditType = StageLevelManager.StageCellType.None;
        }

        if (GUI.Button(new Rect(140f, 70f, 100f, 30f), "Wall")) {
            manager.curEditType = StageLevelManager.StageCellType.Wall;
        }

        if (GUI.Button(new Rect(260f, 70f, 100f, 30f), "ItemBox")) {
            manager.curEditType = StageLevelManager.StageCellType.ItemBox;
        }

        if (GUI.Button(new Rect(380f, 70f, 100f, 30f), "Goal")) {
            manager.curEditType = StageLevelManager.StageCellType.Goal;
        }

        if (GUI.Button(new Rect(20f, 110f, 100f, 30f), "Player")) {
            manager.curEditType = StageLevelManager.StageCellType.Player;
        }
    }

    void PickTileEdit(StageLevelManager manager) {
        Event e = Event.current;

        if (e.type == EventType.MouseDown == true) {
            Vector3 mousePos = Event.current.mousePosition;
            Ray ray = HandleUtility.GUIPointToWorldRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                GameObject obj = hit.collider.gameObject;
                StageEditTile tile = obj.GetComponent<StageEditTile>();

                if (tile != null) {
                    var tileType = manager.curEditType;
                    tile.EditType(manager.curEditType, manager.GetTileTypePrefab(tileType));
                }
            }
        }
    }
}