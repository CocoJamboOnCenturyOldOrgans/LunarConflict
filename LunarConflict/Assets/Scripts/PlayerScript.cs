using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject astronaut;
    [SerializeField] private GameObject rover;
    [SerializeField] private GameObject spawner;
    
    [SerializeField] private Text Budget;

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
            Budget.text = money.ToString() + Settings_Script.UI_Money_Mark;
        }
    }

    public void BuyAstronaut()
    {
        Instantiate(astronaut, spawner.transform.position, spawner.transform.rotation);
        money -= 50;
        Budget.text = money.ToString() + Settings_Script.UI_Money_Mark;
    }

    public void BuyRover()
    {
        Instantiate(rover, spawner.transform.position, spawner.transform.rotation);
        money -= 100;
        Budget.text = money.ToString() + Settings_Script.UI_Money_Mark;
    }
}
