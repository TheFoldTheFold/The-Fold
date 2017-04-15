using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTrigger : MonoBehaviour {

	// Use this for initialization

	private AudioSource audio;
	private bool hasPlayed = false;
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player"){
			if (!hasPlayed) {
				audio.Play ();
				hasPlayed = true;

			}
		}
	}
}
