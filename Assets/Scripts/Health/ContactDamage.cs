using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContactDamage : ObjectCounter {

	public string team = "Enemies";

	public float damageAmount;

	public bool continuousDamage = false;
	public float continuousDamagePeriod = 1; //sec

	private Dictionary<HealthEntity, float> damageCooldowns;

	public void OnTriggerEnter(Collider other)
	{
		HealthEntity healthEntity = other.GetComponent<HealthEntity>();
		if(healthEntity != null && !healthEntity.IsOnTeam(team))
		{
			healthEntity.Damage(damageAmount);

			if(continuousDamage)
			{
				damageCooldowns.Add(healthEntity, continuousDamagePeriod);
			}
		}


	}

	public static class EntityDamageSource : DamageSource
	{	
		public string GetName()
		{
			return "Contact Damage";
		}
	
	}
}
