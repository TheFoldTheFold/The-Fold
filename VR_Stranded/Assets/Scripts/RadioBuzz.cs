using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine;

public class RadioBuzz : MonoBehaviour {

	public AudioClip otherClip;
	public GameObject cam;
    AudioSource audio;
    bool check;
    float wait;
	Image img;

	// Use this for initialization
	void Start () {
		img = GameObject.Find("Radio UI").GetComponent<Image>();
		audio = this.GetComponent<AudioSource>();
		cam.GetComponent<NoiseAndScratches>().enabled = false;
		wait = otherClip.length;
		check = true;


	}
	
	// Update is called once per frame
	void Update () {

		        if (check){
					img.enabled = true;
		        	wait-=Time.deltaTime;
		        	cam.GetComponent<NoiseAndScratches>().enabled = true;	

		        }
		        if(wait<0f){
					img.enabled = false;
		        	cam.GetComponent<NoiseAndScratches>().enabled = false;
		        	check = false;	
		        }

		
	}
}
