using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public GameObject Pig;

	public static Vector3 offset;

	public float smoothing;

	public bool isFollowing;

	// Use this for initialization
	void Start () {
		isFollowing = true;
		offset = transform.position - Pig.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (isFollowing) {
			 Vector3 targetCamPos = Pig.transform.position + offset;

			transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
		}
	}
}
