using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invintory1 : MonoBehaviour 
{
    [SerializeField]
    public bool InvintorySlot1Full = false;

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
            if (other.gameObject.tag == "StackBlock" && InvintorySlot1Full == false)
            {
                InvintorySlot1Full = true;
            }
            else 
            {
                InvintorySlot1Full = false;
            }
        }
    }
}
