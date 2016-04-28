using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealth : HealthEntity {

	public Color onDamageColor = Color.red;
	public float damageTintDuration = .5f;
	public bool showDamageEffect;
	
	List<Renderer> renderers;

	Dictionary<Renderer, Color> rendererInitialColors = new Dictionary<Renderer, Color>();

    //we need to initialize after all of the DamageableParts have been added to the list in the HealthEntity
    //which happens in Awake()
	void Start()
	{

		renderers = Utils.GetComponentsInChildren<Renderer>(gameObject);
		if(GetComponent<Renderer>() != null)
		{
			renderers.Add(GetComponent<Renderer>());
		}

        foreach(DamageablePart part in subParts)
        {
            Renderer partRenderer = part.GetComponent<Renderer>();
            if(partRenderer != null)
            {
                renderers.Add(partRenderer);
            }
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
					if(!rendererInitialColors.ContainsKey(renderer))
					{
						rendererInitialColors.Add(renderer, renderer.material.color);
					}
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
				if(rendererInitialColors.ContainsKey(renderer))
				{
					renderer.material.color = rendererInitialColors[renderer];
				}
			}
		}

		rendererInitialColors.Clear();

		yield break;
	}
}
