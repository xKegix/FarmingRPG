using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // how fast movement.
    public float moveSpeed;

    // track of key pressed.
    private Vector2 moveInput;

    // true if pressing F key.
    private bool interactInput;

    // direction facing when interacting.
    private Vector2 facingDir;

    // which layer to interact with.
    public LayerMask interactLayerMask;

    public Rigidbody2D rig;
    public SpriteRenderer sr;

    void Update()
    {
        // set facing direction.
        if(moveInput.magnitude != 0.0f)
        {
            facingDir = moveInput.normalized;
            sr.flipX = (moveInput.x == 0) ? sr.flipX : moveInput.x > 0;
        }
    }
    // physics calculation.
    void FixedUpdate()
    {
        // setting velocity.
        rig.velocity = moveInput.normalized * moveSpeed;
    }

    // called wen pressing on movement key.
    public void OnMoveInput (InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // performign interact to true on frame.
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            interactInput = true;
        }
    }
}
