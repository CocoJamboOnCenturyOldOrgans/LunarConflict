using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitD : MonoBehaviour
{
    private GameUIScript UIScript;

    // Start is called before the first frame update
    void Start()
    {
        UIScript = GameObject.Find("UI").GetComponent<GameUIScript>();
    }

    public void OnMouseEnter()
    {
        //Temp Test Values
        UIScript.Attack.value = 100;
        UIScript.AttackValue.text = UIScript.Attack.value.ToString();
        UIScript.FireRate.value = 2;
        UIScript.FireRateValue.text = UIScript.FireRate.value.ToString();
        UIScript.HP.value = 1000;
        UIScript.HPValue.text = UIScript.HP.value.ToString();
        UIScript.Speed.value = 2;
        UIScript.SpeedValue.text = UIScript.Speed.value.ToString();
        UIScript.UnitName.text = "Unit Delta";
    }

    public void OnMouseExit()
    {
        UIScript.Attack.value = 0;
        UIScript.AttackValue.text = "-----";
        UIScript.FireRate.value = 0;
        UIScript.FireRateValue.text = "-----";
        UIScript.HP.value = 0;
        UIScript.HPValue.text = "-----";
        UIScript.Speed.value = 0;
        UIScript.SpeedValue.text = "-----";
        UIScript.UnitName.text = "N/A";
    }
}
