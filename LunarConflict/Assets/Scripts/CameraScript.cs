using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    private Vector3 _cameraLookVector3;
    public void Update()
    {
        transform.position += _cameraLookVector3 * (cameraSpeed * Time.deltaTime);
    }

    public void MoveCamera(InputAction.CallbackContext context)
    {
        var vector = context.ReadValue<Vector2>();
        _cameraLookVector3 = new Vector3(vector.x, vector.y, 0);
    }
    
}
