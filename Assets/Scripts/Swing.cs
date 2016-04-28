using UnityEngine;
using System.Collections;

public class Swing : MonoBehaviour {

	//weapons to disable when not swinging
	public GameObject lhandKatar;
    public GameObject rhandSword;


	private Animator anim;		// Reference to the animator component.
	private GameObject player;

    void Awake()
    {
        anim = GetComponent<Animator>();

        SetWeaponEnabled(lhandKatar, false);
        SetWeaponEnabled(rhandSword, false);

    }

    //this is to stop swords from doing damage even if you don't swing them
    void SetWeaponEnabled(GameObject weapon, bool enabled)
    {
        foreach(Collider collider in weapon.GetComponents<Collider>())
        {
            if(collider.isTrigger)
            {
                collider.enabled = enabled;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
		if (Input.GetKeyDown(KeyCode.E))
        {
			anim.SetTrigger("swingR");
            SetWeaponEnabled(rhandSword, true);
			StartCoroutine(disableWeaponAfterAnim(rhandSword));
		} 

		if (Input.GetKeyDown(KeyCode.Q))
        {
			anim.SetTrigger("swingL");
            SetWeaponEnabled(lhandKatar, true);
			StartCoroutine(disableWeaponAfterAnim(lhandKatar));
        }
    }

    IEnumerator disableWeaponAfterAnim(GameObject weapon)
    {
        yield return Utils.WaitForAnimation(anim);
        SetWeaponEnabled(weapon, false);

        yield break;
    }
}
