using System;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float airMultiplier = 0.4f;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody _rb;
    private float groundDrag = 6f;
    private float airDrag = 1f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ControlDrag();
    }

    private void FixedUpdate()
    {
        var moveInput = InputValuesManager.MoveDirection * moveSpeed;
        var moveDirection = moveInput.x * transform.right + moveInput.y * transform.forward;

        if(IsGrounded())
            _rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Acceleration);
        else
            _rb.AddForce(moveDirection.normalized * (moveSpeed * airMultiplier), ForceMode.Acceleration);
        
        if(InputValuesManager.IsJumping && IsGrounded())
            _rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
        
    }

    private void ControlDrag()
    {
        if (IsGrounded())
            _rb.drag = groundDrag;
        else
            _rb.drag = airDrag;
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, groundLayer);
    }
}
