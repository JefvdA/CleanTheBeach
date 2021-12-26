using UnityEngine;
// ReSharper disable Unity.InefficientPropertyAccess

public class PlayerMovement : MonoBehaviour
{
    private const float PlayerHeight = 2f;

    [SerializeField] private Transform orientation;

    [Header("Movement")] 
    public float moveSpeed = 6f;

    private const float MovementMultiplier = 10.0f;
    private const float AirMultiplier = 0.4f;

    [Header("Sprinting")] 
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float sprintSpeed = 6f;
    [SerializeField] private float acceleration = 10f;

    [Header("Jumping")] 
    public float jumpForce = 5f;

    private const float GroundDrag = 6f;
    private const float AirDrag = 2f;

    private float _horizontalMovement;
    private float _verticalMovement;

    [Header("Ground Detection")] 
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    public bool IsGrounded { get; private set; }
    private const float GroundDistance = 0.4f;

    private Vector3 _moveDirection;
    private Vector3 _slopeMoveDirection;

    private Rigidbody _rb;

    private RaycastHit _slopeHit;
    
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out _slopeHit, PlayerHeight / 2 + 0.5f))
        {
            return _slopeHit.normal != Vector3.up;
        }
        return false;
    }
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    private void Update()
    {
        IsGrounded = Physics.CheckSphere(groundCheck.position, GroundDistance, groundMask);

        MyInput();
        ControlDrag();
        ControlSpeed();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Jump();
        }

        _slopeMoveDirection = Vector3.ProjectOnPlane(_moveDirection, _slopeHit.normal);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        _verticalMovement = Input.GetAxisRaw("Vertical");

        _moveDirection = orientation.forward * _verticalMovement + orientation.right * _horizontalMovement;
    }

    private void MovePlayer()
    {
        switch (IsGrounded)
        {
            case true when !OnSlope():
                _rb.AddForce(_moveDirection.normalized * (moveSpeed * MovementMultiplier), ForceMode.Acceleration);
                break;
            case true when OnSlope():
                _rb.AddForce(_slopeMoveDirection.normalized * (moveSpeed * MovementMultiplier), ForceMode.Acceleration);
                break;
            default:
                _rb.AddForce(_moveDirection.normalized * (moveSpeed * MovementMultiplier * AirMultiplier), ForceMode.Acceleration);
                break;
        }
    }

    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ControlSpeed()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded)
            moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, acceleration * Time.deltaTime);
        else
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
    }

    private void ControlDrag()
    {
        _rb.drag = IsGrounded ? GroundDrag : AirDrag;
    }
}
