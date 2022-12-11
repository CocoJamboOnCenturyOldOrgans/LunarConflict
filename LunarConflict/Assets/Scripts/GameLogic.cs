using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject game;
    public bool playingAsRussian = false;
    
    private GameUIScript _uiScript;

    // Start is called before the first frame update
    void Start()
    {
        _uiScript = FindObjectOfType<GameUIScript>();

        if (SettingsScript.SideIsSoviet)
            ChangeToSoviet();
        else
            ChangeToUsa();
        
        #warning This is temporary to view UI changes on different sides.
        _uiScript.changed = true;
    }

    public void ChangeToUsa()
    {
        SettingsScript.UIMoneyMark = "$";
        SettingsScript.AstronautShopPositive = Resources.Load<Sprite>("SpritesShop/usa_astronaut_Icon");
        SettingsScript.AstronautShopNegative = Resources.Load<Sprite>("SpritesShop/usa_astronaut_Icon_LowMoney");
        SettingsScript.RoverShopPositive = Resources.Load<Sprite>("SpritesShop/lunar_rover_usa_Icon");
        SettingsScript.RoverShopNegative = Resources.Load<Sprite>("SpritesShop/lunar_rover_usa_Icon_LowMoney");
        SettingsScript.AstronautName = "Astronaut";
        SettingsScript.RoverName = "Lunar Rover";
    }

    public void ChangeToSoviet()
    {
        SettingsScript.UIMoneyMark = "₽";
        SettingsScript.AstronautShopPositive = Resources.Load<Sprite>("SpritesShop/soviet_astronaut_Icon");
        SettingsScript.AstronautShopNegative = Resources.Load<Sprite>("SpritesShop/soviet_astronaut_Icon_LowMoney");
        SettingsScript.RoverShopPositive = Resources.Load<Sprite>("SpritesShop/lunar_rover_soviet_Icon");
        SettingsScript.RoverShopNegative = Resources.Load<Sprite>("SpritesShop/lunar_rover_soviet_Icon_LowMoney");
        SettingsScript.AstronautName = "Astronaut";
        SettingsScript.RoverName = "Lunar Rover";
    }
}
