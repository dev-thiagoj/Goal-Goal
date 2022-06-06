using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_MovementManager : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;

    public Rigidbody2D player1Rb;
    public Rigidbody2D player02Rb;

    protected PlayerActionsExample playerInput;

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
        player1Rb.transform.Translate(100 * playerSpeed * Time.deltaTime * move01);
        player02Rb.transform.Translate(100 * playerSpeed * Time.deltaTime * move02);

        if (move01 != Vector3.zero)
        {
            player1Rb.transform.forward = move01;
            player1Rb.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if (move02 != Vector3.zero)
        {
            player02Rb.transform.forward = move02;
            player02Rb.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
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