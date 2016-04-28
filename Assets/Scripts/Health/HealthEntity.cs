using UnityEngine;
using System.Collections.Generic;

public abstract class HealthEntity : MonoBehaviour, IHealthEntity {

	//the team that the entity is on.  Damage won't affect entities on the same team as the damage source.
	//if set to empty string, teams are disabled and all dmage will hit
	public string team = "Enemies";
	
	//Maximum health that the entity has
	public int maxHealth = 10;
	public int health = 10;


	HashSet<DamageSource> damagesThisFrame = new HashSet<DamageSource>();

    protected HashSet<DamageablePart> subParts = new HashSet<DamageablePart>();

	//returns true if the entity is on the team provided
	public bool IsOnTeam(string teamToCheck)
	{
		if(team.Equals("") || teamToCheck.Equals(""))
		{
			return false;
		}

		return team.Equals(teamToCheck);
	}

	public void Damage(string damagerTeam, DamageSource source, int amount)
	{
		
		if(IsOnTeam(damagerTeam) || damagesThisFrame.Contains(source))
		{
			return;
		}

		Debug.Log("Damaged " + amount + " by " + source.GetName() + " on team " + damagerTeam);


		OnDamage(source, amount);
		health -= amount;

		if(!IsAlive ())
		{
			OnDie ();
		}
	}

	public void Heal(int amount)
	{
		health += amount;
		OnHeal(amount);
	}

	void LateUpdate()
	{
		//reset 
		damagesThisFrame.Clear();
	}

	//Use this to insert your own damage actions 
	protected virtual void OnDamage(DamageSource source, int amount) {}
	protected virtual void OnHeal(int amount){}

	//called when the entity dies.  Default: destroy the GameObject
	protected virtual void OnDie()
	{
		GameObject.Destroy(gameObject);

        foreach(DamageablePart part in subParts)
        {
            GameObject.Destroy(part);
        }
	}
	
	public IHealthEntity GetParent()
	{
		return null;
	}

	public bool IsAlive()
	{
		return health > 0;
	}

	public GameObject GetGameObject()
	{
		return gameObject;
	}

    //called by DamageableParts to let the main entity know they exist
    public void RegisterSubpart(DamageablePart part)
    {
        subParts.Add(part);
    }

}
