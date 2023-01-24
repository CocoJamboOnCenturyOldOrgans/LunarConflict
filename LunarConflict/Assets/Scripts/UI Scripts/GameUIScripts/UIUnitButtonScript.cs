using UnityEngine;
using UnityEngine.UI;
using static SettingsScript;

public class UIUnitButtonScript : MonoBehaviour
{
    private GameUIScript _uiScript;
    private PlayerScript _playerScript;
    
    private GenericUnitScript _currentUnit;
    private Sprite _currentUnitIcon;
    private Color _buyableColor, _unbuyableColor;
    
    private Image _buttonImage;
    
    [SerializeField] private Text unitPriceText;
    
    [SerializeField] private GenericUnitScript unitUsa;
    [SerializeField] private GenericUnitScript unitRussian; 
    [SerializeField] private Sprite unitIconUsa;
    [SerializeField] private Sprite unitIconRussian;

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
        _buttonImage.color = _playerScript.money >= _currentUnit.unitCost ? _buyableColor : _unbuyableColor;
        unitPriceText.color = _playerScript.money >= _currentUnit.unitCost ? Color.green : Color.red;
    }

    public void OnMouseEnter()
    {
        _uiScript.bottomPanel.unitName.text = Faction == PlayerFaction.USA ? unitUsa.unitName : unitRussian.unitName;
        if(unitUsa.name == "USA Tank")
            _uiScript.bottomPanel.attack.value = Faction == PlayerFaction.USA ? unitUsa.attack * 3 : unitRussian.attack * 3;
        else
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
        unitPriceText.text = (Faction == PlayerFaction.USA ? unitUsa.unitCost : unitRussian.unitCost) + UIMoneyMark;
        _currentUnit = Faction == PlayerFaction.USA ? unitUsa : unitRussian;
        _currentUnitIcon = Faction == PlayerFaction.USA ? unitIconUsa : unitIconRussian;
        _buttonImage.sprite = _currentUnitIcon;
        
        _buyableColor = _buttonImage.color;
        _unbuyableColor = new Color(_buyableColor.r, _buyableColor.g, _buyableColor.b, 0.5f);
    }
}
