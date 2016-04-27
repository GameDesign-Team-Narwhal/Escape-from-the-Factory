using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContactDamage : MonoBehaviour {

	public string team = "Enemies";

	public int damageAmount;
	public bool continuousDamage;
	public bool initialDamage;
	public float continuousDamagePeriod; //sec

	public Dictionary<IHealthEntity, uint> entitiesInsideCount = new Dictionary<IHealthEntity, uint>();
	public Dictionary<IHealthEntity, float> nextDamageTimes = new Dictionary<IHealthEntity, float>();


	private ContactDamageSource damageSource;

	public float knockback = 0;

	void Awake()
	{
		damageSource = new ContactDamageSource();
	}

	public void OnTriggerEnter(Collider collider)
	{

		IHealthEntity healthEntity = Utils.GetBehaviorWithInterface<IHealthEntity>(collider.gameObject);
		if(healthEntity != null)
		{

			IHealthEntity parent = healthEntity.GetParent();

			IHealthEntity entityToReferTo = parent == null ? healthEntity : parent; 

			if(entitiesInsideCount.ContainsKey(entityToReferTo))
			{
				//already inside
				uint prevCount = entitiesInsideCount[entityToReferTo];
				entitiesInsideCount[entityToReferTo] = prevCount + 1;
			}
			else
			{

				entitiesInsideCount.Add(entityToReferTo, 1);

				if(continuousDamage)
				{
					nextDamageTimes.Add(entityToReferTo, Time.time + continuousDamagePeriod);
				}
			}

			if(initialDamage)
			{
				healthEntity.Damage(team, damageSource, damageAmount);

					
				DealKnockback(collider.attachedRigidbody);
			}
		}


	}

	/**
	 * 
	 * Deals knockback to a rigidbody according to how the class is set.
	 * Does nothing if the rigidbody is null.
	*/
	void DealKnockback(Rigidbody body)
	{
		//knockback
		if(body != null)
		{
			Vector3 deltaPos = body.gameObject.transform.position - transform.position;
			Vector3 knockbackImpulse = deltaPos.normalized * knockback;
			
			body.AddForce(knockbackImpulse, ForceMode.Impulse);
		}
	}

	void FixedUpdate()
	{
		//apparently modifying a dictionary while iterating through it is an unsolved proplem in c#
		Dictionary<IHealthEntity, float> newDamageTimes = new Dictionary<IHealthEntity, float>(nextDamageTimes);

		foreach(KeyValuePair<IHealthEntity, float> entityTime in nextDamageTimes)
		{

			if(entityTime.Value < Time.time)
			{
				entityTime.Key.Damage(team, damageSource, damageAmount);
				DealKnockback(entityTime.Key.GetGameObject().GetComponent<Rigidbody>());
				newDamageTimes[entityTime.Key] = Time.time + continuousDamagePeriod;
			}
			if(!entityTime.Key.IsAlive())
			{
				newDamageTimes.Remove(entityTime.Key);
				entitiesInsideCount.Remove(entityTime.Key);
			}

		}

		nextDamageTimes = newDamageTimes;

		//Debug.Log("counts: " + Utils.DictionaryToString(entitiesInsideCount) + " times: " + Utils.DictionaryToString(nextDamageTimes));
	}

	public void OnTriggerExit(Collider collider)
	{

		IHealthEntity healthEntity = Utils.GetBehaviorWithInterface<IHealthEntity>(collider.gameObject);
		if(healthEntity != null)
		{
			IHealthEntity parent = healthEntity.GetParent();
			
			IHealthEntity entityToReferTo = parent == null ? healthEntity : parent; 
			
			if(entitiesInsideCount.ContainsKey(entityToReferTo))
			{
				//already inside
				uint prevCount = entitiesInsideCount[entityToReferTo];
				prevCount -= 1;
				if(prevCount == 0)
				{
					//all of the parts of the entity are out of the area, remove them.
					entitiesInsideCount.Remove(entityToReferTo);
					nextDamageTimes.Remove(entityToReferTo);
				}
				else
				{
					entitiesInsideCount[entityToReferTo] = prevCount;
				}
			}
			
		}
		
	}


	public class ContactDamageSource : DamageSource
	{	

		public override string GetName()
		{
			return "Contact Damage";
		}
	
	}
}
