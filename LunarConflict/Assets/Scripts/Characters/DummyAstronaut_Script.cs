using System.Collections;
using UnityEngine;

public class DummyAstronaut_Script : GenericUnit_Script
{
    [SerializeField] private Transform bulletParent;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject blackhole;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        speed = russian ? speed * -1 : speed;
    }

    private void Update()
    {
        _animator.SetBool("play", true);
        
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("walking"))
            transform.Translate(Vector3.right * (speed * Time.deltaTime));

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left);
        
        _animator.SetBool("attackMode", hit.collider.CompareTag("Unit") ? true : false);
        _animator.SetBool("dying", health <= 0 ? true : false);
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
