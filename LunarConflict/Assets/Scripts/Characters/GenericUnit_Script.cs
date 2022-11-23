using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericUnit_Script : MonoBehaviour
{
    public int health;
    public int speed;
    public int attackRange;
    public bool russian;
    public bool attackMode = false;
    public int unitCost;

    public void GotHit(int damage) => health -= damage;
}
