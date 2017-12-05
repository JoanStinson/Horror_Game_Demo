using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public Door myDoor;
    public AudioClip pickupKey;
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void UnlockDoor() {
        myDoor.isLocked = false;
        if (audioSource != null) audioSource.PlayOneShot(pickupKey);
        Destroy(gameObject, pickupKey.length);
    }
}
