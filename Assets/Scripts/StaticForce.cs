using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/**
 * Script to exert a force on any rigidbodies which hit the object's trigger(s)
 **/
public class StaticForce : ObjectCounter {

	public Vector3 force = Vector3.left;
	

	void Update()
	{
		foreach(GameObject obj in objectsInTrigger)
		{
			Rigidbody body = obj.GetComponent<Rigidbody>();

			if(body != null)
			{
				body.AddForce(force);
			}
		}
	}

}
