using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 10f, jumpVelocity = 10f;
	public LayerMask playerMask;
	public bool canMoveInAir = true;
	Transform myTransform, tagGround;
	Rigidbody2D myBody;
	bool isGrounded = false;
	float hInput = 0f;

	private void Start()
	{
		myBody = GetComponent<Rigidbody2D>();
		myTransform = transform;
		tagGround = GameObject.Find(this.name + "/tag_ground").transform;
	}

	void FixedUpdate()
	{
		isGrounded = Physics2D.Linecast(myTransform.position, tagGround.position, playerMask);

		#if !UNITY_ANDRIOD && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT
		Move(Input.GetAxisRaw("Horizontal"));
		if (Input.GetButtonDown("Jump"))
		{
			Debug.Log("Jump()");
			Jump();
		}
		#else
		Move(hInput);
		#endif
	}

	void Move(float horizontalInput) 
	{
		if (!canMoveInAir && !isGrounded)
			return;

		Vector2 moveVel = myBody.velocity;
		moveVel.x = horizontalInput * speed;
		myBody.velocity = moveVel;
	}

	public void Jump()
	{
		if (isGrounded)
			myBody.velocity += jumpVelocity * Vector2.up;
	}

	public void StartMove(float horizontalInput) 
	{
		hInput = horizontalInput;
	}
}
