using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Warm : MonoBehaviour {
    public event UnityAction<Warm, int> UpdateHp;
    public event UnityAction<int> UpdateHpUI;

    [SerializeField] UIManager uIManager;
    
    public int HP {
        get {
            return curHp;
        }
        
        set {
            curHp = value;

            if (curHp < 0) {
                curHp = 0;
            }

            uIManager.warm = this;
        }
    }

    [SerializeField] GameObject warmRootObj;
    [SerializeField] Rigidbody2D warmRb;
    Camera camera;
    Transform _mousePosition;

    [SerializeField] int maxHp;
    int curHp = 0;
    public float warmSpd = 1.3f;
    public float warmJumpPower = 1f;
    public bool my_Turn = false;

    bool action = false;
    bool warmDirLeft = false;

    public bool WarmDirLeft {
        get {
            return warmDirLeft;
        }
    }

    bool isGround = false;

    public GameObject equipmentObj;
    [HideInInspector] public GameObject equipmentChildObj;

    void Start() {
        my_Turn = true; // 테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트테스트
        curHp = maxHp;
        // warmRb = GetComponent<Rigidbody2D>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        EquipmentCreate(equipmentObj);
    }

    public void EquipmentCreate(GameObject equipObj) {
        equipObj = Instantiate(equipmentObj, transform);
        equipmentChildObj = equipObj.transform.GetChild(0).gameObject;
    }

    public void CurEquipmentDestroy() {
        Destroy(transform.GetChild(0).gameObject);
    }

    void OnCollisionEnter2D(Collision2D col) {
        //첫번째 충돌 지점이 콜라이더 위쪽 방향일 경우
        if (col.contacts[0].normal.y > 0.7f) {
            Debug.Log("바닥 충돌");
            isGround = true;
            action = false;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        isGround = false;
    }
    
    // 좌우 이동, 점프, 장비 사용
    void Update() {

        if (my_Turn == true) {
            //방향 전환
            if (Input.GetKey(KeyCode.LeftArrow) && action == false) {
                WarmLeftDir();
            }
            else if (Input.GetKey(KeyCode.RightArrow) && action == false) {
                WarmRightDir();
            }
            else {
                if (camera.ScreenToWorldPoint(Input.mousePosition).x < this.transform.position.x && action == false) {       //마우스가 캐릭보다 왼쪽
                    WarmLeftDir();
                }
                else if (camera.ScreenToWorldPoint(Input.mousePosition).x > this.transform.position.x && action == false) {      //마우스가 캐릭보다 오른쪽
                    WarmRightDir();
                }
            }

            // 점프 & 좌우 이동
            if (Input.GetKeyDown(KeyCode.Z) && action == false) {
                // 움츠러드는 애니메이션 넣으면 좋고
                action = true;
                Invoke("Jump", 0.3f);
            }
            else if (action == false){
                float hInput = Input.GetAxis("Horizontal");

                float xSpd = hInput * warmSpd;

                Vector3 newMove = new Vector3(hInput, 0f, 0f);
                newMove = newMove.normalized * warmSpd * Time.deltaTime;
                warmRb.position = transform.position + newMove;
            }

            // 장비 사용
            if (Input.GetKeyDown(KeyCode.Space) && action == false) {
                Debug.Log("장비 사용");
                action = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space)) {
                Debug.Log("장비 사용 끝");
                action = false;
            }
        }
    }

    void Jump() {
        Debug.Log("점프");

        switch (warmDirLeft) {
            case false :
                warmRb.AddForce(Vector2.right * warmJumpPower, ForceMode2D.Impulse);
                //다른 사람에게도 보여주기
                break;
            case true :
                warmRb.AddForce(Vector2.left * warmJumpPower, ForceMode2D.Impulse);
                //다른 사람에게도 보여주기
                break;
        }
        
        warmRb.AddForce(Vector2.up * 4.5f * warmJumpPower, ForceMode2D.Impulse);
        //다른 사람에게도 보여주기
    }

    void WarmLeftDir() {
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        warmDirLeft = true;
        equipmentChildObj.GetComponent<SpriteRenderer>().flipY = true;
        // 스프라이트 방향도 수정

        //다른 사람에게도 보여주기
    }

    void WarmRightDir() {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        warmDirLeft = false;
        equipmentChildObj.GetComponent<SpriteRenderer>().flipY = false;
        // 스프라이트 방향도 수정

        //다른 사람에게도 보여주기
    }
}