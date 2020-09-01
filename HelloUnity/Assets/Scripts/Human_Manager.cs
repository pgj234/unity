using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Manager : MonoBehaviour {
    //float a = 1.0f;
    public Player player;
    public Human[] humans;

    // public Human human_1;
    // public Human human_2;
    // public Human human_3;

    void Start() {
        // Debug.Log("-------첫번째 휴먼--------");
        // humans[0].About_Me();
        // Debug.Log("-------두번째 휴먼--------");
        // humans[1].About_Me();
        // Debug.Log("-------세번째 휴먼--------");
        // humans[2].About_Me();

        // for (int i=0; i<humans.Length; i++) {
        //     Debug.Log("-------------------------------------------------");
        //     humans[i].About_Me();
        // }

        foreach (int f in player.favorite) {
            Ending(f);
        }

        for (int i=0; i<player.favorite.Length; i++) {
            Ending(player.favorite[i]);
        }

        int j = 0;
        while (j < player.favorite.Length) {
            Ending(player.favorite[j]);
            j += 1;
        }
    }

    void Ending(float fav) {
        if (fav >= 100) {
            Debug.Log("히든 엔딩");
        }
        else if (IsGoodEnding(fav)) {
            Debug.Log("굿 엔딩");
        }
        else {
            Debug.Log("배드 엔딩");
        }
    }

    bool IsGoodEnding(float f) {
        //return f >= 50;
        return (f > 50) && (f < 100);
    }
}