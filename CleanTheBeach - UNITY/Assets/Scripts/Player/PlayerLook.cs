using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private WallRun wallrun;
    
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] private Transform cam;
    [SerializeField] private Transform orientation;

    private float _mouseX;
    private float _mouseY;

    private const float Multiplier = 0.01f;

    private float _xRotation;
    private float _yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        MyInput();
        
        cam.localRotation = Quaternion.Euler(_xRotation, _yRotation, wallrun.Tilt);
        orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
    }

    private void MyInput()
    {
        _mouseX = Input.GetAxisRaw("Mouse X");
        _mouseY = Input.GetAxisRaw("Mouse Y");

        _yRotation += _mouseX * sensX * Multiplier;
        _xRotation -= _mouseY * sensY * Multiplier;

        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
    }
}