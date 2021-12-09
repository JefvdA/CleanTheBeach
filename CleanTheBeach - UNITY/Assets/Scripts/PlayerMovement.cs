using System;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody _rb;
    private float rbDrag = 6f;

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

        _rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Acceleration);
    }

    private void ControlDrag()
    {
        _rb.drag = rbDrag;
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, groundLayer);
    }
}
