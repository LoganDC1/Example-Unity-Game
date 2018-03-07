using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public string toPrintClass = "Well what country is this, the United Arab Emirates? There's lots of sweaty cameltoe and everyone's a terrorist.";
	public float speed = 5;

	// Use this for initialization
	void Start () {
		string toPrint = "We are here to drink your beer, and steal your rum at the point of a gun. Your alcohol to us will fall, cos' we are here to drink your beer. Drink!";
		Debug.Log (toPrintClass);
		string returned1 = TestFunction ("This is just a test message, please ingore this.", 42);
		string returned2 = TestFunction ("This is just a test message, please ingore this.", 73);
		Debug.Log ("returned1 = " + returned1);
		Debug.Log ("returned2 = " + returned2);
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D ourRigidBody = GetComponent<Rigidbody2D> ();
		ourRigidBody.velocity = Vector2.right * speed;
	}

	string TestFunction(string message, int count) {
		Debug.Log (message + " " + count);

		return "Return of the String";
	}
}