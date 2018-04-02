using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invintory2 : MonoBehaviour 
{
    [SerializeField]
    public bool InvintorySlot2Full = false;

    private Player controllingPlayer;

    private void Start()
    {
        controllingPlayer = GetComponentInParent<PlayerCharacter>().ControllingPlayer;
    }

    private string FireInputName
    {
        get
        {
            return "Fire" + controllingPlayer.PlayerNumber;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown(FireInputName))
        {
            if (other.gameObject.tag == "StackBlock" && InvintorySlot2Full == false)
            {
                InvintorySlot2Full = true;
            }
            else
            {
                InvintorySlot2Full = false;
            }
        }
    }
}
