using System.Collections;
using UnityEngine;

public class SovietTankUnit : GenericUnitScript
{
    private Rigidbody2D _rb;
    private BoxCollider2D _col;
    private bool _destroyed;

    [SerializeField, Range(2.0f, 10.0f)] private float retreatSpeed;

    protected override void Start()
    {
        base.Start();
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (_destroyed)
            transform.Translate(-Vector3.right * (speed * retreatSpeed * Time.deltaTime));
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
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_destroyed && col.gameObject.GetComponent<GenericBaseScript>() != null)
            OnDeath();
    }
}
