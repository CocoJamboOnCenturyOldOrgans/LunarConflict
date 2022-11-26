using System;
using System.Collections;
using UnityEngine;

public class Astronaut_Unit_Enemy_Script : MonoBehaviour
{
    [SerializeField] private Transform bulletParent;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject blackhole;
    private Animator _animator;

    private int attack;
    private float fire_rate;
    private int max_HP;
    private int HP;
    private float speed;

    private int TEMP = 1;
    private int attackRange = 2;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        attack = Units_Statistics.astronaut_attack * TEMP;
        fire_rate = Units_Statistics.astronaut_fire_rate * TEMP;
        max_HP = Units_Statistics.astronaut_max_HP * TEMP;
        HP = max_HP;
        speed = -1 * Units_Statistics.astronaut_speed * TEMP;
    }

    private void Update()
    {
        _animator.SetBool("play", true);

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("walking") || _animator.GetCurrentAnimatorStateInfo(0).IsName("driving"))
            transform.Translate(Vector3.right * (speed * Time.deltaTime));

        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.left, attackRange);
        Debug.DrawRay(transform.position, Vector2.left * attackRange, Color.green, Time.deltaTime);

        _animator.SetBool("attackMode", false);
        foreach (var x in hit)
        {
            if (x.collider.CompareTag("PlayerUnit") && x.collider.gameObject != gameObject)
            {
                _animator.SetBool("attackMode", true);
                break;
            }
        }
        _animator.SetBool("dying", HP <= 0 ? true : false);
    }

    public void AstronautShoot()
    {
        Instantiate(
            bulletPrefab,
            bulletParent.position,
        (Quaternion.Euler(0, 0, 90)));
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
