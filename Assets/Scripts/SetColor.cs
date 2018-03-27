using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour {

    private Player controllingPlayer;

    private void Start()
    {
        controllingPlayer = GetComponentInParent<PlayerCharacter>().ControllingPlayer;

        //switch (controllingPlayer.ToString)
        //{

        //}
    }
}
