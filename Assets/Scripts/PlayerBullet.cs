using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBullet : MonoBehaviour {
    public float speed = 30;
    public Sprite alienExplotion;

    private Rigidbody2D rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, 1) * speed;
    }

    void OnTriggerEnter2D(Collider2D col) {
        switch (col.tag) {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Alien":
                SoundManager.Instance.PlayASound(SoundManager.Instance.alienDies);
                IncreaseScore();
                col.GetComponent<SpriteRenderer>().sprite = alienExplotion;
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

    void IncreaseScore() {
        var textComp = GameObject.Find("Score").GetComponent<Text>();

        int score = int.Parse(textComp.text);

        score += 10;

        textComp.text = score.ToString();
    }
}
