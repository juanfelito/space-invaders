using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {
    public float speed = 5;
    public float altTime = 0.5f;
    public Sprite startingSprite;
    public Sprite altSprite;
    public GameObject alienBullet;
    public float minFireRate = 1.0f;
    public float maxFireRate = 3.0f;
    public float baseFireRate = 3.0f;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;

        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("changeAlienSprite");

        baseFireRate = baseFireRate + Random.Range(minFireRate, maxFireRate);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "RightWall") {
            Turn(-1);
            MoveDown();
        }

        if (col.gameObject.name == "LeftWall") {
            Turn(1);
            MoveDown();
        }
    }

    void Turn(float dir) {
        Vector2 currentVel = rigidBody.velocity;
        currentVel.x = dir * speed;
        rigidBody.velocity = currentVel;
    }

    void MoveDown() {
        Vector2 position = transform.position;
        position.y -= 5;
        transform.position = position;
    }

    public IEnumerator changeAlienSprite(){
		while (true) {
			if (spriteRenderer.sprite == startingSprite) {
				spriteRenderer.sprite = altSprite;
				if (SoundManager.Instance){
                    SoundManager.Instance.PlayASound (SoundManager.Instance.alienBuzz1);
                }
			} else {
				spriteRenderer.sprite = startingSprite;
				SoundManager.Instance.PlayASound (SoundManager.Instance.alienBuzz2);
			}

			yield return new WaitForSeconds (altTime);
		}
	}

    void FixedUpdate() {
        if (Time.time > baseFireRate) {
            baseFireRate = baseFireRate + Random.Range(minFireRate, maxFireRate);

            Instantiate(alienBullet, transform.position, Quaternion.identity);
        }
    }
}
