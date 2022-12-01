using UnityEngine;
using UnityEngine.UI;

public class GameInitiationScript : MonoBehaviour
{
    private GameUIScript _uiScript;
    private PlayerScript _playerScript;
    [SerializeField] private Text budget;

    // Start is called before the first frame update
    void Start()
    {
        _uiScript = FindObjectOfType<GameUIScript>();
        _playerScript = FindObjectOfType<PlayerScript>();

        ChangeToUsa();
        
        if (SettingsScript.Side == 1)
            ChangeToUsa();
        else if(SettingsScript.Side == 2)
            ChangeToSoviet();
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
        _uiScript.changed = true;
        budget.text = _playerScript.money + SettingsScript.UIMoneyMark;
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
        _uiScript.changed = true;
        budget.text = _playerScript.money + SettingsScript.UIMoneyMark;
    }
}
