using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

	public float speed = 50f;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		var right = inputState.GetButtonValue (inputButtons [0]);
		var left = inputState.GetButtonValue (inputButtons [1]);
		var run = inputState.GetButtonValue (inputButtons [2]);

		if (right || left) {
			var tmpSpeed = speed;
			if (run && runMultiplier > 0) {
				tmpSpeed *= runMultiplier;
			}
			var velX = tmpSpeed * (float)inputState.direction;
			body2d.velocity = new Vector2 (velX, body2d.velocity.y);
		}
		
	}
}



