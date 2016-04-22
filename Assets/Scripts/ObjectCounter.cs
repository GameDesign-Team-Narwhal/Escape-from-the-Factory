using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public abstract class ObjectCounter : MonoBehaviour {
	
	protected List<GameObject> objectsInTrigger = new List<GameObject>();

	void OnTriggerEnter(Collider otherCollider)
	{
		objectsInTrigger.Add (otherCollider.gameObject);

		OnObjectEnter (otherCollider.gameObject);
	}

	void OnTriggerExit(Collider otherCollider)
	{
		objectsInTrigger.Remove (otherCollider.gameObject);

		OnObjectExit (otherCollider.gameObject);

	}

	void OnObjectEnter(GameObject obj){}

	void OnObjectExit(GameObject obj){}
}
