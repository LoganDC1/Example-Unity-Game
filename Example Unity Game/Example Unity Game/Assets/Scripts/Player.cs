using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 5;
	public float jumpSpeed = 10;
	public float health = 100;
	public float invulnerableDuration = 1;
	public float blinkDuration = 0.5f;
	public int allowedAirJumps = 0;

	private float invulnerableEndTime = 0;
	private float blinkEndTime = 0;
	//private bool hasDoubleJumped = false;
	private int numAirJumps = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D ourRigidBody = GetComponent<Rigidbody2D> ();

		float horizontal = Input.GetAxis ("Horizontal");

		Vector2 velocity = ourRigidBody.velocity;

		velocity.x = horizontal * speed;

		// get a reference to our animator
		Animator ourAnimator = GetComponent<Animator>();

		// determine what animator speed variable should be set to
		float animatorSpeed = Mathf.Abs(velocity.x);

		// set this value on the animator
		ourAnimator.SetFloat("speed", animatorSpeed);

		Collider2D ourCollider = GetComponent<Collider2D> ();

		LayerMask groundLayer = LayerMask.GetMask ("Ground");

		bool isTouchingGround = ourCollider.IsTouchingLayers (groundLayer);

		// Set touchingGround parameter on the animator
		ourAnimator.SetBool("touchingGround", isTouchingGround);

		if (isTouchingGround == true) {
			numAirJumps = 0;
		}

		bool allowedToJump = isTouchingGround;

		if (isTouchingGround == false && numAirJumps < allowedAirJumps) {
			allowedToJump = true;
		}

		bool jumpPressed = Input.GetButtonDown ("Jump");

		if (jumpPressed == true && allowedToJump == true) {
			velocity.y = jumpSpeed;

			if (isTouchingGround == false) {
				numAirJumps = numAirJumps + 1;
			}
		}

		ourRigidBody.velocity = velocity;

		// Handle blinking while invulnerable:

		// Get our sprite renderer component attached to this object
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();

		renderer.flipX = velocity.x < 0;

		// Are we done being invulnerable?
		if (Time.time >= invulnerableEndTime) {
			// if NOT invulnerable...

			// Set the renderer to enabled.
			renderer.enabled = true;
		} else {
			// If YES invulnerable...

			// If it is time to blink...
			if (Time.time >= blinkEndTime) {
				// set our renderer enabled value to the opposite of what it currently is (toggle it)
				renderer.enabled = !renderer.enabled;
				// Set the next time we should blink to our current time plus the blink duration
				blinkEndTime = Time.time + blinkDuration;
			} // end if (Time.time >= blinkEndTime)
		} // end if (Time.time >= invulnerableEndTime)

//		if (Input.GetMouseButtonDown (0) == true) {
//			Debug.Log ("Mouse left button just pressed down");
//		}
//		if (Input.GetMouseButton (0) == true) {
//			Debug.Log ("Mouse left button held");
//		}
//		if (Input.GetMouseButtonUp (0) == true) {
//			Debug.Log ("Mouse left button just released");
//		}
//		if (Input.GetMouseButtonDown (1) == true) {
//			Debug.Log ("Mouse right button just pressed down");
//		}

	} // end Update()

	public void Damage(float damageToDeal)
	{
		if (Time.time >= invulnerableEndTime) {

			// Reducing health by the damage passed in
			health = health - damageToDeal;

			// TODO: handle death

			// Set us as invulnerable for a set duration
			invulnerableEndTime = Time.time + invulnerableDuration;

			// Log the result of the function
			Debug.Log("Damage was dealt");
			Debug.Log("damageToDeal = "+damageToDeal);
			Debug.Log("health = "+health);
		}
	} // end Damage()
}
