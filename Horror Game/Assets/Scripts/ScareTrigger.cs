using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareTrigger : MonoBehaviour {

    public AudioSource scareAudioSource;
    public AudioClip scareSound;
    public Light scaredLight;
    private bool hasPlayedAudio;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !hasPlayedAudio) {
            scareAudioSource.PlayOneShot(scareSound);
            scaredLight.enabled = true;
            hasPlayedAudio = true;
        }
    }
}
