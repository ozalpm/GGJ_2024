using System;
using System.Collections;
using System.Collections.Generic;
using CubeEngine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

[Header("Movement")]
public float moveSpeed;
public float groundDrag;
public float jumpForce;
public float airMultiplier;


[Header("Keybinds")]
public KeyCode jumpKey = KeyCode.Space;

[Header("Ground Check")]
public float playerHeight;
public LayerMask whatIsGround;
public bool grounded;


float horizontalInput;
float verticalInput;

Vector3 moveDirection;

Rigidbody rb;
public GameObject cameraObject;

private Camera mainCam;
[Header("AI NPC")]
private RaycastHit npcHit;

private Transform oldNpc;
private Transform newNpc;

private bool isLookingNpc;
public LayerMask npcLayerMask;
public float npcRange;
public Transform phoneObject;
public Transform phoneRotTransform;
public Transform phoneLostFocusTransform;
public bool isTalking;

public static PlayerController Init;

private void Awake()
{
    Init = this;
}

private void Start()
{
    rb = GetComponent<Rigidbody>();
    rb.freezeRotation = true;
    Cursor.lockState = CursorLockMode.Locked;
    mainCam = Camera.main;
}

private void Update()
{
    if (isTalking)
    { return; }
    
    // ground check
    grounded = Physics.Raycast(transform.position+Vector3.up, Vector3.down,playerHeight, whatIsGround);
    isLookingNpc=Physics.Raycast(mainCam.transform.position, mainCam.transform.forward,out npcHit,npcRange, npcLayerMask);

    if (isLookingNpc)
    {
        newNpc = npcHit.transform;
        if (oldNpc!=newNpc)
        {
            oldNpc = newNpc;
        }
        OnFocusNpc(newNpc);
    }
    else
    {
        if (!isTalking)
        {
            OnLostFocusNpc();
        }
    }
    MyInput();
    SpeedControl();

    // handle drag
    if (grounded)
        rb.drag = groundDrag;
    else
        rb.drag = 0;
    
    transform.rotation=
        Quaternion.Euler(transform.eulerAngles.x,
            transform.eulerAngles.y+Input.GetAxis("Mouse X"),
            transform.eulerAngles.z);
    cameraObject.transform.rotation=
        Quaternion.Euler(cameraObject.transform.eulerAngles.x-Input.GetAxis("Mouse Y"),
            cameraObject.transform.eulerAngles.y,
            cameraObject.transform.eulerAngles.z);
    rb.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
}
private void FixedUpdate()
{
    MovePlayer();
}
private void MyInput()
{
    horizontalInput = Input.GetAxisRaw("Horizontal");
    verticalInput = Input.GetAxisRaw("Vertical");

    // when to jump
    if(Input.GetKeyDown(jumpKey) && grounded)
    {
        Jump();
    }
}
private void MovePlayer()
{
    // calculate movement direction
    moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

    
    // on ground
    if(grounded)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

    // in air
    else if(!grounded)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    
}
private void SpeedControl()
{
    Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

    // limit velocity if needed
    if(flatVel.magnitude > moveSpeed)
    {
        Vector3 limitedVel = flatVel.normalized * moveSpeed;
        rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
    }
}
private void Jump()
{
    // reset y velocity
    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
}


public void OnFocusNpc(Transform targetTransform)
{
    phoneRotTransform.LookAt(targetTransform);
    phoneObject.rotation=Quaternion.Lerp(phoneObject.rotation,phoneRotTransform.rotation,0.01f);
    if (Input.GetKeyDown(KeyCode.Return))
    {
        isTalking = true;
        UI_Manager.Init.OpenQuestionsPanel(targetTransform.GetComponent<Npc>());
        Cursor.lockState = CursorLockMode.None;
        Phone.Init.RecordStart();
    }
    else
    {
        UI_Manager.Init.OpenInfoPanel(targetTransform.GetComponent<Npc>());
    }
}

public void OnLostFocusNpc()
{
    phoneRotTransform.LookAt(phoneLostFocusTransform);
    phoneObject.rotation=Quaternion.Lerp(phoneObject.rotation,phoneRotTransform.rotation,0.01f);
    UI_Manager.Init.CloseInfoPanel();
}

public void MakeTheJoke(QuestionsReaction reaction)
{
    newNpc.GetComponent<Npc>().GetJoke(reaction);
    Cursor.lockState = CursorLockMode.Locked;
    Phone.Init.RecordEnd();
}

public void TalkingIsEnd()
{
    isTalking = false;
    Cursor.lockState = CursorLockMode.Locked;
}

}
