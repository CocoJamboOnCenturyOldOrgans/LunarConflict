using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SettingsScript;

public class UIBaseBuildingButtonScript : MonoBehaviour
{
    private GameUIScript _uiScript;
    private PlayerScript _playerScript;
    private Color _buyableColor, _unbuyableColor;
    private Image _buttonImage;

    [SerializeField] private List<UIUnitButtonScript> uiUnitButtonScripts;
    [SerializeField] private Text buildingPriceText;
    
    [Header("Stats")]
    [SerializeField] private string buildingName;
    [SerializeField, TextArea(1,2)] private string buildingDescription;
    [SerializeField] private int buildingCost;
    [SerializeField] private int incomeBoost;

    void Start()
    {
        _uiScript = FindObjectOfType<GameUIScript>();
        _playerScript = FindObjectOfType<PlayerScript>();
        _buttonImage = GetComponent<Image>();
        
        buildingPriceText.text = buildingCost + UIMoneyMark;
        _buyableColor = _buttonImage.color;
        _unbuyableColor = new Color(_buyableColor.r, _buyableColor.g, _buyableColor.b, 0.5f);
    }
    
    void Update()
    {
        _buttonImage.color = _playerScript.money >= buildingCost ? _buyableColor : _unbuyableColor;
        buildingPriceText.color = _playerScript.money >= buildingCost ? Color.green : Color.red;
    }

    public void CreateBank()
    {
        if (_playerScript.money >= buildingCost)
            _playerScript.money -= buildingCost;
        else
            return;
        
        _playerScript.income += incomeBoost;
        OnBuildingBought();
    }

    public void CreateFactory()
    {
        if (_playerScript.money >= buildingCost)
            _playerScript.money -= buildingCost;
        else
            return;
        
        _playerScript.hasFactory = true;
        uiUnitButtonScripts.ForEach(x => x.UpdateUIInfo());
        OnBuildingBought();
    }

    private void OnBuildingBought()
    {
        GetComponent<Button>().enabled = false;
        buildingPriceText.text = "OWNED";
        _buttonImage.color = _buyableColor;
        buildingPriceText.color = Color.green;
        this.enabled = false;
    }

    public void OnMouseEnter()
    {
        _uiScript.bottomPanel.buildingName.text = buildingName;
        _uiScript.bottomPanel.description.text = buildingDescription;
    }

    public void OnMouseExit()
    {
        _uiScript.bottomPanel.buildingName.text = string.Empty;
        _uiScript.bottomPanel.description.text = string.Empty;
    }
}
