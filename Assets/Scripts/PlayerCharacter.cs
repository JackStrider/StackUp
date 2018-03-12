using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCharacter : MonoBehaviour {

    #region serialzed fields
    [SerializeField]
    private float moveSpeed = 10;

    [SerializeField]
    private int debugPlayerNumberOverride = 0;
    #endregion

    #region private felds
    private Rigidbody rigidbody;
    private Text playerNumberLabel;
    private Player controllingPlayer_UseProperty;
    #endregion

    #region public properties 
    //Which player controls the characyer?
    //We will use the Player.PlayerNumber. to
    //decide which GamePad to look at.

        public Player ControllingPlayer
    {
        get { return controllingPlayer_UseProperty; }
        set
        {
            controllingPlayer_UseProperty = value;
            UpdatePlayerIndexLabel();
        }
    }
    #endregion

    #region private propeties
    private float HorizontalInput
    {
        get { return Input.GetAxis(HorizontalInputName); }
    }

    private float VerticalInput
    {
        get { return Input.GetAxis(VerticalInputName); }
    }

    private float FireInput
    {
        get { return Input.GetAxis(FireInputName); }
    }

    private float JumpInput
    {
        get { return Input.GetAxis(JumpInputName); }
    }

    // You must configure the Unity Input Manager
    // to have an axis for each control for each supported player.
    // Begin numbering at 1, as Unity numbers "joysticks" beginning at 1.
    // "Joystick" means gamepad in real life...

    private string HorizontalInputName
    {
        get
        {
            return "Horizontal" + ControllingPlayer.PlayerNumber;
        }
    }

    private string VerticalInputName
    {
        get
        {
            return "Vertical" + ControllingPlayer.PlayerNumber;
        }
    }

    private string FireInputName
    {
        get
        {
            return "Fire" + ControllingPlayer.PlayerNumber;
        }
    }

    private string JumpInputName
    {
        get
        {
            return "Jump" + ControllingPlayer.PlayerNumber;
        }
    }
    #endregion

    private void UpdatePlayerIndexLabel()
    {
        playerNumberLabel.text = ("Player:" + ControllingPlayer.PlayerNumber.ToString());
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerNumberLabel = GetComponentInChildren<Text>();

#if UNITY_EDITOR
        if (debugPlayerNumberOverride > 0)
        {
            ControllingPlayer = new Player(debugPlayerNumberOverride);
        }
#endif
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var moveDirection = new Vector3(VerticalInput, JumpInput, HorizontalInput);
        rigidbody.velocity = moveDirection * moveSpeed;
    }
}