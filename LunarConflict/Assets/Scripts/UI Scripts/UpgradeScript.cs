using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static SettingsScript;

public class UpgradeScript : MonoBehaviour
{
    [SerializeField] private Button[] Buttons = new Button[16];

    [SerializeField] private Image[] TreeImages = new Image[4];
    [SerializeField] private Sprite[] TreeSpritesUSA = new Sprite[4];
    [SerializeField] private Sprite[] TreeSpritesSoviet = new Sprite[4];

    [SerializeField] private Image[] UpgradeImages = new Image[16];
    [SerializeField] private Sprite[] UpgradeSpritesUSA = new Sprite[8];
    [SerializeField] private Sprite[] UpgradeSpritesSoviet = new Sprite[8];
    [SerializeField] private Sprite ObliterateTower;

    public Sprite Locked;

    [SerializeField] private Text CostField;
    [SerializeField] private Text DescriptionField;

    [SerializeField] private UpgradeSystemScript upgradeSystemScript;
    [SerializeField] private PlayerScript playerScript;
    
    private GameUIScript _uiScript;

    [Header("Tower Upgrades")]
    [SerializeField] private Sprite obliterationTowerSprite;
    [SerializeField] private AnimatorOverrideController obliterationTowerAnimator;
    private GenericTowerScript _playerTower;

    [Header("Line Colors")] 
    private bool _upgradeBought;
    [SerializeField] private Color32 greenLineColor;
    [SerializeField] private Color32 redLineColor;
    [SerializeField] private Color32 purpleLineColor;
    [SerializeField] private float crossFadeColorSpeed = 0.5f;

    private void Start()
    {
        _uiScript = GetComponent<GameUIScript>();
        CostField.text = "";
        DescriptionField.text = "";
        //Setting Tree Image according to Faction
        for (int i = 0; i < 4; i++)
        {
            TreeImages[i].sprite = Faction == PlayerFaction.USA ? TreeSpritesUSA[i] : TreeSpritesSoviet[i];
        }

        //Setting other images in Tree according to Faction
        for (int i = 0; i < 8; i++)
        {
            UpgradeImages[i].sprite = Faction == PlayerFaction.USA ? UpgradeSpritesUSA[i] : UpgradeSpritesSoviet[i];
            UpgradeImages[i].color = Color.black;
        }
        UpgradeImages[8].sprite = Locked;
        Buttons[8].enabled = false;
        for (int i = 9; i < 15; i++)
        {
            UpgradeImages[i].sprite = Locked;
            Buttons[i].enabled = false;
        }
        UpgradeImages[15].sprite = Locked;
        Buttons[15].enabled = false;


        _playerTower = FindObjectsOfType<GenericTowerScript>().First(x => IsPlayer(x.towerFaction));
    }

    //ASTRONAUT, ROVER, TANK AND SPACESHIP TREE FUNCTIONS
    //##############################################################################
    public void UpgradeUnit(GameObject pressedButton)
    {
        GenericUpgradeButtonsScript DescriptionReader = pressedButton.GetComponent<GenericUpgradeButtonsScript>();
        _upgradeBought = playerScript.money >= DescriptionReader.cost;

        if(_upgradeBought)
        {
            Button ButtonComp = pressedButton.GetComponent<Button>();
            Image ImgComp = pressedButton.GetComponent<Image>();

            string entity = pressedButton.name.Substring(0, 5);
            string upgrade = pressedButton.name.Substring(5, 6);
            float upgValue = 0;

            UpgradeSystemScript.UnitType entityType = UpgradeSystemScript.UnitType.None;
            UpgradeSystemScript.StatType upgradeType = UpgradeSystemScript.StatType.None;

            //Choosing correct Entity from Enum list
            entityType = entity == "Astro" ? UpgradeSystemScript.UnitType.Astronaut : entityType;
            entityType = entity == "Rover" ? UpgradeSystemScript.UnitType.LunarRover : entityType;
            entityType = entity == "Tank_" ? UpgradeSystemScript.UnitType.Tank : entityType;
            //entityType = entity == "Ship_" ? UpgradeSystemScript.UnitType.Spaceship : entityType;

            //Choosing correct Upgrade from Enum list
            upgradeType = upgrade == "Life__" ? UpgradeSystemScript.StatType.Health : upgradeType;
            upgradeType = upgrade == "Attack" ? UpgradeSystemScript.StatType.Damage : upgradeType;
            upgradeType = upgrade == "Speed_" ? UpgradeSystemScript.StatType.Speed : upgradeType;

            //Choosing correct value used for upgrade
            upgValue = upgrade == "Life__" ? 0.25f : upgValue;
            upgValue = upgrade == "Attack" ? 0.25f : upgValue;
            upgValue = upgrade == "Speed_" ? 0.2f : upgValue;

            ButtonComp.enabled = false;
            ImgComp.color = Color.white;
            DescriptionReader.showCost = false;
            CostField.text = "Cost: BOUGHT";
            playerScript.money -= DescriptionReader.cost;
            _uiScript.UpdateMoney(playerScript.money);
            upgradeSystemScript.IncreaseUnitStatisticsMultiplier(entityType, upgradeType, upgValue);
            LockAndLoadUnitTree(pressedButton);
        }
    }

