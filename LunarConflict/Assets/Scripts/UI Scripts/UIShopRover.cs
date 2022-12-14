using UnityEngine;

public class UIShopRover : MonoBehaviour
{
    private GameUIScript _uiScript;

    // Start is called before the first frame update
    void Start()
    {
        _uiScript = FindObjectOfType<GameUIScript>();
    }

    public void OnMouseEnter()
    {
        //Temp Test Values
        _uiScript.attack.value = UnitsStatistics.RoverAttack + 0;
        _uiScript.attackValue.text = _uiScript.attack.value.ToString();
        _uiScript.fireRate.value = UnitsStatistics.RoverFireRate + 0;
        _uiScript.fireRateValue.text = _uiScript.fireRate.value.ToString();
        _uiScript.hp.value = UnitsStatistics.RoverMaxHp + 0;
        _uiScript.hpValue.text = _uiScript.hp.value.ToString();
        _uiScript.speed.value = UnitsStatistics.RoverSpeed + 0;
        _uiScript.speedValue.text = _uiScript.speed.value.ToString();
        _uiScript.unitName.text = SettingsScript.RoverName;
    }

    public void OnMouseExit()
    {
        _uiScript.attack.value = 0;
        _uiScript.attackValue.text = "-----";
        _uiScript.fireRate.value = 0;
        _uiScript.fireRateValue.text = "-----";
        _uiScript.hp.value = 0;
        _uiScript.hpValue.text = "-----";
        _uiScript.speed.value = 0;
        _uiScript.speedValue.text = "-----";
        _uiScript.unitName.text = "N/A";
    }
}
