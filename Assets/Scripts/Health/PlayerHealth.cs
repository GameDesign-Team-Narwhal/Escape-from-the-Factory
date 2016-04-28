using UnityEngine;
using System.Collections;

public class PlayerHealth : HealthEntity {

	//called when the entity dies.  Default: destroy the GameObject
	protected override void OnDie()
	{
		//do nothing, for now
		Debug.LogWarning("Player died.");
	}
}
