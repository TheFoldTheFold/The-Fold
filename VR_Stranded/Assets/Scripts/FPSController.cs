using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {

	public float speed = 2f;
	public float sensitivity = 2f;
	CharacterController player;
    public GameObject pu;

	public GameObject cam;

	float moveFB;
	float moveLR;

	float rotX;
	float rotY;
	float vertVelocity;

	public float jumpDist;
	private int jumpTimes;

    private float run;
    private bool move;
    public bool canInteract;

	// Use this for initialization
	void Start () {
        move = true;
		player = GetComponent<CharacterController> ();
        canInteract = false;

	}
	
	// Update is called once per frame
	void Update () {
		moveFB = Input.GetAxis ("Vertical") * speed;
		moveLR = Input.GetAxis ("Horizontal") * speed;

		rotX = Input.GetAxis ("Mouse X") * sensitivity;
		rotY -= Input.GetAxis ("Mouse Y") * sensitivity;

        if (canInteract == true && Input.GetButton("Interact")) {
            move = false;
            transform.LookAt(pu.transform);
            interaction();
        }
        else if (move == true) {
            movement();
        } 
	}

	void FixedUpdate(){
		if (player.isGrounded == false) {
			vertVelocity += Physics.gravity.y * Time.deltaTime;
		} else {
			vertVelocity = 0f;
		}
	}
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "PickUp") {
            canInteract = true;
            pu = col.gameObject;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "PickUp") {
            canInteract = false;
        }
    }
    void movement()
    {
        rotY = Mathf.Clamp(rotY, -60f, 60f);

        Vector3 movement = new Vector3(moveLR, vertVelocity, moveFB);
        transform.Rotate(0, rotX, 0);
        cam.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);

        float triggerAxis = Input.GetAxis("Triggers");  // left trigger = -1; right trigger = 1;
        print(triggerAxis);

        if (player.isGrounded == true)
        {    // enable gravity
            jumpTimes = 0;
        }
        if (jumpTimes < 1)
        {                // jump once
            if (Input.GetButtonDown("Jump"))
            {
                vertVelocity += jumpDist;
                jumpTimes += 1;
            }
        }
        if (Input.GetButton("Run") || Input.GetAxis("Triggers") < -0.5)
        {   // running
            speed = 7f;
        }
        else
        {  // walking speed
            speed = 3f;
        }
    }
    void interaction() {
        pu.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
    }
}