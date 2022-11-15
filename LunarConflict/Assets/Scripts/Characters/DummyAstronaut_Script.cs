using System.Collections;
using UnityEngine;

public class DummyAstronaut_Script : MonoBehaviour
{
    [SerializeField] private Transform bulletParent;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject blackhole;
    [SerializeField] private int speed;
    [SerializeField] private bool russian = false;
    private Animator _animator;
    private Vector3 _startingPos;
    private bool _startAnimation;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _startingPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_startAnimation)
        {
            _animator.SetBool("play", true);
            _startAnimation = true;
        }

        if (!_startAnimation) return;
        
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("walking"))
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
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
        transform.position = _startingPos;
        blackhole.SetActive(false);
        StopAllCoroutines();
    }
}
