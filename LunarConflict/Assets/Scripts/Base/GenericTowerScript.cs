using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static GameRoundData;
using static SettingsScript;

public class GenericTowerScript : MonoBehaviour
{
    public PlayerFaction towerFaction;
    public int attack;
    private float _fireRate = 1;

    private Animator _animator;
    private Transform _pivot;
    private Transform _target;
    private BoxCollider2D _collider2D;
    private string _ignoreTag;
    
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform bulletParent;
    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        _pivot = transform.parent;
        _collider2D = GetComponent<BoxCollider2D>();
        _ignoreTag = towerFaction == PlayerFaction.USA ? "PlayerUnit" : "EnemyUnit";
    }
    protected void Update()
    {
        _animator.SetBool("attackMode", Attack());
    }

    private bool Attack()
    {
        if (!_target.IsUnityNull())
        {
            if (towerFaction == PlayerFaction.USA)
                _pivot.right = _target.position - transform.position;
            else
                _pivot.right = -(_target.position - transform.position);
                return true;
        }

        return false;
    }
    
    public void Shoot(Transform parent = null)
    {
        var bullet = Instantiate(
            bulletPrefab,
            parent == null ? bulletParent.position : parent.position,
            towerFaction == PlayerFaction.USA ? 
                Quaternion.Euler(0, 0, _pivot.rotation.eulerAngles.z - 90) : 
                Quaternion.Euler(0, 0, _pivot.rotation.eulerAngles.z + 90));
        bullet.GetComponent<BulletScript>().damage = attack;
    }

    public void UpgradeTower(int damageUpg, float fireRateUpg)
    {
        attack += damageUpg;
        _fireRate += fireRateUpg;
        _animator.SetFloat("fireRate", _fireRate);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag(_ignoreTag))
        {
            _target = col.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag(_ignoreTag))
        {
            _target = null;
            _pivot.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }
    }
}
