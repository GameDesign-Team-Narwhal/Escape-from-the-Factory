using UnityEngine;
using System.Collections;

/**
 * Makes an object move in a circle with constant velocity
 * */
public class CurvedConveyorBelt : ObjectCounter {

	public float constantVelocity;
	
	public Vector3 center;
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject obj in objectsInTrigger)
		{
			Rigidbody body = obj.GetComponent<Rigidbody>();
			
			if(body != null)
			{
				PolarVec2 polarVelocity = PolarVec2.FromCartesian(body.velocity.x, body.velocity.z);

				Vector3 deltaPos = obj.transform.position - center;
				PolarVec2 polarDeltaPos = PolarVec2.FromCartesian(deltaPos.x, deltaPos.z);

				//velocity is always tangential to dir to the center
				polarDeltaPos.A -= 90 * Mathf.Sign(polarDeltaPos.A);
				
				body.velocity = polarDeltaPos.Cartesian3DHorizontal.normalized * constantVelocity;
			}
		}
	}
}
