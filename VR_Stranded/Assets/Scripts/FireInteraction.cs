using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInteraction : MonoBehaviour {
    public bool lighter;
    public bool holding;
    public bool turning;
    public bool open;
    public bool flame;
    public bool campfireRange;
    AudioSource click;
    public GameObject li;
    public GameObject pivot;
    public GameObject plyr;
    float angle = 0.0f;
    // Use this for initialization
    void Start () {
        click = GameObject.Find("Lighter").GetComponent<AudioSource>();
        lighter = false;
        holding = false;
        turning = false;
        flame = false;
        open = false;
        campfireRange = false;
        pivot = GameObject.Find("LighterPivot");
        plyr = GameObject.Find("Player");
        GameObject.Find("Flame").GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Back") && li != null)
        {
            flame = false;
            GameObject.Find("Flame").GetComponent<ParticleSystem>().enableEmission = flame;
            li.transform.parent = null;
            li.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (lighter == true && Input.GetButtonUp("Interact") && holding == false)
        {
            holding = true;
            
            li.transform.parent = this.transform;
            li.transform.rotation = Quaternion.identity;
            li.transform.localPosition = new Vector3(0f, 0.6f, -1f);
            li.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
        }
        if(holding == true && Input.GetButton("Interact"))
        {
            turning = true;
        }
        if (turning == true && angle > -130f)
        {
            pivot.transform.Rotate(-10, 0, 0);
            angle -= 10;
        }
        if(turning == true && angle <= -130f)
        {
            open = true;
        }
        if (campfireRange == true && flame == true && Input.GetButtonUp("Interact") && GameObject.Find("Campfire").transform.GetChild(0).gameObject.activeSelf == false)
        {
            GameObject cf = GameObject.Find("Campfire");
            cf.transform.GetChild(0).gameObject.SetActive(true);
            cf.transform.GetChild(1).gameObject.SetActive(true);
            cf.transform.GetChild(2).gameObject.SetActive(true);
            cf.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (open == true && Input.GetButtonUp("Interact"))
        {
            flame = !flame;
            GameObject.Find("Flame").GetComponent<ParticleSystem>().enableEmission = flame;
            if (flame == true)
            {
                click.Play();
            }
        }
        
        
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Lighter")
        {
            lighter = true;
            li = col.gameObject;
        }
        if (col.name == "Campfire")
        {
            campfireRange = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Lighter")
        {
            lighter = false;
            li.transform.parent = null;
            li = null;
        }
        if (col.name == "Campfire")
        {
            campfireRange = false;
        }
    }
}
