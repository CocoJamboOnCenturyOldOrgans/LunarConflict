using UnityEngine;

public class UIShopAstronaut : MonoBehaviour
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

        _uiScript.attack.value = UnitsStatistics.RoverAttack;
        _uiScript.attackValue.text = _uiScript.attack.value.ToString();
        _uiScript.fireRate.value = UnitsStatistics.RoverFireRate;
        _uiScript.fireRateValue.text = _uiScript.fireRate.value.ToString();
        _uiScript.hp.value = UnitsStatistics.RoverMaxHp;
        _uiScript.hpValue.text = _uiScript.hp.value.ToString();
        _uiScript.speed.value = UnitsStatistics.RoverSpeed;
        _uiScript.speedValue.text = _uiScript.speed.value.ToString();
        _uiScript.unitName.text = SettingsScript.RoverName;
        _uiScript.attack.value = UnitsStatistics.AstronautAttack + 0;
        _uiScript.attackValue.text = _uiScript.attack.value.ToString();
        _uiScript.fireRate.value = UnitsStatistics.AstronautFireRate + 0;
        _uiScript.fireRateValue.text = _uiScript.fireRate.value.ToString();
        _uiScript.hp.value = UnitsStatistics.AstronautMaxHp + 0;
        _uiScript.hpValue.text = _uiScript.hp.value.ToString();
        _uiScript.speed.value = UnitsStatistics.AstronautSpeed + 0;
        _uiScript.speedValue.text = _uiScript.speed.value.ToString();
        _uiScript.unitName.text = SettingsScript.AstronautName;
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
