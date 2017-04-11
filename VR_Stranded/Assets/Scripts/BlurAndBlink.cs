using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine;

public class BlurAndBlink : MonoBehaviour {

		public GameObject cam; 
		public bool switching;


	// Use this for initialization
	void Start () {

			switching = false;
			cam.GetComponent<VignetteAndChromaticAberration>().enabled = true;
			cam.GetComponent<BlurOptimized>().enabled = true;

	}
	
	// Update is called once per frame
	void Update () {

		if(switching == false && cam.GetComponent<VignetteAndChromaticAberration>().intensity < 1){
			if((cam.GetComponent<VignetteAndChromaticAberration>().intensity + 0.2f * Time.deltaTime) < 1){
					cam.GetComponent<VignetteAndChromaticAberration>().intensity += 0.2f * Time.deltaTime;
			}
			else{
				switching=true;
			}
			cam.GetComponent<BlurOptimized>().blurSize += 0.3f * Time.deltaTime;
		}
		else if(switching == true){
			cam.GetComponent<VignetteAndChromaticAberration>().intensity -= 0.2f * Time.deltaTime;
			cam.GetComponent<BlurOptimized>().blurSize -= 0.3f * Time.deltaTime;
			cam.GetComponent<BlurOptimized>().enabled = false;

		}
		
	}
}
