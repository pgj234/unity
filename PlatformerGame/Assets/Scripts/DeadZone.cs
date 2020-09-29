using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapCollider2D))]
public class DeadZone : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        Player player = col.transform.GetComponent<Player>();

        if (player != null) {
            player.OnDead();
        }
    }
}
