using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance = null;

    public AudioClip alienBuzz1;
    public AudioClip alienBuzz2;
    public AudioClip alienDies;
    public AudioClip bulletFire;
    public AudioClip shipExplotes;

    private AudioSource soundEffect;

    void Start() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this){
            Destroy(gameObject);
        }

        soundEffect = GetComponent<AudioSource>();
    }

    public void PlayASound(AudioClip clip) {
        soundEffect.PlayOneShot(clip);
    }
}
