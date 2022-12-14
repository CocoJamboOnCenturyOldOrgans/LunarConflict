using UnityEngine;

public class UnitC : MonoBehaviour
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
        _uiScript.attack.value = 75;
        _uiScript.attackValue.text = _uiScript.attack.value.ToString();
        _uiScript.fireRate.value = (float)0.25;
        _uiScript.fireRateValue.text = _uiScript.fireRate.value.ToString();
        _uiScript.hp.value = 500;
        _uiScript.hpValue.text = _uiScript.hp.value.ToString();
        _uiScript.speed.value = (float)1.5;
        _uiScript.speedValue.text = _uiScript.speed.value.ToString();
        _uiScript.unitName.text = "Unit Gamma";
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
