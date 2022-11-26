using System;
using System.Collections;
using UnityEngine;

public class DummyAstronautScript : GenericUnitScript
{
    [SerializeField] private Transform bulletParent;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject blackhole;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("play", true);
        
        speed = russian ? speed * -1 : speed;
        attackRange = russian ? attackRange * -1 : attackRange;
    }

    private void Update()
    { 
        Debug.DrawRay(transform.position, Vector2.right * attackRange, Color.green, Time.deltaTime);
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

    public void AstronautShoot()
    {
        Instantiate(
            bulletPrefab, 
            bulletParent.position, 
            (russian ? Quaternion.Euler(0,0,90) : Quaternion.Euler(0,0,-90)));
    }

    public void OpenBlackHole()
    {
        StartCoroutine(CreateBlackHole());
    }

    private IEnumerator CreateBlackHole()
    {
        yield return null;
        
        var startScale = blackhole.transform.localScale;
        blackhole.transform.localScale /= 10.0f;
        var increaseVal = blackhole.transform.localScale;
        
        blackhole.SetActive(true);

        while (blackhole.transform.localScale.magnitude < startScale.magnitude)
        {
            blackhole.transform.localScale += increaseVal;
            yield return new WaitForSeconds(0.005f);
        }
    }
    
    public void AstronautDeath()
    {
        GameObject.Destroy(this.gameObject);
    }
}
