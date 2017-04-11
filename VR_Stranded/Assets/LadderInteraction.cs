using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderInteraction : MonoBehaviour {
    public bool inRange;
    public bool attached;
    public GameObject ladd;
    FPSController fps;
    float speed = 3f;
    public float height;
    public float currheight;
    public float min;
    public float fwd;
    // Use this for initialization
    void Start () {
        inRange = false;
        fps = GameObject.Find("Player").GetComponent<FPSController>();
        attached = false;
        currheight = 0.0f;
        min = 0.0f;
        fwd = 0.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float moveFB = Input.GetAxis("Vertical") * speed;
        if (moveFB < 0 && currheight <= min) {
            attached = false;
            this.transform.parent = null;
            fps.move = true;
        }
        else if (attached && currheight >= height)
        {
            this.transform.rotation = Quaternion.identity;
            this.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Vector3 movement = new Vector3(0, 0, speed);
            GameObject.Find("Player").transform.Translate(movement * Time.deltaTime);
            fwd += speed*Time.deltaTime;
            if (fwd > 2)
            {
                attached = false;
                this.transform.parent = null;
                fps.move = true;
            }
        }
        else if (attached == true && currheight < height)
        {
            Vector3 movement = new Vector3();
            if (moveFB > 0 && GameObject.Find("Player").transform.localPosition.y < height)
            {
                movement = new Vector3(0, speed, 0);
            }
            else if (moveFB < 0 && GameObject.Find("Player").transform.localPosition.y > min)
            {
                movement = new Vector3(0, speed * -1, 0);
            }
            GameObject.Find("Player").transform.Translate(movement * Time.deltaTime);
            currheight = GameObject.Find("Player").transform.localPosition.y;
        }
        else if (inRange && Input.GetButton("Interact") && ladd != null && attached == false)
        {
            this.transform.parent = ladd.transform;
            this.transform.rotation = Quaternion.identity;
            this.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            fps.move = false;
            attached = true;
            
            min = GameObject.Find("Player").transform.localPosition.y;
            currheight = min;
        }
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            BoxCollider b = col as BoxCollider;
            inRange = true;
            ladd = col.gameObject;
            height = b.size.y;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            inRange = false;
            ladd = null;
        }
    }
}
