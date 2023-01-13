using UnityEngine;
using UnityEngine.InputSystem;
using static SettingsScript;

public class CameraScript : MonoBehaviour
{
    private void Start()
    {
        transform.Rotate(Vector3.up, Faction == PlayerFaction.USA ? 0 : 180);
        transform.position = new Vector3(transform.position.x, transform.position.y, Faction == PlayerFaction.USA ? -10 : 10);
    }

    [SerializeField] private float cameraSpeed;
    private Vector3 _cameraLookVector3;
    public void Update()
    {
        transform.position += (Faction == PlayerFaction.USA ? _cameraLookVector3 : -_cameraLookVector3) * (cameraSpeed * Time.deltaTime);
    }

    public void MoveCamera(InputAction.CallbackContext context)
    {
        var vector = context.ReadValue<Vector2>();
        _cameraLookVector3 = new Vector3(vector.x, vector.y, 0);
    }
    
}
