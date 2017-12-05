using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {

    public int damage = 50, ammo = 20;
    public float range = 50;
    public AudioClip shootSound;
    private Transform mainCamera;
    private AudioSource myAudioSource;

    // Use this for initialization
    void Start () {
        myAudioSource = GetComponent<AudioSource>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && ammo > 0) Shoot();
	}

    void Shoot() {
        Ray ray = new Ray(mainCamera.position, mainCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range)) {
            if (hit.collider.CompareTag("Enemy")) {
                // Damage the enemy
                Debug.Log("We hit an enemy. Yeah");
            }
        }

        myAudioSource.PlayOneShot(shootSound);
        ammo--;
    }
}
