using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_MovementManager : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;

    public CharacterController controller01;
    public CharacterController controller02;
    protected PlayerActionsExample playerInput;
    private Vector3 playerVelocity;

    private void Awake()
    {
        playerInput = new PlayerActionsExample();
    }

    private void Update()
    {
        Vector2 movement01 = playerInput.Player.Move_P01.ReadValue<Vector2>();
        Vector2 movement02 = playerInput.Player.Move_P02.ReadValue<Vector2>();
        Vector3 move01 = new Vector3(movement01.x, movement01.y, 0.0f);
        Vector3 move02 = new Vector3(movement02.x, movement02.y, 0.0f);
        controller01.Move(100 * playerSpeed * Time.deltaTime * move01);
        controller02.Move(100 * playerSpeed * Time.deltaTime * move02);

        if (move01 != Vector3.zero)
        {
            controller01.transform.forward = move01;
            controller01.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if (move02 != Vector3.zero)
        {
            controller02.transform.forward = move02;
            controller02.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        controller01.Move(playerVelocity * Time.deltaTime);
        controller02.Move(playerVelocity * Time.deltaTime);
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}