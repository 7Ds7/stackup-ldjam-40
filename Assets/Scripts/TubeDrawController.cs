using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeDrawController : MonoBehaviour {


	private string[] shapes;
	public bool generated = true;

	private Animator animatorTube;

	void Start () {
		shapes = new string[] {"LShape", "SquareShape", "TShapeWood", "LShapeWood", "IShapeWood", "SShapeWood", "CrossShapeWood", "SquareShapeWood", "UShapeWood", "MShapeWood"};
		animatorTube = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (animatorTube.GetCurrentAnimatorStateInfo(0).IsName("TubeDown") && !generated)
		{
			GenerateShape ();
		}
		

	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "Shape") {
			generated = true;
			animatorTube.SetBool ("Generating", !generated);
		}
	}
		

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "Shape") {
			generated = false;
			animatorTube.SetBool ("Generating", !generated);
		}
	}

	void GenerateShape() {
		
		int ind = Random.Range(0, shapes.Length - 1);
		GameObject shape = Instantiate (Resources.Load (shapes[ind]) as GameObject);
		shape.transform.position = new Vector3 (transform.position.x, transform.position.y + 2, -1.5f);
		generated = true;
		GameObject.Find ("Ground").GetComponent<StageController> ().currentTurn += 1;
	}
}
