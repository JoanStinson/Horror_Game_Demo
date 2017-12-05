using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Safe : MonoBehaviour {

    public Canvas safeCanvas;
    public GameObject playerObject;
    public float doorOpenAngle = 90f, doorClosedAngle = 0f, smooth = 2f;
    public Text[] text = new Text[4];
    private int[] number = new int[4];

    void Start() {
        safeCanvas.enabled = false;
        for (uint i = 0; i < number.Length; i++) 
            number[i] = 0;
    }

	void Update () {
        if (Input.GetButtonDown("Cancel")) HideSafeCanvas();

        if (number[0] == 0 && number[1] == 0 && number[2] == 0 && number[3] == 1) {
            HideSafeCanvas();
            gameObject.layer = 0;
            UnlockSafe();
        }
	}

    public void ShowSafeCanvas() {
        safeCanvas.enabled = true;
        playerObject.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void HideSafeCanvas() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerObject.GetComponent<FirstPersonController>().enabled = true;
        safeCanvas.enabled = false;
    }

    void UnlockSafe() {
        Quaternion targetRotationOpen = Quaternion.Euler(0, 0, doorOpenAngle);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);
    }

    public void IncreaseNumber(int pos) {
        number[pos]++;
        text[pos].text = number[pos].ToString();
        if (number[pos] > 9) {
            number[pos] = 0;
            text[pos].text = number[pos].ToString();
        }
    }

    public void DecreaseNumber(int pos) {
        number[pos]--;
        text[pos].text = number[pos].ToString();
        if (number[pos] < 0) {
            number[pos] = 9;
            text[pos].text = number[pos].ToString();
        }
    }
}
