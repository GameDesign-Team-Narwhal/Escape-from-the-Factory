using UnityEngine;
using System.Collections;

/**
 * Makes an object move in a circle with constant velocity
 * */
public class CurvedConveyorBelt : ObjectCounter {

	public float constantVelocity;
	
	public Vector3 center;

    public GameObject CenterIndicator;

	public bool reverseDir = false;

	// Update is called once per frame
	void Update () {
		base.Update();
		CenterIndicator.transform.position = transform.TransformPoint(center);
		foreach(GameObject obj in objectsInTrigger)
		{
			if(obj != null)
			{
				Rigidbody body = obj.GetComponent<Rigidbody>();
				
				if(body != null)
				{

					Vector3 deltaPos = obj.transform.position - transform.TransformPoint(center);
					PolarVec2 polarDeltaPos = PolarVec2.FromCartesian(deltaPos.x, deltaPos.z);

					//velocity is always tangential to dir to the center
					polarDeltaPos.A += (reverseDir ? 1 : -1) * 90 * Mathf.Sign(polarDeltaPos.A);
					
					body.velocity = -(polarDeltaPos.Cartesian3DHorizontal.normalized * constantVelocity);

	               //Debug.Log(/*"deltaPos: " + deltaPos + */" new velocity: " + polarDeltaPos.Cartesian3DHorizontal.ToString() + ", polar: " + polarDeltaPos.ToString());
				}
			}
		}
	}
}
