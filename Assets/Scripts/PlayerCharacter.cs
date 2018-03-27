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

    [SerializeField]
    public float jumpForce = 2.0f;
    #endregion

    #region private felds
    private Rigidbody rigidbody;
    private Text playerNumberLabel;
    private Player controllingPlayer_UseProperty;
    private string blocksHoldingVisual;
    #endregion

    #region public properties 
    //Which player controls the characyer?
    //We will use the Player.PlayerNumber. to
    //decide which GamePad to look at.

    public Vector3 jump;

    public bool isGrounded;

    public Player ControllingPlayer
    {
        get { return controllingPlayer_UseProperty; }
        set
        {
            controllingPlayer_UseProperty = value;
            //UpdatePlayerIndexLabel();
        }
    }
    #endregion

    #region private propeties
    private float HorizontalInput
    {
        get
        {
            float input = Input.GetAxis(HorizontalInputName);
            if (Mathf.Abs(input) < 0.42f)
            {
                input = 0;
            }
            return input;
        }
    }

    private float VerticalInput
    {
        get
        {
            float input = Input.GetAxis(VerticalInputName);
            if (Mathf.Abs(input) < 0.42f)
            {
                input = 0;
            }
            return input;
        }
    }

    private float FireInput
    {
        get { return Input.GetAxis(FireInputName); }
    }

    private float JumpInput
    {
        get { return Input.GetAxis(JumpInputName); }
    }

    private float AimVertical
    {
        get { return Input.GetAxis(AimVerticalInputName); }
    }

    private float AimHorizontal
    {
        get { return Input.GetAxis(AimHorizontalInputName); }
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

    private string AimHorizontalInputName
    {
        get
        {
            return "AimHorizontal" + ControllingPlayer.PlayerNumber;
        }
    }

    private string VerticalInputName
    {
        get
        {
            return "Vertical" + ControllingPlayer.PlayerNumber;
        }
    }

    private string AimVerticalInputName
    {
        get
        {
            return "AimVertical" + ControllingPlayer.PlayerNumber;
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

    //private void UpdatePlayerIndexLabel()
    //{
    //    playerNumberLabel.text = (blocksHoldingVisual);
    //}

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

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    private void FixedUpdate()
    {
        Move();

        if (Input.GetButtonDown(JumpInputName) && isGrounded == true)
        {
            rigidbody.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnButtonDown(Collider other)
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
            Debug.DrawRay(transform.position - new Vector3(-1,2,0), fwd, Color.green);

        RaycastHit ray = new RaycastHit();

        if (Physics.Raycast(transform.position - new Vector3(-1, 2, 0), fwd, 1))
        {
            if (other.gameObject.tag == "StackBlock")
            print("There is something in front of the object!");
        }
    }

    private void Move()
    {

        var moveDirection = new Vector3(VerticalInput * moveSpeed, rigidbody.velocity.y, HorizontalInput * moveSpeed);
        rigidbody.velocity = moveDirection;
        if (VerticalInput != 0 || HorizontalInput != 0)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        Vector3 rotation = new Vector3(0, transform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(rotation);

        Debug.Log("Vertical input: " + VerticalInput);
        Debug.Log("Horizontal input: " + HorizontalInput);
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }
}