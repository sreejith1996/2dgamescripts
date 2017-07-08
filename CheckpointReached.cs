using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckpointReached : MonoBehaviour {

	bool isvisible = false;
	CanvasGroup canvasGroup ;
	void Start(){
		canvasGroup = GetComponent<CanvasGroup>();
		isvisible = false;
	}
	/*
	public Text mytext;
	bool isvisible = false;
	Color checkpointcolor = new Color(0f,0f,0f,0.5f);
	float smooth = 5f;

	void Start(){
		isvisible = false;
	}

	void Update(){
		if(isvisible){
			mytext.color = checkpointcolor;
		}else{
			mytext.color = Color.Lerp(mytext.color, Color.clear, smooth * Time.deltaTime);
		}
		isvisible = false;
	}




	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Pig"){
			isvisible = true;

		}

	}



	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Pig"){
			isvisible = false;
			Destroy(gameObject);
		}
	}
*/

	void Update(){
		if(isvisible){
			canvasGroup.alpha = 1;  
		}

		isvisible = false;
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Pig"){
			isvisible = true;
			
		}
		
	}


	
	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Pig"){
			FadeMe ();

			Destroy(gameObject,1.5f);
		}

     }

	public void FadeMe(){
		StartCoroutine(DoFade());
	}

	IEnumerator DoFade(){
		while(canvasGroup.alpha > 0){
			canvasGroup.alpha -= Time.deltaTime;
			yield return null;
		}
		canvasGroup.interactable = false;
		yield return null;
	}

}

