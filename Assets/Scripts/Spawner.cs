using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject [] prefabs;
	float delay = 2.0f;
	public bool active = true;
	
	public Vector2 delayRange = new Vector2 (1, 2);
	
	// Use this for initialization
	void Start () {
		ResetDelay ();
		StartCoroutine(EnemyGenerator() );
	}
	
    public void SpawnOne()
    {
        GameObject spawned = GameObject.Instantiate(prefabs[Random.Range(0, prefabs.Length)]); 
		spawned.transform.position = transform.position;
    }

    IEnumerator EnemyGenerator(){
		
		yield return new WaitForSeconds (delay);
		
		if (active) {

            SpawnOne();
			ResetDelay();
			
		}
		
		StartCoroutine(EnemyGenerator() );
		
	}
	
	void ResetDelay(){
		delay = Random.Range (delayRange.x, delayRange.y);
	}
	
	
	
}