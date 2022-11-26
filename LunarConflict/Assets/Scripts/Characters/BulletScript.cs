using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int damage;

    void Start() => StartCoroutine(Disappear());
    void Update() => transform.Translate(Vector3.up * (speed * Time.deltaTime));

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerUnit" || col.tag == "EnemyUnit")
        {
            col.gameObject.GetComponent<GenericUnitScript>().GotHit(damage);
        }
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
