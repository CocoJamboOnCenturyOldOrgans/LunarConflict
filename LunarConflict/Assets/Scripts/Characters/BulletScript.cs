using System.Collections;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int damage;

    private string _ignoreTag;

    void Start()
    {
        _ignoreTag = transform.rotation.z < 0 ? "PlayerUnit" : "EnemyUnit";
        Debug.Log(_ignoreTag);
        StartCoroutine(Disappear());
    }

    void FixedUpdate() => transform.Translate(Vector3.up * (speed * Time.deltaTime));

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag(_ignoreTag))
        {
            if (col.TryGetComponent(out GenericUnitScript unitScript))
            {
                unitScript.GotHit(damage);
            }

            Destroy(this.gameObject);
        }
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
