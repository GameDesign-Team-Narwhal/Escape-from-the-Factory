using UnityEngine;
using System.Collections;

public class MouseOrbitCamera : MonoBehaviour {

	public GameObject toOrbit;

	//side-to-side distance that the camera can turn
	public Vector2 mouseSpeed = Vector2.one;
	public float scrollSpeed = 1;

	public Vector2 verticalRotationBounds = new Vector2(-70, 70);


	public float radius = 3;
	public Vector2 radiusBounds = new Vector2(1.5f, 10);

	private Vector3 initialOffset;
	
	float hAngle, vAngle;


	// Use this for initialization
	void Start () {
		hAngle = 0;
		vAngle = 0;

		initialOffset = transform.position - toOrbit.transform.position;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		hAngle += mouseSpeed.x * Input.GetAxis("Mouse X");
		vAngle += mouseSpeed.y * Input.GetAxis("Mouse Y");

		vAngle = Mathf.Clamp (vAngle, verticalRotationBounds.x, verticalRotationBounds.y);

		radius += -1 * scrollSpeed * Input.GetAxis ("Scroll Wheel");
		radius = Mathf.Clamp (radius, radiusBounds.x, radiusBounds.y);

		Vector3 newCamPosition = toOrbit.transform.position;

		//convert from 3D polar coordinates to cartesian
		newCamPosition.x += Mathf.Sin(Mathf.Deg2Rad * hAngle) * Mathf.Cos(Mathf.Deg2Rad * vAngle) * -1 * radius;
		newCamPosition.y += radius * Mathf.Sin (Mathf.Deg2Rad * vAngle);
		newCamPosition.z += Mathf.Cos(Mathf.Deg2Rad * hAngle) * Mathf.Cos(Mathf.Deg2Rad * vAngle) * -1 * radius;

		newCamPosition += initialOffset;

		transform.position = newCamPosition;

		transform.rotation = Quaternion.LookRotation((toOrbit.transform.position + initialOffset)  - transform.position);
	}
}
