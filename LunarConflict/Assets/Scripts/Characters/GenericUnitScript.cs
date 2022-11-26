using System;
using System.Collections;
using System.Collections.Generic;
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

    protected void Start() 
    {   
        _animator = GetComponent<Animator>();
        _animator.SetBool("play", true);
        
        speed = russian ? speed * -1 : speed;
        attackRange = russian ? attackRange * -1 : attackRange;
    }

    protected void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("walking") || _animator.GetCurrentAnimatorStateInfo(0).IsName("driving"))
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        _animator.SetBool("attackMode", CanAttack());
        
        _animator.SetBool("dying", health <= 0 ? true : false);
    }
    
    private bool CanAttack()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.right, attackRange);
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
        throw new NotImplementedException();
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
