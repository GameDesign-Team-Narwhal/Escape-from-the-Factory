using UnityEngine;
using System.Collections;

public class LookAtObject : MonoBehaviour {
	public GameObject objectToLookAt;
	public float angleOffset;

	private float initialXEuler;

	void Start()
	{
		initialXEuler = transform.rotation.eulerAngles.x;
	}

	// Update is called once per frame
	void Update () {
		Quaternion fullRotation = Quaternion.LookRotation (transform.position - objectToLookAt.transform.position);

		Vector3 swivelEuler = fullRotation.eulerAngles;
		swivelEuler.x = initialXEuler;
		swivelEuler.y += angleOffset;

		transform.rotation = Quaternion.Euler (swivelEuler);

	}
}
