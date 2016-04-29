using UnityEngine;
using System.Collections;

/**
 * Makes an object move in a circle with constant velocity
 * */
public class CurvedConveyorBelt : ObjectCounter {

	public float constantVelocity;
	
	public Vector3 center;

    public GameObject CenterIndicator;
	
	// Update is called once per frame
	void Update () {

        CenterIndicator.transform.position = center;
		foreach(GameObject obj in objectsInTrigger)
		{
			Rigidbody body = obj.GetComponent<Rigidbody>();
			
			if(body != null)
			{

				Vector3 deltaPos = obj.transform.position - center;
				PolarVec2 polarDeltaPos = PolarVec2.FromCartesian(deltaPos.x, deltaPos.z);

				//velocity is always tangential to dir to the center
				polarDeltaPos.A += 90 * Mathf.Sign(polarDeltaPos.A);
				
				body.velocity = polarDeltaPos.Cartesian3DHorizontal.normalized * constantVelocity;

                //Debug.Log("new velocity: " + polarDeltaPos.Cartesian3DHorizontal.normalized.ToString() + ", polar: " + polarDeltaPos.ToString());
			}
		}
	}
}
