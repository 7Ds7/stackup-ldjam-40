using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoonController : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("Do the happy dance");
			Camera.main.GetComponent<CameraScript> ().winState = true;
			StartCoroutine (WinDelay ());
		}
	}

	IEnumerator WinDelay() {
		yield return StartCoroutine(Win(3f));
	}


	IEnumerator Win(float delay) {
		yield return new WaitForSeconds(delay);
		Debug.Log ("Taddammmmm");
		SceneManager.LoadScene (3);
	}
}
