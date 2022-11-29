using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenericUnitScript : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int attackRange;
    [SerializeField] protected bool russian;
    [SerializeField] protected bool attackMode = false;
    [SerializeField] protected int unitCost;
    [SerializeField] protected Transform bulletParent;
    [SerializeField] protected GameObject bulletPrefab;
    
    private Animator _animator;
    private LayerMask _mask;
    private Vector2 _movementDirection;
    private float _localScaleX;

    protected void Start() 
    {   
        _animator = GetComponent<Animator>();
        _mask = LayerMask.GetMask("Unit");
        _animator.SetBool("play", true);

        _movementDirection = russian ? Vector2.left : Vector2.right;
        _localScaleX = transform.localScale.x;
        speed = russian ? speed * -1 : speed;
    }

    protected void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("walking") ||
            _animator.GetCurrentAnimatorStateInfo(0).IsName("driving"))
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        _animator.SetBool("attackMode", CanAttack());
        _animator.SetBool("play", CanWalk());
        _animator.SetBool("dying", health <= 0 ? true : false);
    }
    
    private bool CanAttack()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(
            transform.position, 
            _movementDirection,
            attackRange, 
            _mask);
        foreach (var x in hit)
        {
            if (x.collider.CompareTag(russian ? "PlayerUnit" : "EnemyUnit") && x.collider.gameObject != gameObject)
            {
                return true;
            }
        }

        return false;
    }
    
    private bool CanWalk()
    {
        LayerMask mask = LayerMask.GetMask("Unit");
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position, 
            _movementDirection, 
            _localScaleX, 
            _mask);
        return hit.collider.IsUnityNull();
    }
    
    public void Shoot()
    {
        Instantiate(
            bulletPrefab, 
            bulletParent.position, 
            (russian ? Quaternion.Euler(0,0,90) : Quaternion.Euler(0,0,-90)));
    }
    
    protected void Death()
    {
        Destroy(gameObject);
    }
    
    public void GotHit(int damage) => health -= damage;
}
