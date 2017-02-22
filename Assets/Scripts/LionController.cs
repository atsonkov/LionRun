using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionController : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	public float playerJumpForce = 500f;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Jump")) {
			myRigidBody.AddForce (transform.up * playerJumpForce);
		}
	}
}
