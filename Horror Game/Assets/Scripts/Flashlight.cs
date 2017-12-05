using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    public Light flashlight;
    public AudioSource audioSource;
    public AudioClip soundFlashLightOn, soundFlashLightOff;
    private bool isActive;

    void Start() {
        isActive = true;
        flashlight.enabled = true;
    }
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.F)) {
            if (!isActive) {
                flashlight.enabled = true;
                isActive = true;
                audioSource.PlayOneShot(soundFlashLightOn);
            }
            else {
                flashlight.enabled = false;
                isActive = false;
                audioSource.PlayOneShot(soundFlashLightOff);
            }
        }
	}
}
