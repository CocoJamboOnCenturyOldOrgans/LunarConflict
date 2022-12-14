using System;
using UnityEngine;
using UnityEngine.UI;

public class UIUnitButtonScript : MonoBehaviour
{
    private GameUIScript _uiScript;
    private GameLogic _gameLogic;
    private PlayerScript _playerScript;
    
    private GenericUnitScript _currentUnit;
    private Sprite _currentUnitIconBuyable;
    private Sprite _currentUnitIconNonBuyable;
    
    private Image _buttonImage;
    
    [SerializeField] private Text unitPriceText;
    
    [SerializeField] private GenericUnitScript unitUsa;
    [SerializeField] private GenericUnitScript unitRussian;
    [SerializeField] private Sprite UnitIconBuyableUsa;
    [SerializeField] private Sprite UnitIconNonBuyableUsa;
    [SerializeField] private Sprite UnitIconBuyableRussian;
    [SerializeField] private Sprite UnitIconNonBuyableRussian;

    // Start is called before the first frame update
    void Start()
    {
        _uiScript = FindObjectOfType<GameUIScript>();
        _gameLogic = FindObjectOfType<GameLogic>();
        _playerScript = FindObjectOfType<PlayerScript>();
        _buttonImage = GetComponent<Image>();
        ChangeSide();
    }
    
    void FixedUpdate()
    {
        enabled = _playerScript.money >= _currentUnit.unitCost;
        _buttonImage.sprite = _playerScript.money >= _currentUnit.unitCost ? 
            _currentUnitIconBuyable : _currentUnitIconNonBuyable;
        unitPriceText.color = _playerScript.money >= _currentUnit.unitCost ? Color.green : Color.red;
    }

    public void OnMouseEnter()
    {
        _uiScript.bottomPanel.unitName.text = SettingsScript.SideIsSoviet ? unitUsa.name : unitRussian.name;
        _uiScript.bottomPanel.attack.value = SettingsScript.SideIsSoviet ? unitUsa.attack : unitRussian.attack;
        _uiScript.bottomPanel.fireRate.value = SettingsScript.SideIsSoviet ? unitUsa.fireRate : unitRussian.fireRate;
        _uiScript.bottomPanel.hp.value = SettingsScript.SideIsSoviet ? unitUsa.maxHealth : unitRussian.maxHealth;
        _uiScript.bottomPanel.speed.value = SettingsScript.SideIsSoviet ? unitUsa.speed : unitRussian.speed;
        _uiScript.bottomPanel.attackValue.text = _uiScript.bottomPanel.attack.value.ToString();
        _uiScript.bottomPanel.fireRateValue.text = _uiScript.bottomPanel.fireRate.value.ToString();
        _uiScript.bottomPanel.hpValue.text = _uiScript.bottomPanel.hp.value.ToString();
        _uiScript.bottomPanel.speedValue.text = _uiScript.bottomPanel.speed.value.ToString();
    }

    public void OnMouseExit()
    {
        _uiScript.bottomPanel.attack.value = 0;
        _uiScript.bottomPanel.attackValue.text = "-----";
        _uiScript.bottomPanel.fireRate.value = 0;
        _uiScript.bottomPanel.fireRateValue.text = "-----";
        _uiScript.bottomPanel.hp.value = 0;
        _uiScript.bottomPanel.hpValue.text = "-----";
        _uiScript.bottomPanel.speed.value = 0;
        _uiScript.bottomPanel.speedValue.text = "-----";
        _uiScript.bottomPanel.unitName.text = "N/A";
    }

    public void ChangeSide()
    {
        unitPriceText.text = (SettingsScript.SideIsSoviet ? unitRussian.unitCost : unitUsa.unitCost) 
                             + SettingsScript.UIMoneyMark;
        _currentUnit = SettingsScript.SideIsSoviet ? unitRussian : unitUsa;
        _currentUnitIconBuyable = SettingsScript.SideIsSoviet ? 
            UnitIconBuyableRussian : UnitIconBuyableUsa;
        _currentUnitIconNonBuyable = SettingsScript.SideIsSoviet ? 
            UnitIconNonBuyableRussian : UnitIconNonBuyableUsa;
    }
}
