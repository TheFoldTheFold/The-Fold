using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {

	public float speed = 2f;
	public float sensitivity = 2f;
	CharacterController player;
    public GameObject pu;

	public GameObject cam;
    private GameObject plyr;

	float moveFB;
	float moveLR;

	float rotX;
	float rotY;
	float vertVelocity;

	public float jumpDist;
	private int jumpTimes;

    private float run;
    public bool move;
    public bool canInteract;

    bool safeRange;

	public static int itemCount;
	// Use this for initialization
	void Start () {
        move = true;
		player = GetComponent<CharacterController> ();
        plyr = GameObject.Find("Player");
        canInteract = false;
        safeRange = false;
		itemCount = 3;
	}
	
	void Update () {
		moveFB = Input.GetAxis ("Vertical") * speed;
		moveLR = Input.GetAxis ("Horizontal") * speed;

		rotX = Input.GetAxis ("Mouse X") * sensitivity;
		rotY -= Input.GetAxis ("Mouse Y") * sensitivity;

        rotY = Mathf.Clamp(rotY, -60f, 60f);
        transform.Rotate(0, rotX, 0);
        cam.transform.localRotation = Quaternion.Euler(rotY, 0, 0);


        //if (canInteract == true && Input.GetButton("Interact")) {
        //    //move = false;
        //    //transform.LookAt(pu.transform);
        //    interaction();
        //}
        if (safeRange == true && Input.GetButton("Interact")) {
            move = false;
            SafeController sc = pu.gameObject.GetComponent<SafeController>();
            sc.isActive = true;
        }
        else if (move == true) {
            movement();
        } 
	}

	void FixedUpdate() {
		if (player.isGrounded == false) {
			vertVelocity += Physics.gravity.y * Time.deltaTime;
		} else {
			vertVelocity = 0f;
		}
	}
    void OnTriggerEnter(Collider col) {
        //if (col.gameObject.tag == "PickUp") {
        //    canInteract = true;
        //    pu = col.gameObject;
        //}
        if (col.gameObject.tag == "Safe") {
            safeRange = true;
            pu = col.gameObject;
        }
    }
    void OnTriggerExit(Collider col) {
        //if (col.gameObject.tag == "PickUp") {
        //    canInteract = false;
        //    pu = null;
        //} 
        if (col.gameObject.tag == "Safe") {
            safeRange = false;
            pu = null;
        }
    }
    void movement() {
        

        Vector3 movement = new Vector3(moveLR, vertVelocity, moveFB);
        
        

        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);

        float triggerAxis = Input.GetAxis("Triggers");  // left trigger = -1; right trigger = 1;

        if (player.isGrounded == true) {    // enable gravity
            jumpTimes = 0;
        }
        if (jumpTimes < 1) {                // jump once
            if (Input.GetButtonDown("Jump"))
            {
                vertVelocity += jumpDist;
                jumpTimes += 1;
            }
        }
        if (Input.GetButton("Run") || Input.GetAxis("Triggers") < -0.5) {   // running
            speed = 7f;
        }
        else {  // walking speed
            speed = 3f;
        }
    }
    //void interaction() {
    //    if (pu.transform.parent != null) {
    //        pu.transform.parent = null;
    //    } else{
    //        pu.transform.parent = plyr.transform;
    //    }
    //}
}