using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int damage; 
    
    void Update() => transform.Translate(Vector3.up * (speed * Time.deltaTime));

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerUnit" || col.tag == "EnemyUnit")
        {
            col.gameObject.GetComponent<GenericUnit_Script>().GotHit(damage);
        }
        Destroy(this.gameObject);
    }
}
