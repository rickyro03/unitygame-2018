using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector3 jump;
	public float jumpForce = 2.0f;
	public float speed = 1.0f;
	public Collider2D Platform1;
	public Collider2D Platform2;
	public Collider2D Platform3;
	
	
	Rigidbody2D rb;
	private bool isGrounded;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		jump = new Vector3(0.0f, 1.0f, 0.0f);
	}
	
	void OnCollisionStay2D(Collision2D col)
	{
		isGrounded = true;
		Debug.Log("GroundedStay");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			isGrounded = false;
			rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
			Debug.Log("UnGrounded");
		}
		var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;



	}
}
