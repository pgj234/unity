using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // 유한 상태 머신 (AI)
    // Idle : 지정된 좌표를 서성거리면서 캐릭터가 근처에 왔는지 탐색
    // Follow : 캐릭터가 근처에 있으면 캐릭터를 향해 이동
    
    [SerializeField] Vector2 moveStartPos;
    [SerializeField] Vector2 moveEndPos;
    [SerializeField] float speed;
    [SerializeField] float idleTime;
    [SerializeField] float findTargetLength = 3f;
    float waitTime;
    bool isWaiting = false;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;

    void Update() {
        if (FindPlayer() == false) {
            OnIdle();
        }
    }

    bool FindPlayer() {
        Vector3 startRay = transform.position + new Vector3(0f, 0.3f, 0f);
        Vector2 findDir = GetDirection() * findTargetLength;
        Ray2D ray = new Ray2D(transform.position, GetDirection() * findTargetLength);
        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction, findTargetLength);
        Debug.DrawRay(transform.position, GetDirection() * findTargetLength, Color.red, 0.1f);

        for (int i=0; i<hits.Length; i++) {
            if (hits[i].collider != null) {
                Player player = hits[i].collider.GetComponent<Player>();

                if (player != null) {
                    Debug.Log("Player 찾음");
                    OnFollow(player.transform.position);
                    return true;
                }
            }
        }

        return false;
    }

    void OnIdle () {
        if (isWaiting == true) {
            waitTime += Time.deltaTime;

            if (waitTime >= idleTime) {
                isWaiting = false;
                waitTime = 0f;
            }

            animator.SetBool("IsWalking", false);
        }
        else {
            Walk();
        }
    }

    void Walk() {
        Vector2 dir = (spriteRenderer.flipX == true) ? Vector2.left : Vector2.right;

        if (transform.position.x <= moveEndPos.x) {
            isWaiting = true;
            dir = Vector2.right;
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x >= moveStartPos.x) {
            isWaiting = true;
            dir = Vector2.left;
            spriteRenderer.flipX = true;
        }

        transform.position += ((Vector3)dir * speed) * Time.deltaTime;
        animator.SetBool("IsWalking", true);
    }

    Vector2 GetDirection() {
        if (spriteRenderer.flipX == true) {
            return Vector2.left;
        }
        else {
            return Vector2.right;
        }
    }

    void OnFollow(Vector3 targetPos) {
        Vector3 dir = new Vector3(targetPos.x - transform.position.x, 0f, 0f).normalized;

        transform.position += (dir * speed) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col) {
        Player player = col.GetComponent<Player>();

        if (player != null) {
            player.OnDead();
        }
    }
}