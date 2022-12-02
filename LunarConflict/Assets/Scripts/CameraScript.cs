using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    public void MoveCamera(InputAction.CallbackContext context)
    {
        var vector = context.ReadValue<Vector2>();
        transform.position += new Vector3(vector.x, vector.y, 0);
        Debug.Log(vector);
    }
}
