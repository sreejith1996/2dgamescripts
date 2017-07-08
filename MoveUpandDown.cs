﻿using UnityEngine;
using System.Collections;

public class MoveUpandDown : MonoBehaviour {

	public Transform farEnd;
	private Vector3 frometh;
	private Vector3 untoeth;
	public float secondsForOneLength = 1f; 

	// Use this for initialization
	void Start () {
		frometh = transform.position;
		untoeth = farEnd.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = Vector3.Lerp(frometh, untoeth,
		                                  Mathf.SmoothStep(0f,1f,
		                 Mathf.PingPong(Time.time/secondsForOneLength, 1f)
		                 ) );

	}
}
