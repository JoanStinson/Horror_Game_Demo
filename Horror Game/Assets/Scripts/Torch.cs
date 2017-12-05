using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {

    public int lightMode;
    public GameObject flameLight, flame;
    private bool lit = true;
	
	void Update () {
		if (lightMode == 0) StartCoroutine(AnimateLight());
	}

    IEnumerator AnimateLight() {
        lightMode = Random.Range(1, 4);
        if (lightMode == 1) flameLight.GetComponent<Animation>().Play("TorchAnim1");
        else if (lightMode == 2) flameLight.GetComponent<Animation>().Play("TorchAnim2");
        else if (lightMode == 3) flameLight.GetComponent<Animation>().Play("TorchAnim3");
        yield return new WaitForSeconds(0.99f);
        lightMode = 0;
    }

    public void ChangeFlameState() {
        lit = !lit;
        flame.SetActive(lit);
        flameLight.SetActive(lit);
    }
}
