using UnityEngine;
using System.Collections;

public class ConveyorBelt : ObjectCounter {

	public Vector3 constantVelocity;

	public bool horizontal, vertical;

	// Update is called once per frame
	void Update () {
		foreach(GameObject obj in objectsInTrigger)
		{
			if(obj != null)
			{
				Rigidbody body = obj.GetComponent<Rigidbody>();
				
				if(body != null)
				{
					Vector3 newVelocity = body.velocity;

					if(horizontal)
					{
						newVelocity.x = constantVelocity.x;
						newVelocity.z = constantVelocity.z;
					}
					if(vertical)
					{
						newVelocity.y = constantVelocity.y;
					}

					body.velocity = newVelocity;
				}
			}
		}
	}
}
