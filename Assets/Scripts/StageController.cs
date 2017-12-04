﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {
	public float waitTime = 3000f;
	float timer;
	public int turnsToMove;
	public int currentTurn;

	/// <summary>
	/// The time taken to move from the start to finish positions
	/// </summary>
	public float timeTakenDuringLerp = 1f;

	/// <summary>
	/// How far the object should move when 'space' is pressed
	/// </summary>
	public float distanceToMove = 10;

	//Whether we are currently interpolating or not
	private bool _isLerping;

	//The start and finish positions for the interpolation
	private Vector3 _startPosition;
	private Vector3 _endPosition;
	private Vector3 _startPosition_background;
	private Vector3 _endPosition_background;

	private GameObject background;

	//The Time.time value when we started the interpolation
	private float _timeStartedLerping;

	void Start() {
		turnsToMove = 5;
		currentTurn = 1;
		background = GameObject.Find ("SceneBackground");
	}

	/// <summary>
	/// Called to begin the linear interpolation
	/// </summary>
	void StartLerping()
	{
		_isLerping = true;
		_timeStartedLerping = Time.time;

		//We set the start position to the current position, and the finish to 10 spaces in the 'forward' direction
		_startPosition = transform.position;
		//_endPosition = transform.position + Vector3.down*distanceToMove;
		_endPosition = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

		_startPosition_background = background.transform.position;
		_endPosition_background = new Vector3 (_startPosition_background.x, _startPosition_background.y - 1f, _startPosition_background.z);

	}

	void Update()
	{
		if (currentTurn == turnsToMove) {
			StartLerping();
			currentTurn = 1;
		}
//		timer += Time.deltaTime;
//		if (timer > waitTime) {
//			Debug.Log ("Timer is done");

//			//transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.position.x, transform.position.y - 10f, transform.position.z), 0.5f*Time.deltaTime);
//			timer = 0f;
//		}

	}

	//We do the actual interpolation in FixedUpdate(), since we're dealing with a rigidbody
	void FixedUpdate()
	{
		if(_isLerping)
		{
			//We want percentage = 0.0 when Time.time = _timeStartedLerping
			//and percentage = 1.0 when Time.time = _timeStartedLerping + timeTakenDuringLerp
			//In other words, we want to know what percentage of "timeTakenDuringLerp" the value
			//"Time.time - _timeStartedLerping" is.
			float timeSinceStarted = Time.time - _timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

			//Perform the actual lerping.  Notice that the first two parameters will always be the same
			//throughout a single lerp-processs (ie. they won't change until we hit the space-bar again
			//to start another lerp)
			transform.position = Vector3.Lerp (_startPosition, _endPosition, percentageComplete);
			background.transform.position = Vector3.Lerp (_startPosition_background, _endPosition_background, percentageComplete);

			//When we've completed the lerp, we set _isLerping to false
			if(percentageComplete >= 1.0f)
			{
				_isLerping = false;
			}
		}
	}

}
