using UnityEngine;
using System.Collections;

public class Propeller : MonoBehaviour {

	Rigidbody body;

	public Vector3 direction = Vector3.left;


	// Use this for initialization
	void Awake () {
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		body.angularVelocity = direction;
	}
}
