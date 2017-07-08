using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class moveAcrossThePath : MonoBehaviour {

	public enum FollowType{
		MoveTowards,
		Lerp
	}

	public FollowType Type = FollowType.MoveTowards;
	public PathDefinition Path;
	public float Speed = 1;
	public float MaxDistanceToGoal = .1f;

	private IEnumerator<Transform> _currentPoint;

	// Use this for initialization
	public void Start () {
		if(Path == null){
			Debug.LogError("Path cannot be null",gameObject);
			return;
		}

		_currentPoint = Path.GetPathsEnumerator ();
		_currentPoint.MoveNext ();

		if(_currentPoint.Current == null){
			return;
		}

		transform.position = _currentPoint.Current.position;
	}
	
	// Update is called once per frame
	public void Update () {
		if(_currentPoint == null || _currentPoint.Current == null){
			return;
		}

		if(Type == FollowType.MoveTowards){
			transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);
		}else if(Type == FollowType.Lerp){
			transform.position = Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);
		}

		float distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;

		if(distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal){
			_currentPoint.MoveNext();
		}

	}
}
