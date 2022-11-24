using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject astronaut;
    [SerializeField] private GameObject spawner;
    
    public int money;
    
    private GameObject _base;
    void Start()
    {
        StartCoroutine("RaiseBudget");
        _base = GameObject.Find("PlayerBase");
    }

    private IEnumerator RaiseBudget()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            money += 5;
        }
    }

    public void BuyAstronaut()
    {
        if (money >= 100)
        {
            Instantiate(astronaut, spawner.transform.position, spawner.transform.rotation);
            money -= 100;
        }
    }
}
