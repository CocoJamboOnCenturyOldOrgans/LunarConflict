using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInitiationScript : MonoBehaviour
{
    [SerializeField] private GameUIScript UIScript;
    [SerializeField] private PlayerScript PlayerScript;
    [SerializeField] private Text Budget;

    // Start is called before the first frame update
    void Start()
    {
        UIScript = GameObject.Find("UI").GetComponent<GameUIScript>();
        PlayerScript = GameObject.Find("GameLogic").GetComponent<PlayerScript>();

        ChangeToUSA();
        if (Settings_Script.side == 1)
            ChangeToUSA();
        else if(Settings_Script.side == 2)
            ChangeToSoviet();
    }

    public void ChangeToUSA()
    {
        Settings_Script.UI_Money_Mark = "$";
        Settings_Script.Astronaut_Shop_Positive = Resources.Load<Sprite>("SpritesShop/usa_astronaut_Icon");
        Settings_Script.Astronaut_Shop_Negative = Resources.Load<Sprite>("SpritesShop/usa_astronaut_Icon_LowMoney");
        Settings_Script.Rover_Shop_Positive = Resources.Load<Sprite>("SpritesShop/lunar_rover_usa_Icon");
        Settings_Script.Rover_Shop_Negative = Resources.Load<Sprite>("SpritesShop/lunar_rover_usa_Icon_LowMoney");
        Settings_Script.Astronaut_Name = "USA Astronaut";
        Settings_Script.Rover_Name = "USA Lunar Rover";
        UIScript.changed = true;
        Budget.text = PlayerScript.money.ToString() + Settings_Script.UI_Money_Mark;
    }

    public void ChangeToSoviet()
    {
        Settings_Script.UI_Money_Mark = "₽";
        Settings_Script.Astronaut_Shop_Positive = Resources.Load<Sprite>("SpritesShop/soviet_astronaut_Icon");
        Settings_Script.Astronaut_Shop_Negative = Resources.Load<Sprite>("SpritesShop/soviet_astronaut_Icon_LowMoney");
        Settings_Script.Rover_Shop_Positive = Resources.Load<Sprite>("SpritesShop/lunar_rover_soviet_Icon");
        Settings_Script.Rover_Shop_Negative = Resources.Load<Sprite>("SpritesShop/lunar_rover_soviet_Icon_LowMoney");
        Settings_Script.Astronaut_Name = "Soviet Astronaut";
        Settings_Script.Rover_Name = "Soviet Lunar Rover";
        UIScript.changed = true;
        Budget.text = PlayerScript.money.ToString() + Settings_Script.UI_Money_Mark;
    }
}
