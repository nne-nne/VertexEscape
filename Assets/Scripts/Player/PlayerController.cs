using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpForce;
    [SerializeField] private float walkSpeed;
    //[SerializeField] private float runSpeed; - does anybody want to implement running?
    [SerializeField] private float lookSpeed;
    [SerializeField] private float lookLimitX;


    private CharacterController characterController;
    private Vector3 movement;
    private Vector3 forward;
    private Vector3 right;
    private Vector2 walkingInput;
    private float xRotation = 0f;
    private float yMovement = 0f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        forward = transform.forward;
        right = transform.right;
    }

    void Update()
    {
        ManageInput();
        ApplyGravity();

        if(characterController.isGrounded)
        {
            forward = transform.forward;
            right = transform.right;
        }
        movement = forward * walkingInput.y + right * walkingInput.x;
        movement.y = yMovement;
        characterController.Move(movement * Time.deltaTime);
    }

    private void ManageInput()
    {
        // walking
        walkingInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * walkSpeed;

        // jumping
        if(Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            yMovement = jumpForce;
        }

        //rotating
        ManageRotating();
    }

    private void ApplyGravity()
    {
        if(!characterController.isGrounded)
        {
            yMovement -= gravity * Time.deltaTime;
        }
    }

    private void ManageRotating()
    {
        xRotation += -Input.GetAxis("Mouse Y") * lookSpeed;
        xRotation = Mathf.Clamp(xRotation, -lookLimitX, lookLimitX);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
