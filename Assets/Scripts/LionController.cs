using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using UnityEngine.UI;

public class LionController : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private Collider2D myCollider;
	private Animator myAnim;
	public float playerJumpForce = 500f;
	private float playerHurtTime = -1;
	public Text scoreText;
	private float startTime;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent <Rigidbody2D> ();
		myAnim = GetComponent <Animator> ();
		myCollider = GetComponent <BoxCollider2D> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHurtTime == -1) {
			if (Input.GetButtonUp ("Jump") || Input.GetMouseButtonDown (0)) {
				myRigidBody.AddForce (transform.up * playerJumpForce);
			}
			myAnim.SetFloat ("vVelocity", myRigidBody.velocity.y);
			scoreText.text = (Time.time - startTime).ToString("0.0");
		} else if (playerHurtTime + 2 < Time.time){
			//Application.LoadLevel (Application.loadedLevel);
			SceneManager.LoadScene("Game", LoadSceneMode.Single);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			foreach (MoveLeft moveLefter in FindObjectsOfType <MoveLeft>()){
				moveLefter.enabled = false;
			}
			foreach (PrefabSpawner prefabSpawn in FindObjectsOfType <PrefabSpawner>()){
				prefabSpawn.enabled = false;
			}
			playerHurtTime = Time.time;
			myAnim.SetBool ("playerHurt", true);
			myRigidBody.velocity = Vector2.zero;
			myRigidBody.AddForce (transform.up * playerJumpForce);
			myCollider.enabled = false;
		}
	}
}
