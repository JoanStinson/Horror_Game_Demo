using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool open, isLocked;
    public float doorOpenAngle = 90f, doorClosedAngle = 0f, smooth = 2f;
    public AudioClip openingSound, lockedSound;
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeDoorState() {
        if (!isLocked) {
            open = !open;
            if (audioSource != null) audioSource.PlayOneShot(openingSound);
        }else {
            if (audioSource != null) audioSource.PlayOneShot(lockedSound);
        }

    }
	
	void Update () {
		if (open) {
            Quaternion targetRotationOpen = Quaternion.Euler(0, -doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);
        }
        else {
            Quaternion targetRotationClosed = Quaternion.Euler(0, doorClosedAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClosed, smooth * Time.deltaTime);
        }
    }
}
