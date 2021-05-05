using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Gameplay controls;
    public delegate void InputVector2Event(Vector2 vector2);

    public static InputVector2Event MovementEvent;

    public delegate void InputBoolEvent(bool boolValue);
    public static InputBoolEvent JumpEvent;


    private void OnEnable()
    {
        controls = new Gameplay();
        controls.Enable();
        controls.Player.Move.performed += Movement;
        controls.Player.Move.canceled += StopMovement;

        controls.Player.Jump.performed += StartJump;
        controls.Player.Jump.canceled += StopJump;

    }


    private void OnDisable()
    {
        controls.Disable();
    }


    private void Movement(InputAction.CallbackContext ctxt)
    {
        Vector2 value = ctxt.ReadValue<Vector2>();
        MovementEvent?.Invoke(value);
    }

    private void StopMovement(InputAction.CallbackContext ctxt)
    {
        MovementEvent?.Invoke(Vector2.zero);

    }

    private void StartJump(InputAction.CallbackContext ctxt)
    {
        JumpEvent?.Invoke(true);
    }

    private void StopJump(InputAction.CallbackContext ctxt)
    {
        JumpEvent?.Invoke(false);
    }
}
