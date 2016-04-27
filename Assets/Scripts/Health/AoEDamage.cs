using UnityEngine;
using System.Collections.Generic;

public class AoEDamage : MonoBehaviour {

	public int damageAmount;
	public float damageRadius;

	public string team = "";

	AoEDamageSource damageSource;

	void Awake()
	{
		damageSource = new AoEDamageSource(this);
	}

	void DoDamage()
	{
		Collider[] foundColliders = Physics.OverlapSphere(transform.position, damageRadius);

		foreach(Collider collider in foundColliders)
		{
			List<IHealthEntity> healthEntities = Utils.GetBehaviorsWithInterface<IHealthEntity>(collider.gameObject);
			foreach(IHealthEntity entity in healthEntities)
			{
				entity.Damage(team, damageSource, damageAmount);
			}
		}
	}

	public class AoEDamageSource : DamageSource
	{
		AoEDamage damager;

		public AoEDamageSource(AoEDamage damager)
		{
			this.damager = damager;
		}

		public override string GetName()
		{
			return "AoE Damage - from " + damager.team;
		}
	
	} 
}
