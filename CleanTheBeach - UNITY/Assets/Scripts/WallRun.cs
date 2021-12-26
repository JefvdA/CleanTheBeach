using UnityEngine;

public class WallRun : MonoBehaviour
{
    [SerializeField] private Transform orientation;

    [Header("Movement")] 
    [SerializeField] private PlayerMovement playerMovement;

    [Header("Detection")]
    [SerializeField] private float wallDistance = .5f;
    [SerializeField] private float minimumJumpHeight = 1.5f;

    [Header("Wall Running")] 
    [SerializeField] private float wallRunGravity;
    [SerializeField] private float wallRunJumpForce;

    [Header("Camera")] 
    [SerializeField] private Camera cam;
    [SerializeField] private float fov;
    [SerializeField] private float wallRunFov;
    [SerializeField] private float wallRunFovTime;
    [SerializeField] private float camTilt;
    [SerializeField] private float camTiltTime;

    public float Tilt { get; private set; }

    private bool _wallLeft;
    private bool _wallRight;

    private RaycastHit _leftWallHit;
    private RaycastHit _rightWallHit;

    private Rigidbody _rb;

    private bool CanWallRun()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minimumJumpHeight) && !playerMovement.IsGrounded;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckWall();

        if (CanWallRun())
        {
            if (_wallLeft)
            {
                StartWallRun();
            }
            else if (_wallRight)
            {
                StartWallRun();
            }
            else
            {
                StopWallRun();
            }
        }
        else
        {
            StopWallRun();
        }
    }

    private void StartWallRun()
    {
        _rb.useGravity = false;
        _rb.AddForce(Vector3.down * wallRunGravity, ForceMode.Force);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, wallRunFov, wallRunFovTime * Time.deltaTime);

        if (_wallLeft)
            Tilt = Mathf.Lerp(Tilt, -camTilt, camTiltTime * Time.deltaTime);
        else if(_wallRight)
            Tilt = Mathf.Lerp(Tilt, camTilt, camTiltTime * Time.deltaTime);

        if (!Input.GetKeyDown(KeyCode.Space)) return; // When player didn't press space, return cause we don't want to jump
        
        // Jumping
        if (_wallLeft)
        {
            var wallRunJumpDirection = transform.up + _leftWallHit.normal;
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            _rb.AddForce(wallRunJumpDirection * (wallRunJumpForce * 100), ForceMode.Force);
        }
        else if (_wallRight)
        {
            var wallRunJumpDirection = transform.up + _rightWallHit.normal;
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            _rb.AddForce(wallRunJumpDirection * (wallRunJumpForce * 100), ForceMode.Force);
        }
    }

    private void StopWallRun()
    {
        _rb.useGravity = true;
        
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, wallRunFovTime * Time.deltaTime);
        Tilt = Mathf.Lerp(Tilt, 0, camTiltTime * Time.deltaTime);
    }

    private void CheckWall()
    {
        _wallLeft = Physics.Raycast(transform.position, -orientation.right, out _leftWallHit, wallDistance);
        _wallRight = Physics.Raycast(transform.position, orientation.right, out _rightWallHit, wallDistance);
    }
}
