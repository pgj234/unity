using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IArchor {
    // 인터페이스에 변수는 선언 할 수 없음
    // 프로퍼티, 메소드만 선언할 수 있고, 실행 코드 넣지 못함
    // 인터페이스에 선언되는 프로퍼티와 메소드는 접근제한자를 쓰지 않음

    void ShootBow();
}

public interface IWalkable {
    int walkedDistance { get; }
    void Walk();
}

public class Hero : IArchor, IWalkable {

    public int walkedDistance {
        get { return 0; }
    }

    void Attack() {

    }

    public void ShootBow() {
        Debug.Log("히어로가 활을 쐈다");
    }

    public void Walk() {
        Debug.Log("히어로는 당당히 걷는다");
    }
}
