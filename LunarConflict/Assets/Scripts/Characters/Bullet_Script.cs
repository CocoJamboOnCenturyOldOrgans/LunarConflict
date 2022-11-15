using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    [SerializeField] private int speed;
    
    void Update() => transform.Translate(Vector3.up * (speed * Time.deltaTime));
}
