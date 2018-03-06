using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {
    //Got part of this script from Lurony
    //On youtube. Video here: https://www.youtube.com/watch?v=_Xrw2EEhzI4

    public Transform spawnPoint; 
    public Rigidbody Prefab;

    // Use this for initialization
    void OnTriggerEnter ()
    {
        Rigidbody RidgidPrefab;
        RidgidPrefab = Instantiate(Prefab, spawnPoint.position, spawnPoint.rotation);
	}
}
