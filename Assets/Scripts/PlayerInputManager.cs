using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInput playerInput;
    public PlayerInput.OnFootMovementActions onFoot;
    private MovementManager motor;
    private PlayerLook look;


    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFootMovement;
        motor = GetComponent<MovementManager>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => motor.jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());

    }

    void LateUpdate()
    {
        // Debug.Log(onFoot.Look.ReadValue<Vector2>());
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
