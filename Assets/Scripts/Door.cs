using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public string triggerOpenName = "Open";
	public string triggerCloseName = "Close";

	Animator engineAnimator;

	// Use this for initialization
	void Awake () {
		engineAnimator = GetComponent<Animator>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		engineAnimator.SetTrigger(triggerOpenName);
	}
	
	void OnTriggerExit(Collider other)
	{
		engineAnimator.SetTrigger(triggerCloseName);
	}
}
