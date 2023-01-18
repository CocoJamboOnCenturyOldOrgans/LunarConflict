using UnityEngine;
using UnityEngine.InputSystem;
using static SettingsScript;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Sprite[] Backgrounds = new Sprite[3];
    private SpriteRenderer BackgroundImage;

    private void Start()
    {
        transform.Rotate(Vector3.up, Faction == PlayerFaction.USA ? 0 : 180);
        transform.position = new Vector3(transform.position.x, transform.position.y, Faction == PlayerFaction.USA ? -1 : 1);
        BackgroundImage = GameObject.Find("SpaceBackGround").GetComponent<SpriteRenderer>();
        BackgroundImage.sprite = Backgrounds[Random.Range(0, 3)];
    }

    [SerializeField] private float cameraSpeed;
    private Vector3 _cameraLookVector3;
    public void Update()
    {
        transform.position += _cameraLookVector3 * (cameraSpeed * Time.deltaTime);
    }

    public void MoveCamera(InputAction.CallbackContext context)
    {
        var vector = context.ReadValue<Vector2>();
        _cameraLookVector3 = new Vector3(Faction == PlayerFaction.USA ? vector.x : -vector.x, vector.y, 0);
    }
    
}
