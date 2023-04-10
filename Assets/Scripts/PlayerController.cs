using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    [Header("Referencia")]
    [SerializeField] Camera playerCamera;

    [Header("General")]
    [SerializeField] private float gravityScale;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 1.9f;

    [Header("Rotarion")]
    [SerializeField] private float rotationsens = 10f;


    [Header("Movement")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprint;

    private float cameraVertical;
    Vector3 moveInput = Vector3.zero;
    Vector3 rotacionInput = Vector3.zero;
    CharacterController charactercontroller;

    private void Awake()
    {
        charactercontroller = GetComponent<CharacterController>();
    }


    private void Update()
    {
        Move();
        Look();
    }


    private void Move()
    {
        if (charactercontroller.isGrounded)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);
            

            if (Input.GetButton("Sprint"))
            {
                moveInput = transform.TransformDirection(moveInput) * sprint;
            }
            else
            {
                moveInput = transform.TransformDirection(moveInput) * walkSpeed;
            }

            if (Input.GetButtonDown("Jump"))
            {
                moveInput.y = Mathf.Sqrt(jumpForce * -2f * gravityScale);
            }
        }

        moveInput.y += gravityScale * Time.deltaTime;

        charactercontroller.Move(moveInput * Time.deltaTime);
    }

    private void Look()
    {
        rotacionInput.x = Input.GetAxis("Mouse X") * rotationsens * Time.deltaTime;
        rotacionInput.y = Input.GetAxis("Mouse Y") * rotationsens * Time.deltaTime;

        cameraVertical = cameraVertical + rotacionInput.y;
        cameraVertical = Mathf.Clamp(cameraVertical, -70, 70);

        transform.Rotate(Vector3.up * rotacionInput.x);
        playerCamera.transform.localRotation = Quaternion.Euler(-cameraVertical, 0f, 0f);
    }



}
