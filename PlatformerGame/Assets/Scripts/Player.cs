using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct InventoryInfo {
    public string itemName;
    public int count;
}

public class Player : MonoBehaviour {
    public delegate void UpdateNumberInfoAction(int a);

    public event UpdateNumberInfoAction UpdateHpAction;
    public event UpdateNumberInfoAction UpdateCoinAction;

    public int hp {
        get; private set;
    }

    public int coin {
        get; private set;
    }

    [SerializeField] int maxHp;
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] int jumpAbleCount;

    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleCol;
    Rigidbody2D playerRb;

    bool isDead = false;        // HP 1개 없어지는 죽음
    bool isRealDead = false;    // HP가 0이 되었을 때
    bool isJumping = false;
    int jumpCnt = 0;
    Vector3 startPos;

    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        capsuleCol = GetComponent<CapsuleCollider2D>();

        UpdateHp(maxHp);
        coin = 0;
        startPos = transform.position;
    }

    void Update() {
        if (isDead == true || isRealDead == true) {
            return;
        }

        float xInput = Input.GetAxis("Horizontal");

        if (xInput > 0.1f || xInput < -0.1f) {
            animator.SetBool("IsWalk", true);

            if (xInput > 0) {
                spriteRenderer.flipX = false;
            }
            else {
                spriteRenderer.flipX = true;
            }
        }
        else {
            animator.SetBool("IsWalk", false);
        }
    }

    void FixedUpdate() {
        if (isDead == true || isRealDead == true) {
            return;
        }

        Move();
        Jump();
    }

    public void UpdateHp(int addHp) {
        hp += addHp;

        if (hp > maxHp) {
            hp = maxHp;
        }
        else if (hp < 0) {
            hp = 0;
        }

        if (UpdateHpAction != null) {
            UpdateHpAction(hp);
        }
    }

    public void GetCoin(int addCoin) {
        coin += addCoin;

        if (UpdateCoinAction != null) {
            UpdateCoinAction(coin);
        }
    }

    public void OnDead() {
        if (isDead == true || isRealDead == true) {
            return;
        }

        StartCoroutine(IEDead());
    }

    IEnumerator IEDead() {
        isDead = true;
        UpdateHp(-1);

        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(new Vector2(1f, 8f), ForceMode2D.Impulse);
        capsuleCol.enabled = false;
        spriteRenderer.sortingLayerName = "DeadPlayer";
        animator.SetBool("IsDead", isDead);

        yield return new WaitForSeconds(1f);

        // 부활
        if (hp > 0) {
            isDead = false;
            transform.position = startPos;
            capsuleCol.enabled = true;
            spriteRenderer.sortingLayerName = "Player";
            playerRb.velocity = Vector2.zero;
            animator.SetBool("IsDead", isDead);
        }
        else {
            isRealDead = true;
        }
    }

    void Move() {
        float xVelocity = 0f;
        float xInput = Input.GetAxis("Horizontal");

        if (xInput < -0.1f) {        // Left
            xVelocity = -1f;
        }
        else if (xInput > 0.1f) {       // Right
            xVelocity = 1f;
        }

        xVelocity *= speed;
        playerRb.velocity = new Vector2(xVelocity, playerRb.velocity.y);
    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < jumpAbleCount) {
            isJumping = true;
            jumpCnt++;

            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);

            animator.SetBool("IsJumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.contacts[0].normal.y > 0f) {
            isJumping = false;
            jumpCnt = 0;

            animator.SetBool("IsJumping", false);
        }
    }
}