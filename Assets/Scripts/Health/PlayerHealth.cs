using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthEntity
{

    public RawImage healthbarRawImage;

    public Color highHealthColor = Color.green, medHealthColor = Color.yellow, lowHealthColor = Color.red;

    private float initialWidth, initialHeight, initialXPos;

    void UpdateHealthbar()
    {
        Color tintColor;

        //deal with negative health values (player is dead)
        uint clampedHealth = health < 0 ? 0 : (uint)health;
        float healthPercentage = ((float)clampedHealth) / maxHealth;
        if (healthPercentage >= .5)
        {
            tintColor = highHealthColor;
        }
        else if (healthPercentage >= .2)
        {
            tintColor = medHealthColor;
        }
        else
        {
            tintColor = lowHealthColor;
        }


        //calculate where to draw it
        Rect drawnPart = new Rect(0, 0, healthPercentage, 1);

        healthbarRawImage.uvRect = drawnPart;
        healthbarRawImage.color = tintColor;

        //now move and scale it to the right place
        Vector2 healthbarPos = healthbarRawImage.rectTransform.anchoredPosition;

        healthbarPos.x = initialXPos - ((initialWidth * (1 - healthPercentage)) / 2); //divide by 2 because it's anchored to the center

        healthbarRawImage.rectTransform.anchoredPosition = healthbarPos;

        healthbarRawImage.rectTransform.sizeDelta = new Vector2(healthPercentage * initialWidth, initialHeight);
    }

    //called when the entity dies.  Default: destroy the GameObject
    protected override void OnDie()
    {
        //do nothing, for now
        Debug.LogWarning("Player died.");
    }

    void Start()
    {
        //save initial values
        initialWidth = healthbarRawImage.rectTransform.sizeDelta.x;
        initialHeight = healthbarRawImage.rectTransform.sizeDelta.y;

        initialXPos = healthbarRawImage.rectTransform.anchoredPosition.x;

        UpdateHealthbar();
    }

    protected override void OnDamage(DamageSource source, int amount)
    {
        UpdateHealthbar();
    }
    protected override void OnHeal(int amount)
    {
        UpdateHealthbar();
    }
}
