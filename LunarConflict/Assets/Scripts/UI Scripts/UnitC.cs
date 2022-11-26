using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitC : MonoBehaviour
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
        UIScript.Attack.value = 75;
        UIScript.AttackValue.text = UIScript.Attack.value.ToString();
        UIScript.FireRate.value = (float)0.25;
        UIScript.FireRateValue.text = UIScript.FireRate.value.ToString();
        UIScript.HP.value = 500;
        UIScript.HPValue.text = UIScript.HP.value.ToString();
        UIScript.Speed.value = (float)1.5;
        UIScript.SpeedValue.text = UIScript.Speed.value.ToString();
        UIScript.UnitName.text = "Unit Gamma";
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
