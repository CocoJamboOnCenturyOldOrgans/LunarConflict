using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static SettingsScript;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private List<Sprite> backgrounds = new List<Sprite>();
    private SpriteRenderer _backgroundMinimap;
    private SpriteRenderer _backgroundMainCamera;

    private void Start()
    {
        transform.Rotate(Vector3.up, Faction == PlayerFaction.USA ? 0 : 180);
        transform.position = new Vector3(transform.position.x, transform.position.y, Faction == PlayerFaction.USA ? -10 : 10);
        _backgroundMinimap = GameObject.Find("BackgroundMinimap").GetComponent<SpriteRenderer>();
        _backgroundMainCamera = GameObject.Find("BackgroundMainCamera").GetComponent<SpriteRenderer>();
        _backgroundMinimap.sprite = backgrounds[Random.Range(0, backgrounds.Count)];
        _backgroundMainCamera.sprite = _backgroundMinimap.sprite;
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
