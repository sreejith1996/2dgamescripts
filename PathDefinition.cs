using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PathDefinition : MonoBehaviour {

	public Transform[] points;
	public int direction;

	public IEnumerator<Transform> GetPathsEnumerator(){
		if(points == null || points.Length < 1){
			yield break;
		}

		direction = 1;
		int index = 0;

		while(true){
			yield return points[index];

			if (points.Length == 1){
				continue;
			}

			if(index <= 0){
				direction = 1;
			}else if(index >= points.Length - 1){
				direction = -1;
			}

			index = index + direction;	
		}
	}

	public void OnDrawGizmos(){
		if (points == null || points.Length < 2)
			return;

		for(int i=1 ;i < points.Length; i++){
			Gizmos.DrawLine(points[i-1].position,points[i].position);
		}

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
