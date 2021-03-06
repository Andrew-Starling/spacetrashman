﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManyAlongSpline : MonoBehaviour {

	[SerializeField]
	public BezierSpline spline = null;
	[SerializeField]
	private GameObject[] _objects = null;
	[SerializeField]
	private float speed = 0.005f;
	[SerializeField]
	private float seperation = 0.05f;
	[SerializeField]
	private bool loop = true;

	private float progress;

	// Use this for initialization
	private void Start () {
		progress = 0;
	}

	// Update is called once per frame
	private void Update ()
	{
		
		progress = progress + (speed * Time.deltaTime);

		if (progress > 1f && loop) {
			progress = 0f;
		} else if (progress > 1f && !loop) {
			progress = 1f;
		}

		for (int index = 0; index < _objects.Length; index++) {
			float loopProgress = progress - (index * seperation);
			if (loopProgress < 0.0f) {
				loopProgress = 1.0f + loopProgress;
			}
			Vector3 position = spline.GetPoint (loopProgress);
			if (_objects [index] != null) {
				_objects [index].transform.position = position;
				_objects [index].transform.LookAt (position + spline.GetDirection (loopProgress));
			}
		}
	}
}


		 
	


