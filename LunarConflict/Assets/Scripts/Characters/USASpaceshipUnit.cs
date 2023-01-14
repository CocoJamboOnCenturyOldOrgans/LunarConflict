using System.Collections;
using UnityEngine;
using static SettingsScript;

public class USASpaceshipUnit : GenericUnitScript
{
    private Rigidbody2D _rb;
    private BoxCollider2D _col;
    private SpriteRenderer _renderer;
    private bool _destroyed;

    [SerializeField] private Transform bombParent;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField, Range(2.0f, 10.0f)] private float retreatSpeed;
    [SerializeField, Range(1.0f, 5.0f)] private float camouflageSpeed;

    protected override void Start()
    {
        base.Start();
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    protected void FixedUpdate()
    {
        if (_destroyed)
            transform.Translate(Vector3.right * (speed * retreatSpeed * Time.deltaTime));
    }

    public void DropBomb()
    {
        Instantiate(
            bombPrefab, 
            bombParent.position, 
            unitFaction == PlayerFaction.USA ? Quaternion.Euler(0,0,-90) : Quaternion.Euler(0,0,90));
    }

    public void Escape()
    {
        StartCoroutine(StartEscaping());
    }

    private IEnumerator StartEscaping()
    {
        yield return null;

        _rb.bodyType = RigidbodyType2D.Kinematic;
        _col.isTrigger = true;
        _destroyed = true;

        while (_renderer.color.a > 0)
        {
            _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, _renderer.color.a - camouflageSpeed * Time.deltaTime);
            yield return null;
        }
        
        OnDeath();
    }
}
