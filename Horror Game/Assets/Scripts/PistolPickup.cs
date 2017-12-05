using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolPickup : MonoBehaviour {

    public AudioClip pickupSound;
    public GameObject pistol; // Actual pistol under the player

    public void PickupPistol() {
        GetComponent<AudioSource>().PlayOneShot(pickupSound);
        pistol.SetActive(true);
        Destroy(gameObject, pickupSound.length);
    }
}
