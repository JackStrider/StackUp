using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBoxes : MonoBehaviour
{
    private Player controllingPlayer;
    private string FireInputName
    {
        get
        {
            return "Fire" + controllingPlayer.PlayerNumber;
        }
    }

    private GameObject blockHeld = null;

    private void Start()
    {
        controllingPlayer = GetComponentInParent<PlayerCharacter>().ControllingPlayer;
    }

    private void Update()
    {
        //if (Input.GetButtonDown(FireInputName) && blockHeld != null)
        //{
        //    blockHeld.transform.SetParent(null);
        //    blockHeld = null;
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "StackBlock")
        //blockHeld == null &&
        {
            if (Input.GetButtonDown(FireInputName))
            {
                other.transform.SetParent(transform.parent);
                blockHeld = other.gameObject;
            }
        }
    }
}