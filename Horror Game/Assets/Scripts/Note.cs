using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Note : MonoBehaviour {

    public Image noteImage;
    public GameObject hideNoteButton;
    public AudioClip pickupSound, putAwaySound;
    public GameObject playerObject;

    void Start () {
        noteImage.enabled = false;
        hideNoteButton.SetActive(false);
    }
	
    public void ShowNoteImage() {
        noteImage.enabled = true;
        hideNoteButton.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(pickupSound);
        playerObject.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideNoteImage() {
        noteImage.enabled = false;
        hideNoteButton.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(putAwaySound);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerObject.GetComponent<FirstPersonController>().enabled = true;
    }
}
