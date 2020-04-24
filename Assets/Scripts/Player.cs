using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 30;
    public GameObject bullet;

    private Rigidbody2D rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            SoundManager.Instance.PlayASound(SoundManager.Instance.bulletFire);
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    void FixedUpdate() {
        float keyPress = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(keyPress, 0) * speed;
    }
}
