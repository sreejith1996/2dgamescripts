using UnityEngine;
using System.Collections;

public class CameraOffsets : MonoBehaviour {

	FollowCamera myCamera;
	public float goBack;
	public float goBacksmoothly;

	// Use this for initialization
	void Start () {
		myCamera = FindObjectOfType<FollowCamera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Pig"){
			FollowCamera.offset.z += goBack;

			Vector3 newTransform = myCamera.Pig.transform.position + FollowCamera.offset;

			myCamera.transform.position = Vector3.Lerp (myCamera.transform.position, newTransform , goBacksmoothly * Time.deltaTime);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Pig"){
			FollowCamera.offset.z -= goBack;
			
			Vector3 newTransform = myCamera.Pig.transform.position + FollowCamera.offset;
			
			myCamera.transform.position = Vector3.Lerp (myCamera.transform.position, newTransform , goBacksmoothly * Time.deltaTime);
		}
	}
}
