using System.Collections;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int damage;

    void Start() => StartCoroutine(Disappear());
    void FixedUpdate() => transform.Translate(Vector3.up * (speed * Time.deltaTime));

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<GenericUnit_Script>(out var unitScript))
            unitScript.GotHit(damage);
        
        Destroy(this.gameObject);
    }
    
    private IEnumerator Disappear()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Destroy(this.gameObject);
        }
    }
}
