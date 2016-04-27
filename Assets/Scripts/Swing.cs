using UnityEngine;
using System.Collections;

public class Swing : MonoBehaviour {

	//weapons to disable when not swinging
	public GameObject[] weaponPrefabs;

	private KeyCode weaponSwitchR = KeyCode.C;
	private KeyCode weaponSwitchL = KeyCode.Z;

	private Animator anim;		// Reference to the animator component.
	private GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		anim = GetComponent<Animator>();
		if (Input.GetKey (KeyCode.E)) {
			Debug.Log("hi");
			anim.SetBool ("swing", true);
		} else {
			anim.SetBool ("swing", false);
		}
		if (Input.GetKey (KeyCode.Q)) {
			Debug.Log("hi");
			anim.SetBool ("swingK", true);
		} else {
			anim.SetBool ("swingK", false);
		}
	}
}
