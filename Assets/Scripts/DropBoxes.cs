using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBoxes : MonoBehaviour 
{

    public GameObject boxInventoryLocation1;
    public GameObject boxInventoryLocation2;
    public GameObject boxInventoryLocation3;


    private Player controllingPlayer;

    private string FireInputName
    {
        get
        {
            return "Fire" + controllingPlayer.PlayerNumber;
        }
    }

    private void Start()
    {
        controllingPlayer = GetComponentInParent<PlayerCharacter>().ControllingPlayer;
    }
}
