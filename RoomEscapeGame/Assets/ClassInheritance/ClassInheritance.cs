using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassInheritance : MonoBehaviour, IArchor {

    [SerializeField] 

    void Start() {
        IArchor[] archors = new IArchor[2];

        Skeleton skeleton = new Skeleton("해골 궁수", 100, 10);
        Hero hero = new Hero();

        archors[0] = skeleton;
        archors[1] = hero;

        for (int i = 0; i<archors.Length; i++) {
            archors[i].ShootBow();
        }

        IWalkable[] walkers = new IWalkable[2];
        Skeleton walkSkeleton = new Skeleton("걷는 해골", 100, 10);

        walkers[0] = hero;
        walkers[1] = walkSkeleton;

        for (int i = 0; i<walkers.Length; i++) {
            walkers[i].Walk();
            Debug.Log("걸어온 거리 : " + walkers[i].walkedDistance);
        }
    }

    public void ShootBow() {

    }

    void Test() {
        Slime slime = new Slime("호좁 슬라임", "......", 1);
        Skeleton skeleton = new Skeleton("멍때리는 해골", 100, 10);

        // Debug.Log("----------슬라임----------");
        // slime.FindPlayerAction();

        // Debug.Log("----------스켈레톤----------");
        // skeleton.FindPlayerAction();

        // Monster monster = new Monster("뭔지 모를 몬스터");
        // monster.FindPlayerAction();

        Monster[] monsters = new Monster[2];
        monsters[0] = slime;       // 자식 클래스 -> 부모 클래스 : 업 캐스팅
        monsters[1] = skeleton;

        // Slime newSlime = (Slime)monsters[0];    // 부모 클래스 -> 자식 클래스 : 다운 캐스팅

        for (int i=0; i<monsters.Length; i++) {
            monsters[i].FindPlayerAction();
            monsters[i].Sleep(monsters[i].monster_Sound);
        }
    }
}