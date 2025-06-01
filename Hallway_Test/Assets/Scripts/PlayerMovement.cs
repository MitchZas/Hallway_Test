using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls playerControls;

    [SerializeField] CharacterController controller;
    [SerializeField] float walkSpeed = 10f;

    Vector3 moveInput;

    void Start()
    {
        playerControls = new PlayerControls();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * walkSpeed * Time.deltaTime);
    }

    void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector3>();
    }

}
