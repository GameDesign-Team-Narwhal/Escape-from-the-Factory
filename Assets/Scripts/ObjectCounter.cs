using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public abstract class ObjectCounter : MonoBehaviour {
	
	protected HashSet<GameObject> objectsInTrigger = new HashSet<GameObject>();

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

	public void Update()
	{
		if(objectsInTrigger.Contains(null))
		{
			objectsInTrigger.Remove(null);
			Debug.Log ("Removed null?!?");
		}
	}

	void OnObjectEnter(GameObject obj){}

	void OnObjectExit(GameObject obj){}
}
