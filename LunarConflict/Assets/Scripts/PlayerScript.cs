using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject astronaut;
    [SerializeField] private GameObject spawner;
    
    [SerializeField] private Text Budget;

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
            Budget.text = money.ToString() + "$";
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
