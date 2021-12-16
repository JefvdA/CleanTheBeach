using System;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var moveInput = InputValuesManager.MoveDirection * moveSpeed;
        var moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        var targetVelocity = transform.TransformDirection(moveDirection) * moveSpeed;
        targetVelocity.y = _rb.velocity.y;
        _rb.velocity = targetVelocity;
        
        if (InputValuesManager.IsJumping && IsGrounded())
            _rb.AddForce(transform.up * jumpForce);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, groundLayer);
    }
}
