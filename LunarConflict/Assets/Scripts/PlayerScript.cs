using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject unitAstronaut;
    [SerializeField] private GameObject unitRover;
    [SerializeField] private GameObject spawner;
    
    [SerializeField] private Text budget;

    public int money;
    
    private GameObject _base;
    void Start()
    {
        StartCoroutine(RaiseBudget());
        _base = GameObject.Find("PlayerBase");
    }

    private IEnumerator RaiseBudget()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            money += 10;
            budget.text = money.ToString() + "$";
        }
    }

    public void BuyAstronaut()
    {
        if (money >= 50)
        {
            Instantiate(unitAstronaut, spawner.transform.position, spawner.transform.rotation);
            money -= 50;
        }
    }
    
    public void BuyRover()
    {
        if (money >= 100)
        {
            Instantiate(unitRover, spawner.transform.position, spawner.transform.rotation);
            money -= 100;
        }
    }
}
