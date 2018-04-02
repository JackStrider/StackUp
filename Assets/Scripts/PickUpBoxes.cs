using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBoxes : MonoBehaviour
{
    private Player controllingPlayer;
    public GameObject boxInventoryLocation1;
    public GameObject boxInventoryLocation2;
    public GameObject boxInventoryLocation3;
    private int blocksHeld = 0;

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

    void FixedUpdate()
    {
        if (blocksHeld > 3)
        {
            blocksHeld = 3;
        }

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
            print("There is something in front of the object!");
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown(FireInputName))
        {
            if (other.gameObject.tag == "StackBlock")
            {
                if (blocksHeld <= 2)
                {
                    other.transform.SetParent(transform.parent);
                    other.GetComponent<Rigidbody>().isKinematic = true;
                    blocksHeld++;
                    switch (blocksHeld)
                    {
                        case 1:
                            other.transform.parent = boxInventoryLocation1.transform;
                            other.transform.localPosition = Vector3.zero;
                            other.transform.localScale /= 4;
                            other.transform.Rotate(0, 0, 0);
                            break;
                        case 2:
                            other.transform.parent = boxInventoryLocation2.transform;
                            other.transform.localPosition = Vector3.zero;
                            other.transform.localScale /= 4;
                            other.transform.Rotate(0, 0, 0);
                            break;
                        case 3:
                            other.transform.parent = boxInventoryLocation3.transform;
                            other.transform.localPosition = Vector3.zero;
                            other.transform.localScale /= 4;
                            other.transform.Rotate(0, 0, 0);
                            break;

                    }
                }
            }
        }
    }
}