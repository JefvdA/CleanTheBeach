using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("MouseSettings")]
    [SerializeField] private float mouseSensitivity = 100f;
    
    [Header("RotationAxis")]
    [SerializeField] private bool rotateOnX;
    [SerializeField] private bool rotateOnY;

    [Header("ClampSettings")] 
    [SerializeField] private bool clampX;
    [SerializeField] private float maxVerticalAngle;

    private Vector2 _mouseRotation;
    private Vector2 _rotation;

    private void Start()
    {
        _rotation = Vector2.zero;
    }

    private void Update()
    {
        _mouseRotation = InputValuesManager.MouseRotation * (mouseSensitivity * Time.deltaTime);
        
        if (rotateOnX)
            _rotation.x -= _mouseRotation.y;
        if (rotateOnY)
            _rotation.y += _mouseRotation.x;

        if (clampX)
            _rotation.x = Mathf.Clamp(_rotation.x, -maxVerticalAngle, maxVerticalAngle);

        transform.localRotation = Quaternion.Euler(_rotation.x, _rotation.y, 0);
    }
}
