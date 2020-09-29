// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class StudyCollection : MonoBehaviour {

//     // System.Collections : ArrayList, Queue, Stack   -> 현재 사용 권장 X
//     // System.Collections.Generic : List, Dictionary, Queue Stack

//     string[] stringArray;

//     List<string> stringList;

//     Dictionary<string, Vector2> vectorDic;

//     Stack<int> intStack;
//     Queue<int> intQueue;

//     void Start() {
//         intStack = new Stack<int>();
//         intQueue = new Queue<int>();

//         intStack.Push(0);
//         intStack.Push(1);
//         intStack.Push(2);
//         intStack.Push(3);

//         intQueue.Enqueue(6);
//         intQueue.Enqueue(7);
//         intQueue.Enqueue(8);
//         intQueue.Enqueue(9);

//         int allCount = intStack.Count;

//         for (int i=0;i< allCount; i++) {
//             Debug.Log("intStack 의 " + (i+1) + "번째 값 : " + intStack.Pop());
//             Debug.Log("intQueue 의 " + (i+1) + "번째 값 : " + intQueue.;
//         }

//         // vectorDic = new Dictionary<string, Vector2>();

//         // vectorDic.Add("위", Vector2.up);
//         // vectorDic.Add("아래", Vector2.down);
//         // vectorDic.Add("왼쪽", Vector2.left);
//         // vectorDic.Add("오른쪽", Vector2.right);

//         // if (vectorDic.ContainsKey("위") == true) {
//         //     Vector2 upVec = vectorDic["위"];
//         // }

//         // if (vectorDic.ContainsValue(Vector2.up) == true) {

//         // }

//         // foreach (KeyValuePair<string, Vector2> dicElement in vectorDic) {
//         //     Debug.Log("vectorDic[" + dicElement.Key + "] : " + dicElement.Value);
//         // }
//     }

//     void StudyList() {

//     }

//     void ShowStringList() {
//         for (int i=0; i< stringList.Count; i++) {
//             Debug.Log("stringList[" + i + "] : " + stringList[i]);
//         }
//     }
// }