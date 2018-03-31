using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {
    //The base of this script is from Lurony
    //on youtube. Video here: https://www.youtube.com/watch?v=_Xrw2EEhzI4

    public Transform spawnPoint;
    public Rigidbody PrefabBlue;
    public Rigidbody PrefabRed;
    public Rigidbody PrefabGreen;
    public Rigidbody PrefabPurple;
    private Player controllingPlayer;

    void OnTriggerEnter ()
    {
        controllingPlayer = GetComponentInParent<PlayerCharacter>().ControllingPlayer;

        Rigidbody RidgidPrefab;

        if (controllingPlayer.PlayerNumber == 1)
        {
        RidgidPrefab = Instantiate(PrefabBlue, spawnPoint.position, spawnPoint.rotation);
        }
        if (controllingPlayer.PlayerNumber == 2)
        {
            RidgidPrefab = Instantiate(PrefabRed, spawnPoint.position, spawnPoint.rotation);
        }
        if (controllingPlayer.PlayerNumber == 3)
        {
            RidgidPrefab = Instantiate(PrefabGreen, spawnPoint.position, spawnPoint.rotation);
        }
        if (controllingPlayer.PlayerNumber == 4)
        {
            RidgidPrefab = Instantiate(PrefabPurple, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
