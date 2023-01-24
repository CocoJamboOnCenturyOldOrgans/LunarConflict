using System.Collections;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private enum BulletType
    {
        Missile,
        AirMissile,
        Bullet
    }

    [SerializeField] private BulletType bulletType;
    [SerializeField] private int speed;
    [SerializeField] private int damage;

    private string _ignoreTag;

    void Start()
    {
        _ignoreTag = transform.rotation.eulerAngles.z > 180 ? "PlayerUnit" : "EnemyUnit";
        StartCoroutine(Disappear());
    }

    void FixedUpdate()
    {
        if (bulletType == BulletType.AirMissile) return;
        
        transform.Translate(Vector3.up * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag(_ignoreTag))
        {
            if (col.TryGetComponent(out IHittable hittable))
            {
                hittable.OnHit(damage);
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
