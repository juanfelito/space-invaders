using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour {
    public float speed = 30;
    public Sprite playerExplotion;

    private Rigidbody2D rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, -1) * speed;
    }

    void OnTriggerEnter2D(Collider2D col) {
        switch (col.tag) {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Player":
                SoundManager.Instance.PlayASound(SoundManager.Instance.shipExplotes);
                col.GetComponent<SpriteRenderer>().sprite = playerExplotion;
                Destroy(gameObject);
                DestroyObject(col.gameObject, 0.5f);
                break;
            case "Shield":
                Destroy(gameObject);
                DestroyObject(col.gameObject);
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
