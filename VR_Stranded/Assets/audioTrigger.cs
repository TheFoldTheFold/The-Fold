using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine;

public class audioTrigger : MonoBehaviour {

	 //Use this for initialization
	public GameObject cam;
	public AudioClip audioC;
	private AudioSource audio;
	private bool hasPlayed = false;
	private bool triggerEffect = false;
	float lengt;

	void Start () {
		audio = GetComponent<AudioSource>();
		hasPlayed = false;
		lengt = audioC.length;	
		triggerEffect = false;	

	}

	void Update (){

		if(triggerEffect == true){

			lengt -= Time.deltaTime;

			if(lengt > 0f){

				cam.GetComponent<NoiseAndScratches>().enabled = true;
			}

			else if(lengt<0f){
				cam.GetComponent<NoiseAndScratches>().enabled = false;
				triggerEffect = false;

			}

		}

	}

	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player"){
			if (!hasPlayed) {
				audio.Play ();
				triggerEffect = true;
				hasPlayed = true;

			}
		}
	}

}
