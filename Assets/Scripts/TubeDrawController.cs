using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeDrawController : MonoBehaviour {

	private string[] shapes;
	public bool generated = true;

	private Animator animatorTube;

	private int batch;
	private int generated_count;

	private CameraScript cameraScript;
	void Start () {
		shapes = new string[] {"LShape", "SquareShape", "TShapeWood", "LShapeWood", "IShapeWood", "SShapeWood", "CrossShapeWood", "SquareShapeWood", "UShapeWood", "MShapeWood"};
		animatorTube = GetComponent<Animator> ();
		cameraScript = Camera.main.GetComponent<CameraScript> ();
		batch = 25;
		generated_count = 0;
		StartCoroutine (GenerateFirstBatch ());
		StartCoroutine(DrawSingle());
	}


	
	// Update is called once per frame
	void FixedUpdate () {
		if (animatorTube.GetCurrentAnimatorStateInfo(0).IsName("TubeDown") && generated == false ){
			generated = true;
			GenerateShape ();
		}
	}

//	void OnCollisionEnter2D(Collision2D coll) {
//		if (coll.gameObject.tag == "Shape") {
//			generated = true;
//			animatorTube.SetBool ("Generating", !generated);
//		}
//	}
//
//	void OnCollisionStay2D(Collision2D coll) {
//		if (coll.gameObject.tag == "Shape") {
//			generated = true;
//			animatorTube.SetBool ("Generating", !generated);
//		}
//	}
//		
//	void OnCollisionExit2D(Collision2D coll) {
//		if (coll.gameObject.tag == "Shape") {
//			generated = false;
//			animatorTube.SetBool ("Generating", !generated);
//		}
//	}

	void GenerateShape() {
		int ind = Random.Range(0, shapes.Length - 1);
		GameObject shape = Instantiate (Resources.Load (shapes[ind]) as GameObject);
		shape.transform.position = new Vector3 (transform.position.x, transform.position.y + 2.2f, -1.5f);
		animatorTube.SetBool ("Generating", !generated);

	}

	IEnumerator DrawSingle() {
		while (true) {
			Debug.Log ("DrawSingle");
			generated = false;
			animatorTube.SetBool ("Generating", !generated);
			yield return new WaitForSeconds(7f);
		}
	}

	IEnumerator GenerateFirstBatch() {
		while (batch > 0) {
			generated_count += 1;
			int ind = Random.Range(0, shapes.Length - 1);
			GameObject shape = Instantiate (Resources.Load (shapes[ind]) as GameObject);
			shape.transform.position = new Vector3 (transform.position.x + Random.Range(2.5f, 8f), transform.position.y + 10f, -1.5f);
			batch--;
			yield return new WaitForSeconds(0.2f);
		}
		cameraScript.startTimer = true;
		StartCoroutine (GenerateOnGoing ());
		yield return null;
	}

	IEnumerator GenerateOnGoing() {
		while (!cameraScript.gameOver) {
			generated_count += 1;
			int ind = Random.Range(0, shapes.Length - 1);
			GameObject shape = Instantiate (Resources.Load (shapes[ind]) as GameObject);
			shape.transform.position = new Vector3 (transform.position.x + Random.Range(2.5f, 8f), transform.position.y + 100f, -1.5f);
			batch--;
			yield return new WaitForSeconds(Random.Range(5f, 10f));
		}

		yield return null;

	}
}
