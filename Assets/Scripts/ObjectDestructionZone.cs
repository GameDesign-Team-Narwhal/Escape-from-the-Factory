using UnityEngine;
using System.Collections.Generic;

public class ObjectDestructionZone : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        GameObject.Destroy(collider.gameObject);
    }
}
