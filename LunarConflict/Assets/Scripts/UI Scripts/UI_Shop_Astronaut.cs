using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public class UI_Shop_Astronaut : MonoBehaviour
=======
<<<<<<< Updated upstream:LunarConflict/Assets/Scripts/UI Scripts/UI_Shop_Rover.cs
public class UI_Shop_Rover : MonoBehaviour
=======
public class UI_Shop_Astronaut : MonoBehaviour
>>>>>>> Stashed changes:LunarConflict/Assets/Scripts/UI Scripts/UI_Shop_Astronaut.cs
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
<<<<<<< Updated upstream:LunarConflict/Assets/Scripts/UI Scripts/UI_Shop_Rover.cs
        UIScript.Attack.value = Units_Statistics.rover_attack;
        UIScript.AttackValue.text = UIScript.Attack.value.ToString();
        UIScript.FireRate.value = Units_Statistics.rover_fire_rate;
        UIScript.FireRateValue.text = UIScript.FireRate.value.ToString();
        UIScript.HP.value = Units_Statistics.rover_max_HP;
        UIScript.HPValue.text = UIScript.HP.value.ToString();
        UIScript.Speed.value = Units_Statistics.rover_speed;
        UIScript.SpeedValue.text = UIScript.Speed.value.ToString();
        UIScript.UnitName.text = Settings_Script.Rover_Name.ToString();
=======
>>>>>>> Stashed changes
        UIScript.Attack.value = Units_Statistics.astronaut_attack + 0;
        UIScript.AttackValue.text = UIScript.Attack.value.ToString();
        UIScript.FireRate.value = Units_Statistics.astronaut_fire_rate + 0;
        UIScript.FireRateValue.text = UIScript.FireRate.value.ToString();
        UIScript.HP.value = Units_Statistics.astronaut_max_HP + 0;
        UIScript.HPValue.text = UIScript.HP.value.ToString();
        UIScript.Speed.value = Units_Statistics.astronaut_speed + 0;
        UIScript.SpeedValue.text = UIScript.Speed.value.ToString();
        UIScript.UnitName.text = Settings_Script.Astronaut_Name.ToString();
<<<<<<< Updated upstream
=======
>>>>>>> Stashed changes:LunarConflict/Assets/Scripts/UI Scripts/UI_Shop_Astronaut.cs
>>>>>>> Stashed changes
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
