using UnityEngine;
using System.Collections;

/**
 * Script to fix the position of the object it is applied to relative to another object.
 * */
public class RelativePositionConstraint : MonoBehaviour {

	public GameObject other;

	private Vector3 relativePosition;

	// Use this for initialization
	void Start () {
		relativePosition = transform.position - other.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = other.transform.position + relativePosition;
	}
}
