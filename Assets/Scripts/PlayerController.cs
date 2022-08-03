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

        // when true run interact tile fucntion and reset interact to false.
        if(interactInput)
        {
            TryInteractTile();
            interactInput = false;
        }
    }
    // physics calculation.
    void FixedUpdate()
    {
        // setting velocity.
        rig.velocity = moveInput.normalized * moveSpeed;
    }

    void TryInteractTile()
    {
        // where to aim and recive hit data.
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + facingDir, Vector3.up, 0.1f, interactLayerMask);

        // check to see hit something.
        if(hit.collider != null)
        {
            // check 'something' is component attached with FieldTile and assign to type FieldTile varaible.
            FieldTile tile = hit.collider.GetComponent<FieldTile>();
            // interact with that object.
            tile.Interact();
        }
    }

    // called wen pressing on movement key.
    public void OnMoveInput (InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // performing interact to true on frame.
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            interactInput = true;
        }
    }
}