    #region Line Color Change Methods

    public void ChangeLineColorToGreen(GameObject linesParent)
    {
        if (!_upgradeBought) return;
        
        var images = linesParent.GetComponentsInChildren<Image>().ToList();
        images.ForEach(x =>
        { 
            x.CrossFadeColor(greenLineColor, crossFadeColorSpeed, true, false);
            x.color = greenLineColor;
        });
    }
    public void ChangeLineColorToRed(GameObject linesParent)
    {
        if (!_upgradeBought) return;
        
        var images = linesParent.GetComponentsInChildren<Image>().ToList();
        images.ForEach(x =>
        {
            x.CrossFadeColor(redLineColor, crossFadeColorSpeed, true, false);
            x.color = redLineColor;
        });
    }
    public void ChangeLineColorToPurple(GameObject linesParent)
    {
        if (!_upgradeBought) return;
        
        var images = linesParent.GetComponentsInChildren<Image>().ToList();
        images.ForEach(x =>
        { 
            x.CrossFadeColor(purpleLineColor, crossFadeColorSpeed, true, false);
            x.color = purpleLineColor;
        });
    }

    #endregion

    public void LockAndLoadUnitTree(GameObject changer)
    {
        //Astronauts Tree
        //Second HP
        Buttons[8].enabled = changer.name == "AstroLife__1" || Buttons[8].enabled;
        UpgradeImages[8].sprite = changer.name == "AstroLife__1" ? (Faction == PlayerFaction.USA ? UpgradeSpritesUSA[0] : UpgradeSpritesSoviet[0]) : UpgradeImages[8].sprite;
        UpgradeImages[8].color = changer.name == "AstroLife__1" ? Color.black : UpgradeImages[8].color;

        //Rover Tree
        //Second Speed
        Buttons[9].enabled = changer.name == "RoverSpeed_1" || Buttons[9].enabled;
        UpgradeImages[9].sprite = changer.name == "RoverSpeed_1" ? (Faction == PlayerFaction.USA ? UpgradeSpritesUSA[2] : UpgradeSpritesSoviet[2]) : UpgradeImages[9].sprite;
        UpgradeImages[9].color = changer.name == "RoverSpeed_1" ? Color.black : UpgradeImages[9].color;
        //Second HP
        Buttons[10].enabled = changer.name == "RoverLife__2" || Buttons[10].enabled;
        UpgradeImages[10].sprite = changer.name == "RoverLife__2" ? (Faction == PlayerFaction.USA ? UpgradeSpritesUSA[3] : UpgradeSpritesSoviet[3]) : UpgradeImages[10].sprite;
        UpgradeImages[10].color = changer.name == "RoverLife__2" ? Color.black : UpgradeImages[10].color;
        //Second Attack
        Buttons[11].enabled = changer.name == "RoverAttack1" || Buttons[11].enabled;
        UpgradeImages[11].sprite = changer.name == "RoverAttack1" ? (Faction == PlayerFaction.USA ? UpgradeSpritesUSA[4] : UpgradeSpritesSoviet[4]) : UpgradeImages[11].sprite;
        UpgradeImages[11].color = changer.name == "RoverAttack1" ? Color.black : UpgradeImages[11].color;

        ///Tank Tree
        //Second HP
        Buttons[12].enabled = changer.name == "Tank_Life__3" || Buttons[12].enabled;
        UpgradeImages[12].sprite = changer.name == "Tank_Life__3" ? (Faction == PlayerFaction.USA ? UpgradeSpritesUSA[5] : UpgradeSpritesSoviet[5]) : UpgradeImages[12].sprite;
        UpgradeImages[12].color = changer.name == "Tank_Life__3" ? Color.black : UpgradeImages[12].color;
    }

