using UnityEngine;
using UnityEngine.UI;
using static SettingsScript;

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
    
    void LateUpdate()
    {
        _buttonImage.sprite = _playerScript.money >= _currentUnit.unitCost ? 
            _currentUnitIconBuyable : _currentUnitIconNonBuyable;
        unitPriceText.color = _playerScript.money >= _currentUnit.unitCost ? Color.green : Color.red;
    }

    public void OnMouseEnter()
    {
        _uiScript.bottomPanel.unitName.text = Faction == PlayerFaction.USA ? unitUsa.unitName : unitRussian.unitName;
        _uiScript.bottomPanel.attack.value = Faction == PlayerFaction.USA ? unitUsa.attack : unitRussian.attack;
        _uiScript.bottomPanel.fireRate.value = Faction == PlayerFaction.USA ? unitUsa.fireRate : unitRussian.fireRate;
        _uiScript.bottomPanel.hp.value = Faction == PlayerFaction.USA ? unitUsa.maxHealth : unitRussian.maxHealth;
        _uiScript.bottomPanel.speed.value = Faction == PlayerFaction.USA ? unitUsa.speed : unitRussian.speed;
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
        unitPriceText.text = (Faction == PlayerFaction.USA ? unitUsa.unitCost : unitRussian.unitCost) 
                             + UIMoneyMark;
        _currentUnit = Faction == PlayerFaction.USA ? unitUsa : unitRussian;
        _currentUnitIconBuyable = Faction == PlayerFaction.USA ? 
            UnitIconBuyableUsa : UnitIconBuyableRussian;
        _currentUnitIconNonBuyable = Faction == PlayerFaction.USA ? 
            UnitIconNonBuyableUsa : UnitIconNonBuyableRussian;
    }
}
