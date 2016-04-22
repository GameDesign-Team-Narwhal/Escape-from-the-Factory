using UnityEngine;
using System.Collections;

public class NotifyAnimationOnPlayerNearby : MonoBehaviour {


	public GameObject player;
	public string animationBoolName = "Run";

	Animator engineAnimator;
	int triggerNameHash;

	// Use this for initialization
	void Awake () {
		engineAnimator = GetComponent<Animator>();

		triggerNameHash = Animator.StringToHash (animationBoolName);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.Equals (player)) {
			engineAnimator.SetBool(triggerNameHash, true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.Equals (player)) {
			engineAnimator.SetBool(triggerNameHash, false);
		}
	}
}
