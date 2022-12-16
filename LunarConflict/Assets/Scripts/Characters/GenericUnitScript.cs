using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static GameRoundData;
using UnityEngine.Serialization;

public class GenericUnitScript : MonoBehaviour, IHittable
{
    public int Health { get; set; }
    public string unitName;
    public float attack;
    public float fireRate;
    public int maxHealth;
    public float speed;
    public int unitCost;
    [SerializeField] protected int attackRange;
    [SerializeField] protected bool russian;
    [SerializeField] protected bool attackMode = false;
    [SerializeField] protected Transform bulletParent;
    [SerializeField] protected GameObject bulletPrefab;
    
    private Animator _animator;
    private LayerMask _mask;
    private Vector2 _movementDirection;
    private float _localScaleX;

    protected void Start()
    {
        Health = maxHealth;
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
        _animator.SetBool("dying", Health <= 0);
    }
    
    private bool CanAttack()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(
            transform.position, 
            _movementDirection,
            attackRange, 
            _mask);

        return hit.Any(x => x.collider.CompareTag(russian ? "PlayerUnit" : "EnemyUnit"));
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
            russian ? Quaternion.Euler(0,0,90) : Quaternion.Euler(0,0,-90));
    }
    
    public virtual void OnHit(int damage) => Health -= damage;
    
    public virtual void OnDeath()
    {
        if (russian)
            kills++;
        Destroy(gameObject);
    }

}