    //TOWERS TREE FUNCTIONS
    //##############################################################################
    public void BuildTowers(GameObject pressedButton)
    {
        GenericUpgradeButtonsScript DescriptionReader = pressedButton.GetComponent<GenericUpgradeButtonsScript>();

        if (playerScript.money >= DescriptionReader.cost)
        {
            Button ButtonComp = pressedButton.GetComponent<Button>();
            Image ImgComp = pressedButton.GetComponent<Image>();

            UpgradeSystemScript.TowerType towerType = UpgradeSystemScript.TowerType.None;

            //Choosing correct Tower from Enum list
            towerType = pressedButton.name.Contains("Light") ? UpgradeSystemScript.TowerType.Light : towerType;
            towerType = pressedButton.name.Contains("Heavy") ? UpgradeSystemScript.TowerType.Heavy : towerType;
            towerType = pressedButton.name.Contains("Oblit") ? UpgradeSystemScript.TowerType.Obliterate : towerType;
            
            //Choosing correct value used for upgrade
            var damageUpgValue = towerType == UpgradeSystemScript.TowerType.Light ? 5 : 10;
            var fireRateUpgValue = towerType == UpgradeSystemScript.TowerType.Heavy ? 0 : 0.5f;
            
            //Change tower sprite if upgraded to obliteration tower
            if (towerType == UpgradeSystemScript.TowerType.Obliterate)
            {
                _playerTower.GetComponent<SpriteRenderer>().sprite = obliterationTowerSprite;
                _playerTower.GetComponent<Animator>().runtimeAnimatorController = obliterationTowerAnimator;
            }

            ButtonComp.enabled = false;
            ImgComp.color = Color.white;
            DescriptionReader.showCost = false;
            CostField.text = "Cost: BOUGHT";
            playerScript.money -= DescriptionReader.cost;
            _uiScript.UpdateMoney(playerScript.money);
            _playerTower.UpgradeTower(damageUpgValue, fireRateUpgValue);
            LockAndLoadTowerTree(pressedButton);
        }
    }

    public void LockAndLoadTowerTree(GameObject changer)
    {
        ///Tower Tree
        //First Level Light
        Buttons[7].enabled = changer.name != "TowerLight1" && Buttons[7].enabled;
        UpgradeImages[7].sprite = changer.name == "TowerLight1" ? Locked : UpgradeImages[7].sprite;
        UpgradeImages[7].color = changer.name == "TowerLight1" ? Color.white : UpgradeImages[7].color;
        //First Level Heavy
        Buttons[6].enabled = changer.name != "TowerHeavy1" && Buttons[6].enabled;
        UpgradeImages[6].sprite = changer.name == "TowerHeavy1" ? Locked : UpgradeImages[6].sprite;
        UpgradeImages[6].color = changer.name == "TowerHeavy1" ? Color.white : UpgradeImages[6].color;
        //First Level Both
        if (changer.name == "TowerLight1" || changer.name == "TowerHeavy1")
        {
            Buttons[13].enabled = true;
            UpgradeImages[13].sprite = Faction == PlayerFaction.USA ? UpgradeSpritesUSA[6] : UpgradeSpritesSoviet[6];
            UpgradeImages[13].color = Color.black;
            Buttons[14].enabled = true;
            UpgradeImages[14].sprite = Faction == PlayerFaction.USA ? UpgradeSpritesUSA[7] : UpgradeSpritesSoviet[7];
            UpgradeImages[14].color = Color.black;
        }

        //Second Level Light
        Buttons[14].enabled = changer.name != "TowerLight2" && Buttons[14].enabled;
        UpgradeImages[14].sprite = changer.name == "TowerLight2" ? Locked : UpgradeImages[14].sprite;
        UpgradeImages[14].color = changer.name == "TowerLight2" ? Color.white : UpgradeImages[14].color;
        //Second Level Heavy
        Buttons[13].enabled = changer.name != "TowerHeavy2" && Buttons[13].enabled;
        UpgradeImages[13].sprite = changer.name == "TowerHeavy2" ? Locked : UpgradeImages[13].sprite;
        UpgradeImages[13].color = changer.name == "TowerHeavy2" ? Color.white : UpgradeImages[13].color;
        //Second Level Both
        if (changer.name == "TowerLight2" || changer.name == "TowerHeavy2")
        {
            Buttons[15].enabled = true;
            UpgradeImages[15].sprite = ObliterateTower;
            UpgradeImages[15].color = Color.black;
        }
    }

    //DESCRIPTION FUNCTION
    //##############################################################################
    public void ShowDescription(GameObject changer)
    {
        GenericUpgradeButtonsScript DescriptionReader = changer.GetComponent<GenericUpgradeButtonsScript>();
        CostField.text = DescriptionReader.showCost == true ? "Cost: " + DescriptionReader.cost.ToString() + UIMoneyMark : "Cost: BOUGHT";
        DescriptionField.text = DescriptionReader.description.ToString();
    }

    public void HideDescription()
    {
        CostField.text = "";
        DescriptionField.text = "";
    }
}