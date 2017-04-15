using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class pressExit : MonoBehaviour {

	bool playRange;
	public GameObject highlight;
	// Use this for initialization
	void Start () {
		playRange = false;
		highlight.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(playRange == true && Input.GetButton("Interact")){
			Debug.Log ("Exit");
			Quit ();
		}
	}
	public void Quit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}
	void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag == "Player") {
			playRange = true;
			Debug.Log ("Collide");
			highlight.SetActive (true);
		}
	}
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			playRange = false;
			highlight.SetActive (false);
			Debug.Log ("Not Collide");
		}
	}
}
