using System.Collections;
using UnityEngine;

public class USATankUnit : GenericUnitScript
{
    private Rigidbody2D _rb;
    private BoxCollider2D _col;
    private bool _destroyed;

    [SerializeField] private Transform bulletParent2;
    [SerializeField] private Transform missileParent;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField, Range(2.0f, 10.0f)] private float retreatSpeed;

    protected override void Start()
    {
        base.Start();
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
    }

    protected void FixedUpdate()
    {
        if (_destroyed)
            transform.Translate(-Vector3.right * (speed * retreatSpeed * Time.deltaTime));
    }

    public void ShootBulletFirstCannon() => Shoot();
    
    public void ShootBulletSecondCannon() => Shoot(bulletParent2);

    public void ShootWithMissiles()
    {
        Instantiate(
            missilePrefab, 
            missileParent.position, 
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
