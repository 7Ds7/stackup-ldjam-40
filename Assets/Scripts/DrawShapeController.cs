using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawShapeController : MonoBehaviour {

	private string[] shapes;
	public bool generating = false;
	public float waitTime = 10f;
	float timer;
	// Use this for initialization
	void Start () {
		shapes = new string[] {"LShape", "SquareShape", "TShapeWood", "LShapeWood", "IShapeWood", "SShapeWood", "CrossShapeWood", "SquareShapeWood", "UShapeWood", "MShapeWood"};
	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (timer > waitTime) {
			//if (generating) {
				Debug.Log ("Timer is done");
				GenerateShape ();
				timer = 0f;
			//}
		}
		
	}

	public void GenerateShape() {
		Debug.Log (shapes.Length);
		int ind = Random.Range(0, shapes.Length - 1);
		GameObject shape = Instantiate (Resources.Load (shapes[ind]) as GameObject);
		shape.transform.position = new Vector3 (transform.position.x, transform.position.y + 10, transform.position.z);
		generating = false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Shape") {
			generating = false;
		}

	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "Shape") {
			generating = true;
		}

	}
}
