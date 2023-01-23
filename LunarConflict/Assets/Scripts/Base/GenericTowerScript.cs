using System;
using Unity.VisualScripting;
using UnityEngine;
using static GameRoundData;
using static SettingsScript;

public class GenericTowerScript : MonoBehaviour
{
    public PlayerFaction towerFaction;
    public float attack;

    private Animator _animator;
    private Transform _pivot;
    private Transform _target;
    private string _ignoreTag;
    
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform bulletParent;
    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        _pivot = transform.parent;
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
            _pivot.right = _target.position - transform.position;
            return true;
        }

        return false;
    }
    
    public void Shoot(Transform parent = null)
    {
        Instantiate(
            bulletPrefab,
            parent == null ? bulletParent.position : parent.position,
            Quaternion.Euler(0, 0, _pivot.rotation.eulerAngles.z - 90));
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag(_ignoreTag))
        {
            _target = col.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        _target = null;
        _pivot.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }
}
