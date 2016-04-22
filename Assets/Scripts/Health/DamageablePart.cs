using UnityEngine;
using System.Collections;

// Script to put on sub-objects of damageable entities so that damage to them can be transmitted to the main entity
public class DamageablePart : MonoBehaviour {

	public GameObject mainEntity;

	private HealthEntity healthEntity
	{
		get
		{
			return healthEntity;
		}
	}

	// Use this for initialization
	void Start () 
	{
		healthEntity = mainEntity.GetComponent<HealthEntity>();
		if(healthEntity == null)
		{
			Debug.LogError("DamageablePart: entity does not have health");
		}
	}
}
