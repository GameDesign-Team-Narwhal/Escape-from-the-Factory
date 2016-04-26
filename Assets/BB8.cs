using UnityEngine;
using System.Collections;

public class BB8 : MonoBehaviour {
	public GameObject Leader;
	private Animator anim;		
	public float angleOffset = 0;
	public Rigidbody Body3D;
	public float Speed = 0;
	public bool NearTraget;	
	public float InRange = 0;

	// Use this for initialization
	void Awake () {
		Body3D = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		anim = GetComponent<Animator>();
	
	float X = Leader.transform.position.x;
	float Y = Leader.transform.position.z;
	float x = transform.position.x;
	float y = transform.position.z;
	
		Quaternion fullRotation = Quaternion.LookRotation(Leader.transform.position - transform.position);
		float swivelAngle = fullRotation.eulerAngles.y;

		swivelAngle += angleOffset;

		transform.rotation = Quaternion.Euler (0, swivelAngle, 0);
		if (X + InRange > x && X - InRange < x && Y + InRange > y && Y - InRange < y) {
			anim.SetBool("NearTraget", true);
		} else {
			anim.SetBool("NearTraget", false);
			Body3D.velocity += 0.01f*(VecFromAngleMagnitude(360-swivelAngle, Speed));
		}
	}
	public static Vector3 VecFromAngleMagnitude(float angle, float magnitude)
	{
		return new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle) * magnitude,0, Mathf.Sin(Mathf.Deg2Rad * angle) * magnitude);
	}
}
