using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invintory3 : MonoBehaviour 
{
    [SerializeField]
    public bool InvintorySlot3Full = false;

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
            if (other.gameObject.tag == "StackBlock" && InvintorySlot3Full == false)
            {
                InvintorySlot3Full = true;
            }
            else
            {
                InvintorySlot3Full = false;
            }
        }
    }
}
