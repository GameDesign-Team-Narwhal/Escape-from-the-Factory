using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealth : HealthEntity {

	public Color onDamageColor = Color.red;
	public float damageTintDuration = .5f;
	public bool showDamageEffect;
	
	List<Renderer> renderers;

	void Awake()
	{

		renderers = Utils.GetComponentsInChildren<Renderer>(gameObject);
		if(GetComponent<Renderer>() != null)
		{
			renderers.Add(GetComponent<Renderer>());
		}

	}

	protected override void OnDamage(DamageSource source, int amount)
	{
		if(showDamageEffect)
		{
			foreach(Renderer renderer in renderers)
			{
				if(renderer != null)
				{
					renderer.material.color = onDamageColor;
				}
			}

			StartCoroutine(setColorBackToNormal());
		}
	}

	IEnumerator setColorBackToNormal()
	{
		yield return new WaitForSeconds(damageTintDuration);
		foreach(Renderer renderer in renderers)
		{
			if(renderer != null)
			{
				renderer.material.color = Color.white;
			}
		}

		yield break;
	}
}
