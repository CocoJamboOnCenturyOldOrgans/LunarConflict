using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    //THIS IS ONLY PROTOTYPE VERSION (DON'T SHOUT ON ME PLEASE xd)
    //13.01.2023 And this is still here as "Prototype" :-D
    //13.01.2023 20:56:22 Not anymore "Prototype" :d

    [SerializeField] private Button[] Buttons = new Button[18];
    [SerializeField] private Image[] Images = new Image[18];

    public Sprite Locked;
    public Sprite Available;
    public Sprite Bought;

    [SerializeField] private UpgradeSystemScript upgradeSystemScript;
    private void Start()
    {
        for(int i = 0; i < 9; i++)
        {
            Buttons[i].enabled = true;
            Images[i].sprite = Available;
        }
        for (int i = 9; i < 18; i++)
        {
            Buttons[i].enabled = i != 16 ? false : true;
            Images[i].sprite = i != 16 ? Locked : Available;
        }
    }

    //ASTRONAUT, ROVER, TANK AND SHIP TREE FUNCTIONS
    //##############################################################################
    public void UpgradeUnit(GameObject pressedButton)
    {
        Button ButtonComp = pressedButton.GetComponent<Button>();
        Image ImgComp = pressedButton.GetComponent<Image>();

        string entity = pressedButton.name.Substring(0, 5);
        string upgrade = pressedButton.name.Substring(5, 6);
        int modifier = 0;
        Int32.TryParse(pressedButton.name.Substring(11, 1), out modifier);
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
        upgValue = upgrade == "Life__" ? 25 : upgValue;
        upgValue = upgrade == "Attack" ? 10 : upgValue;
        upgValue = upgrade == "Speed_" ? 5 : upgValue;

        ButtonComp.enabled = false;
        ImgComp.sprite = Bought;
        upgradeSystemScript.IncreaseUnitStatisticsMultiplier(entityType, upgradeType, modifier * upgValue);
        LockAndLoadUnitTree(pressedButton);
    }

    public void LockAndLoadUnitTree(GameObject changer)
    {
        ///Astronauts Tree
        //Second HP
        Buttons[9].enabled = changer.name == "AstroLife__1" ? true : false;
        Images[9].sprite = changer.name == "AstroLife__1" ? Available : Images[9].sprite;

        ///Rover Tree
        //Second Speed
        Buttons[10].enabled = changer.name == "RoverSpeed_1" ? true : false;
        Images[10].sprite = changer.name == "RoverSpeed_1" ? Available : Images[10].sprite;
        //Second HP
        Buttons[11].enabled = changer.name == "RoverLife__2" ? true : false;
        Images[11].sprite = changer.name == "RoverLife__2" ? Available : Images[11].sprite;
        //Second Attack
        Buttons[12].enabled = changer.name == "RoverAttack1" ? true : false;
        Images[12].sprite = changer.name == "RoverAttack1" ? Available : Images[12].sprite;

        ///Tank Tree
        //Second HP
        Buttons[13].enabled = changer.name == "Tank_Life__3" ? true : false;
        Images[13].sprite = changer.name == "Tank_Life__3" ? Available : Images[13].sprite;
    }

    //TOWERS TREE FUNCTIONS
    //##############################################################################
    public void BuildTowers(GameObject pressedButton)
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
        ImgComp.sprite = Bought;
        LockAndLoadTowerTree(pressedButton);
    }

    public void LockAndLoadTowerTree(GameObject changer)
    {
        ///Tower Tree
        //First Level Light
        Buttons[7].enabled = changer.name == "TowerLight1" ? false : Buttons[7].enabled;
        Images[7].sprite = changer.name == "TowerLight1" ? Locked : Images[7].sprite;
        Buttons[14].enabled = changer.name == "TowerLight1" ? true : Buttons[14].enabled;
        Images[14].sprite = changer.name == "TowerLight1" ? Available : Images[14].sprite;
        Buttons[15].enabled = changer.name == "TowerLight1" ? true : Buttons[15].enabled;
        Images[15].sprite = changer.name == "TowerLight1" ? Available : Images[15].sprite;
        //First Level Heavy
        Buttons[6].enabled = changer.name == "TowerHeavy1" ? false : Buttons[6].enabled;
        Images[6].sprite = changer.name == "TowerHeavy1" ? Locked : Images[6].sprite;
        Buttons[14].enabled = changer.name == "TowerHeavy1" ? true : Buttons[14].enabled;
        Images[14].sprite = changer.name == "TowerHeavy1" ? Available : Images[14].sprite;
        Buttons[15].enabled = changer.name == "TowerHeavy1" ? true : Buttons[15].enabled;
        Images[15].sprite = changer.name == "TowerHeavy1" ? Available : Images[15].sprite;
        
        //Second Level Light
        Buttons[15].enabled = changer.name == "TowerLight2" ? false : Buttons[15].enabled;
        Images[15].sprite = changer.name == "TowerLight2" ? Locked : Images[15].sprite;
        Buttons[17].enabled = changer.name == "TowerLight2" ? true : Buttons[17].enabled;
        Images[17].sprite = changer.name == "TowerLight2" ? Available : Images[17].sprite;

        //Second Level Heavy
        Buttons[14].enabled = changer.name == "TowerHeavy2" ? false : Buttons[14].enabled;
        Images[14].sprite = changer.name == "TowerHeavy2" ? Locked : Images[14].sprite;
        Buttons[17].enabled = changer.name == "TowerHeavy2" ? true : Buttons[17].enabled;
        Images[17].sprite = changer.name == "TowerHeavy2" ? Available : Images[17].sprite;
    }

    //BASE FUNCTIONS
    //##############################################################################
    public void UpgradeBank()
    {
        Images[8].sprite = Bought;
        Buttons[8].enabled = false;
    }

    public void UpgradeFactory()
    {
        Images[16].sprite = Bought;
        Buttons[16].enabled = false;
    }
}