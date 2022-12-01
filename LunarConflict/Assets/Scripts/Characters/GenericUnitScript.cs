using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenericUnitScript : MonoBehaviour
{
    [SerializeField] protected float attack;
    [SerializeField] protected float fire_rate;
    [SerializeField] protected float max_health;
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
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

        if(this.name == "USA Astronaut(Clone)")
        {
            attack = Units_Statistics.astronaut_attack;
            fire_rate = Units_Statistics.astronaut_fire_rate;
            max_health = Units_Statistics.astronaut_max_HP;
            health = max_health;
            speed = Units_Statistics.astronaut_speed;
        }
        else if(this.name == "Soviet Astronaut(Clone)")
        {
            attack = Units_Statistics.astronaut_attack * Units_Statistics.stats_modifier;
            fire_rate = Units_Statistics.astronaut_fire_rate * Units_Statistics.stats_modifier;
            max_health = Units_Statistics.astronaut_max_HP * Units_Statistics.stats_modifier;
            health = max_health;
            speed = Units_Statistics.astronaut_speed * Units_Statistics.stats_modifier;
        }
        else if(this.name == "USA Lunar Rover(Clone)")
        {
            attack = Units_Statistics.rover_attack;
            fire_rate = Units_Statistics.rover_fire_rate;
            max_health = Units_Statistics.rover_max_HP;
            health = max_health;
            speed = Units_Statistics.rover_speed;
        }
        else if(this.name == "Soviet Lunar Rover(Clone)")
        {
            attack = Units_Statistics.rover_attack * Units_Statistics.stats_modifier;
            fire_rate = Units_Statistics.rover_fire_rate * Units_Statistics.stats_modifier;
            max_health = Units_Statistics.rover_max_HP * Units_Statistics.stats_modifier;
            health = max_health;
            speed = Units_Statistics.rover_speed * Units_Statistics.stats_modifier;
        }

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
