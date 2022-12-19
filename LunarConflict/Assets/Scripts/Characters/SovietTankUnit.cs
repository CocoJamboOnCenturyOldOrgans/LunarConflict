using System.Collections;
using UnityEngine;

public class SovietTankUnit : GenericUnitScript
{
    private Rigidbody2D _rb;
    private BoxCollider2D _col;
    private bool _destroyed;

    [SerializeField] private Transform missileParent1, missileParent2;
    [SerializeField] private GameObject missilePrefab;
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

    public void ShootWithBullets() => Shoot();

    public void ShootWithMissiles()
    {
        Instantiate(
            missilePrefab, 
            missileParent1.position, 
            russian ? Quaternion.Euler(0,0,90) : Quaternion.Euler(0,0,-90));
        
        Instantiate(
            missilePrefab, 
            missileParent2.position, 
            russian ? Quaternion.Euler(0,0,90) : Quaternion.Euler(0,0,-90));
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
