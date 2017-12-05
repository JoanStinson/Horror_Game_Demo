using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {

    public string interactButton;
    public float interactDistance = 3f;
    public LayerMask interactLayer; 
    public Image interactIcon; 
    public bool isInteracting;
    
	void Start () {
        if (interactIcon != null) interactIcon.enabled = false;
	}
	
	void Update () {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // If the ray we shoot from the player hits something within the interaction distance inside the interactLayer
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer)) {

            // Checks if we are not interacting
            if (!isInteracting) {
                if (interactIcon != null) interactIcon.enabled = true;

                if (Input.GetButtonDown(interactButton)) { 
                    switch (hit.collider.tag) {
                        case "Door":   hit.collider.GetComponent<Door>().ChangeDoorState();      break; 
                        case "Key":    hit.collider.GetComponent<Key>().UnlockDoor();            break;
                        case "Safe":   hit.collider.GetComponent<Safe>().ShowSafeCanvas();       break;
                        case "Note":   hit.collider.GetComponent<Note>().ShowNoteImage();        break;
                        case "Pistol": hit.collider.GetComponent<PistolPickup>().PickupPistol(); break;
                        case "Torch":  hit.collider.GetComponent<Torch>().ChangeFlameState();    break;
                        default: break;
                    }
                }
            }
        }
        else interactIcon.enabled = false;
    }
}
