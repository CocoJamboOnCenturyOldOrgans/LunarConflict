using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static GameRoundData;
using static SettingsScript;

public class GenericUnitScript : MonoBehaviour, IHittable
{
    public PlayerFaction unitFaction;
    public Sprite icon;
    public int Health { get; set; }
    public string unitName;
    public float attack;
    public float fireRate;
    public int maxHealth;
    public float speed;
    public int unitCost;
    [SerializeField] protected int attackRange;
    [SerializeField] protected bool attackMode = false;
    [SerializeField] protected Transform bulletParent;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] private Vector2 raycastOffset;
    
    private Animator _animator;
    private LayerMask _mask;
    private Vector2 _movementDirection;
    private float _localScaleX;

    private HealthBarDisplayer _healthBarDisplayer;

    protected virtual void Start()
    {
        Health = maxHealth;
        _animator = GetComponent<Animator>();
        _mask = LayerMask.GetMask("Unit");
        _animator.SetBool("play", true);
        _movementDirection = unitFaction == PlayerFaction.USA ? Vector2.right : Vector2.left;
        _localScaleX = transform.localScale.x;
        speed = unitFaction == PlayerFaction.USA ? speed : speed * -1;

        _healthBarDisplayer = GetComponent<HealthBarDisplayer>();
    }

    protected virtual void Update()
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
        var pos = new Vector3(transform.position.x + raycastOffset.x, transform.position.y + raycastOffset.y, transform.position.z);
        RaycastHit2D[] hit = Physics2D.RaycastAll(
            pos, 
            _movementDirection,
            attackRange, 
            _mask);

        return hit.Any(x => 
            (x.collider.TryGetComponent<GenericUnitScript>(out var unitScript) && unitScript.unitFaction != unitFaction) ||
            (x.collider.TryGetComponent<GenericBaseScript>(out var baseScript) && baseScript.BaseFaction != unitFaction));
    }
    
    private bool CanWalk()
    {
        var pos = new Vector3(transform.position.x + raycastOffset.x, transform.position.y + raycastOffset.y, transform.position.z);
        LayerMask mask = LayerMask.GetMask("Unit");
        RaycastHit2D hit = Physics2D.Raycast(
            pos, 
            _movementDirection, 
            _localScaleX, 
            _mask);
        
        //Fix that by Yourself Mr. Blue Skeleton Leader, cause it's still not working well
        //if(!hit.collider.IsUnityNull())
        //{
        //    this.transform.position += new Vector3(-1, 0);
        //}
        
        return hit.collider.IsUnityNull();
    }
    
    public void Shoot(Transform parent = null)
    {
        Instantiate(
            bulletPrefab,
            parent == null ? bulletParent.position : parent.position,
            unitFaction == PlayerFaction.USA ? Quaternion.Euler(0, 0, -90) : Quaternion.Euler(0, 0, 90));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == this.tag)
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    public virtual void OnHit(int damage) => Health -= damage;

    public virtual void OnDeath()
    {
        _healthBarDisplayer.DestroySlider();
        
        if (!IsPlayer(unitFaction))
            kills++;
        
        Destroy(gameObject);
    }

}
