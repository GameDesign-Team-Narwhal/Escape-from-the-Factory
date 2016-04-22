using UnityEngine;
using System.Collections;

public abstract class HealthEntity : MonoBehaviour {

	//the team that the entity is on.  Damage won't affect entities on the same team as the damage source.
	//if set to empty string, teams are disable and all
	public string team = "Enemies";
	
	//Maximum health that the entity has
	public int maxHealth = 10;
	public int health = 10;

	public bool showDamageEffect;



	//returns true if the entity is on the team provided
	public bool IsOnTeam(string teamToCheck)
	{
		if(team.Equals("") || teamToCheck.Equals(""))
		{
			return false;
		}

		return team.Equals(teamToCheck)
	}

	public void Damage(DamageSource source, int amount)
	{
		OnDamage(source, amount);
		health -= amount;

		if(health <= 0)
		{
			OnDie ()
		}
	}

	public void Heal(int amount)
	{
		health += amount;
		OnHeal(amount);
	}

	//Use this to insert your own damage actions 
	protected void OnDamage(DamageSource source, int amount) {}
	protected void OnHeal(int amount){}

	//called when the entity dies.  Default: destroy the GameObject
	protected void OnDie()
	{
		GameObject.Destroy(gameObject);
	}

	public static class EntityDamageSource : DamageSource
	{
		public HealthEntity source
		{
			get
			{
				return source;
			}
		}

		
		public string GetName()
		{
			return "Entity - " + source.gameObject.name;
		}
		
	}


}
