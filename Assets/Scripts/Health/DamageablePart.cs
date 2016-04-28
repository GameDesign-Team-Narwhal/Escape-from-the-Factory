using UnityEngine;
using System.Collections;

// Script to put on sub-objects of damageable entities so that damage to them can be transmitted to the main entity
public class DamageablePart : MonoBehaviour, IHealthEntity {

	public GameObject mainEntity;

	private HealthEntity _healthEntity;

	private HealthEntity healthEntity
	{
		get
		{
			return _healthEntity;
		}
	}

	// Use this for initialization
	void Awake () 
	{
		_healthEntity = mainEntity.GetComponent<HealthEntity>();
		if(healthEntity == null)
		{
			Debug.LogError("DamageablePart: entity does not have health");
		}
        else
        {
            _healthEntity.RegisterSubpart(this);
        }
	}

	//damage the entity by amount.  Does no damage if the provided team is the same as the entity's.
	public void Damage(string damagerTeam, DamageSource source, int amount)
	{
		_healthEntity.Damage(damagerTeam, source, amount);
	}
	
	// Heal the entity by amount.
	public void Heal(int amount)
	{
		_healthEntity.Heal(amount);
	}

	public IHealthEntity GetParent()
	{
		return _healthEntity;
	}

	public bool IsAlive()
	{
		return _healthEntity.IsAlive();
	}

	public GameObject GetGameObject()
	{
		return mainEntity;
	}

}
