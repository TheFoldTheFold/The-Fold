using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public bool isClimbing;
    public bool rotate;
    private Vector3 offset;
    private GameObject player;

    void Start() {
        player = GameObject.Find("Player");
        isClimbing = false;
    }

    void Update() {
        if (isClimbing && Input.GetKeyDown("w")) {
            Debug.Log("moving up\n");
            player.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        }
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject == player) {
            //player.transform.parent = transform;
            player.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, player.transform.position.z);
            offset = player.transform.position;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            isClimbing = true;
        }
    }
}