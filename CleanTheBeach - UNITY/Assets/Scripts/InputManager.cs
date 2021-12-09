using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private void Start()
    {
        // Lock and hide cursor for First Person 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnMove(InputValue value)
    {
        var data = value.Get<Vector2>();
        InputValuesManager.MoveDirection = new Vector2(data.x, data.y);
    }
    
    private void OnLook(InputValue value)
    {
        var data = value.Get<Vector2>();
        InputValuesManager.MouseRotation = data;
    }

    private void OnJump(InputValue value)
    {
        print("Jump");
    }
}
