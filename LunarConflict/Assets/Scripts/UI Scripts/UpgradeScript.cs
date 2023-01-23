using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SettingsScript;

public class UpgradeScript : MonoBehaviour
{
    //THIS IS ONLY PROTOTYPE VERSION (DON'T SHOUT ON ME PLEASE xd)
    //13.01.2023 And this is still here as "Prototype" :-D
    //13.01.2023 20:56:22 Not anymore "Prototype" :d

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

    private void Start()
    {
        _uiScript = GetComponent<GameUIScript>();
        CostField.text = "";
        DescriptionField.text = "";
        //Setting Tree Image according to Faction
        for (int i = 0; i < 4; i++)
        {
            TreeImages[i].sprite = SettingsScript.Faction == SettingsScript.PlayerFaction.USA ? TreeSpritesUSA[i] : TreeSpritesSoviet[i];
        }

        //Setting other images in Tree according to Faction
        for (int i = 0; i < 8; i++)
        {
            UpgradeImages[i].sprite = SettingsScript.Faction == SettingsScript.PlayerFaction.USA ? UpgradeSpritesUSA[i] : UpgradeSpritesSoviet[i];
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
    }

    //ASTRONAUT, ROVER, TANK AND SHIP TREE FUNCTIONS
    //##############################################################################
    public void UpgradeUnit(GameObject pressedButton)
    {
        GenericUpgradeButtonsScript DescriptionReader = pressedButton.GetComponent<GenericUpgradeButtonsScript>();

        if(playerScript.money >= DescriptionReader.cost)
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

    public void LockAndLoadUnitTree(GameObject changer)
    {
        ///Astronauts Tree
        //Second HP
        Buttons[8].enabled = changer.name == "AstroLife__1" ? true : Buttons[8].enabled;
        UpgradeImages[8].sprite = changer.name == "AstroLife__1" ? (SettingsScript.Faction == SettingsScript.PlayerFaction.USA ? UpgradeSpritesUSA[0] : UpgradeSpritesSoviet[0]) : UpgradeImages[8].sprite;
        UpgradeImages[8].color = changer.name == "AstroLife__1" ? Color.black : UpgradeImages[8].color;

        ///Rover Tree
        //Second Speed
        Buttons[9].enabled = changer.name == "RoverSpeed_1" ? true : Buttons[9].enabled;
        UpgradeImages[9].sprite = changer.name == "RoverSpeed_1" ? (SettingsScript.Faction == SettingsScript.PlayerFaction.USA ? UpgradeSpritesUSA[2] : UpgradeSpritesSoviet[2]) : UpgradeImages[9].sprite;
        UpgradeImages[9].color = changer.name == "RoverSpeed_1" ? Color.black : UpgradeImages[9].color;
        //Second HP
        Buttons[10].enabled = changer.name == "RoverLife__2" ? true : Buttons[10].enabled;
        UpgradeImages[10].sprite = changer.name == "RoverLife__2" ? (SettingsScript.Faction == SettingsScript.PlayerFaction.USA ? UpgradeSpritesUSA[3] : UpgradeSpritesSoviet[3]) : UpgradeImages[10].sprite;
        UpgradeImages[10].color = changer.name == "RoverLife__2" ? Color.black : UpgradeImages[10].color;
        //Second Attack
        Buttons[11].enabled = changer.name == "RoverAttack1" ? true : Buttons[11].enabled;
        UpgradeImages[11].sprite = changer.name == "RoverAttack1" ? (SettingsScript.Faction == SettingsScript.PlayerFaction.USA ? UpgradeSpritesUSA[4] : UpgradeSpritesSoviet[4]) : UpgradeImages[11].sprite;
        UpgradeImages[11].color = changer.name == "RoverAttack1" ? Color.black : UpgradeImages[11].color;

        ///Tank Tree
        //Second HP
        Buttons[12].enabled = changer.name == "Tank_Life__3" ? true : Buttons[12].enabled;
        UpgradeImages[12].sprite = changer.name == "Tank_Life__3" ? (SettingsScript.Faction == SettingsScript.PlayerFaction.USA ? UpgradeSpritesUSA[5] : UpgradeSpritesSoviet[5]) : UpgradeImages[12].sprite;
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

            string defenceType = pressedButton.name.Substring(5, 5);

            UpgradeSystemScript.TowerType towerType = UpgradeSystemScript.TowerType.None;

            //Choosing correct Tower from Enum list
            towerType = defenceType == "Light" ? UpgradeSystemScript.TowerType.Light : towerType;
            towerType = defenceType == "Heavy" ? UpgradeSystemScript.TowerType.Heavy : towerType;
            towerType = defenceType == "Oblit" ? UpgradeSystemScript.TowerType.Obliterate : towerType;

            ButtonComp.enabled = false;
            ImgComp.color = Color.white;
            DescriptionReader.showCost = false;
            CostField.text = "Cost: BOUGHT";
            playerScript.money -= DescriptionReader.cost;
            _uiScript.UpdateMoney(playerScript.money);
            LockAndLoadTowerTree(pressedButton);
        }
    }

    public void LockAndLoadTowerTree(GameObject changer)
    {
        ///Tower Tree
        //First Level Light
        Buttons[7].enabled = changer.name == "TowerLight1" ? false : Buttons[7].enabled;
        UpgradeImages[7].sprite = changer.name == "TowerLight1" ? Locked : UpgradeImages[7].sprite;
        UpgradeImages[7].color = changer.name == "TowerLight1" ? Color.white : UpgradeImages[7].color;
        //First Level Heavy
        Buttons[6].enabled = changer.name == "TowerHeavy1" ? false : Buttons[6].enabled;
        UpgradeImages[6].sprite = changer.name == "TowerHeavy1" ? Locked : UpgradeImages[6].sprite;
        UpgradeImages[6].color = changer.name == "TowerHeavy1" ? Color.white : UpgradeImages[6].color;
        //First Level Both
        if (changer.name == "TowerLight1" || changer.name == "TowerHeavy1")
        {
            Buttons[13].enabled = true;
            UpgradeImages[13].sprite = SettingsScript.Faction == SettingsScript.PlayerFaction.USA ? UpgradeSpritesUSA[6] : UpgradeSpritesSoviet[6];
            UpgradeImages[13].color = Color.black;
            Buttons[14].enabled = true;
            UpgradeImages[14].sprite = SettingsScript.Faction == SettingsScript.PlayerFaction.USA ? UpgradeSpritesUSA[7] : UpgradeSpritesSoviet[7];
            UpgradeImages[14].color = Color.black;
        }

        //Second Level Light
        Buttons[14].enabled = changer.name == "TowerLight2" ? false : Buttons[14].enabled;
        UpgradeImages[14].sprite = changer.name == "TowerLight2" ? Locked : UpgradeImages[14].sprite;
        UpgradeImages[14].color = changer.name == "TowerLight2" ? Color.white : UpgradeImages[14].color;
        //Second Level Heavy
        Buttons[13].enabled = changer.name == "TowerHeavy2" ? false : Buttons[13].enabled;
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