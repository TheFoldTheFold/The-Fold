using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridInteract : MonoBehaviour {

	public int[,] grid;
	int h = 0;
	int v = 0;
    bool isActive = false;
    bool inRange = false;
	GameObject marker;
    FPSController fps;
    float horz = 0.0f;
	float vert = 0.0f;

	// Use this for initialization
	void Start () {
        isActive = false;
        inRange = false;
        grid = new int[5,3];
		int kiddies = transform.childCount;
		for(int i = 0; i < kiddies-1; ++i){
			transform.GetChild (i).gameObject.SetActive (false);
		}
		marker = transform.GetChild (kiddies - 1).gameObject;
        fps = GameObject.Find("Player").GetComponent<FPSController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Back"))
        {
            Debug.Log("Exit Interaction");
            fps.move = true;
            isActive = false;
        }
        else if (inRange && Input.GetButton("Interact"))
        {
            isActive = true;
            fps.move = false;
        }
        if (isActive)
        {
            if (Input.GetButtonUp("Jump"))
            {
                Debug.Log("jumped!");
                bool tog = transform.GetChild(v * 3 + h).gameObject.activeSelf;
                transform.GetChild(v * 3 + h).gameObject.SetActive(!tog);
            }
            if (Input.GetAxis("DX") > 0)    // right
            {
                Debug.Log("D button");
                ++h;
                Debug.Log("h: " + h);
                if (h >= 3)
                    h = 2;
                else
                    marker.transform.Translate(-0.575f, 0, 0);
            }
            if (Input.GetAxis("DY") > 0)    // up
            {
                Debug.Log("W button");
                --v;
                if (v < 0)
                    v = 0;
                else
                    marker.transform.Translate(0, 0, -0.5f);
            }
            if (Input.GetAxis("DX") < 0)    // left
            {
                Debug.Log("A button");
                --h;
                if (h < 0)
                    h = 0;
                else
                    marker.transform.Translate(0.575f, 0, 0);
            }
            if (Input.GetAxis("DY") < 0)    // right
            {
                Debug.Log("S button");
                ++v;
                if (v >= 5)
                    v = 4;
                else
                    marker.transform.Translate(0, 0, 0.5f);
            }
        }
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
