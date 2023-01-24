using UnityEngine;
using UnityEngine.UI;
using static SettingsScript;

public class UIUnitButtonScript : MonoBehaviour
{
    private GameUIScript _uiScript;
    private PlayerScript _playerScript;
    
    private GenericUnitScript _currentUnit;
    private bool _isTank;
    private Color _buyableColor, _unbuyableColor;
    
    private Image _buttonImage;
    
    [SerializeField] private Text unitPriceText;
    
    [SerializeField] private GenericUnitScript unitUsa;
    [SerializeField] private GenericUnitScript unitRussian; 

    // Start is called before the first frame update
    void Start()
    {
        _uiScript = FindObjectOfType<GameUIScript>();
        _playerScript = FindObjectOfType<PlayerScript>();
        _buttonImage = GetComponent<Image>();
        ChangeSide();
    }
    
    void Update()
    {
        if (_isTank && !_playerScript.hasFactory) return;
        
        _buttonImage.color = _playerScript.money >= _currentUnit.unitCost ? _buyableColor : _unbuyableColor;
        unitPriceText.color = _playerScript.money >= _currentUnit.unitCost ? Color.green : Color.red;
    }

    public void OnMouseEnter()
    {
        if(_isTank && _playerScript.hasFactory)
            _uiScript.bottomPanel.attack.value = _currentUnit.attack * 3;
        else if (!_isTank)
            _uiScript.bottomPanel.attack.value = _currentUnit.attack;
        else
            return;
        
        _uiScript.bottomPanel.unitName.text = _currentUnit.unitName;
        _uiScript.bottomPanel.fireRate.value = _currentUnit.fireRate;
        _uiScript.bottomPanel.hp.value = _currentUnit.maxHealth;
        _uiScript.bottomPanel.speed.value = _currentUnit.speed;
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
        _currentUnit = Faction == PlayerFaction.USA ? unitUsa : unitRussian;
        _isTank = _currentUnit.GetType() == typeof(USATankUnit) || _currentUnit.GetType() == typeof(SovietTankUnit);

        UpdateUIInfo();
        
        _buyableColor = _buttonImage.color;
        _unbuyableColor = new Color(_buyableColor.r, _buyableColor.g, _buyableColor.b, 0.5f);
    }

    public void UpdateUIInfo()
    {
        if (_isTank && !_playerScript.hasFactory)
        {
            unitPriceText.text = "N/A";
            unitPriceText.color = Color.red;
        }
        else
        {
            unitPriceText.text = _currentUnit.unitCost + UIMoneyMark; 
        }
        
        _buttonImage.sprite = _currentUnit.icon;
    }
}
