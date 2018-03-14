using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 5;
	public float health = 100;
	public float invulnerableDuration = 1;

	private float invulnerableEndTime = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D ourRigidBody = GetComponent<Rigidbody2D> ();
		ourRigidBody.velocity = Vector2.right * speed;
	}

	public void Damage(float damageToDeal) {

		if (Time.time >= invulnerableEndTime) {
			// Reducing health by the damage passed in

			health = health - damageToDeal;

			// TODO: handle death

			// Set us as invulnerable for a set duration
			invulnerableEndTime = Time.time + invulnerableDuration;

			// Log the result of the function
			Debug.Log("Damage was dealt");
			Debug.Log ("damageToDeal = " + damageToDeal);
			Debug.Log("health = " +health);
		}
	}
}