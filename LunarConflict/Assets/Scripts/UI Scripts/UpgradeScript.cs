using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    //THIS IS ONLY PROTOTYPE VERSION (DON'T SHOUT ON ME PLEASE xd)
    //13.01.2023 And this is still here as "Prototype" :-D
    [SerializeField] private Image UpgradeA1;
    [SerializeField] private Button ButtonA1;

    [SerializeField] private Image UpgradeA2;
    [SerializeField] private Button ButtonA2;

    [SerializeField] private Image UpgradeA3;
    [SerializeField] private Button ButtonA3;


    [SerializeField] private Image UpgradeR1;
    [SerializeField] private Button ButtonR1;

    [SerializeField] private Image UpgradeR2;
    [SerializeField] private Button ButtonR2;

    [SerializeField] private Image UpgradeR3;
    [SerializeField] private Button ButtonR3;

    [SerializeField] private Image UpgradeR4;
    [SerializeField] private Button ButtonR4;

    [SerializeField] private Image UpgradeR5;
    [SerializeField] private Button ButtonR5;

    [SerializeField] private Image UpgradeR6;
    [SerializeField] private Button ButtonR6;

    [SerializeField] private Image UpgradeT1;
    [SerializeField] private Button ButtonT1;

    [SerializeField] private Image UpgradeT2;
    [SerializeField] private Button ButtonT2;

    [SerializeField] private Image UpgradeTo1;
    [SerializeField] private Button ButtonTo1;

    [SerializeField] private Image UpgradeTo2;
    [SerializeField] private Button ButtonTo2;

    [SerializeField] private Image UpgradeTo3;
    [SerializeField] private Button ButtonTo3;

    [SerializeField] private Image UpgradeTo4;
    [SerializeField] private Button ButtonTo4;

    [SerializeField] private Image UpgradeTo5;
    [SerializeField] private Button ButtonTo5;

    [SerializeField] private Image UpgradeB1;
    [SerializeField] private Button ButtonB1;

    [SerializeField] private Image UpgradeB2;
    [SerializeField] private Button ButtonB2;

    public Sprite Locked;
    public Sprite Available;
    public Sprite Bought;

    [SerializeField] private UpgradeSystemScript upgradeSystemScript;
    private void Start()
    {
        UpgradeA1.sprite = Available;
        UpgradeA2.sprite = Locked;
        UpgradeA3.sprite = Available;
        UpgradeR1.sprite = Available;
        UpgradeR2.sprite = Locked;
        UpgradeR3.sprite = Available;
        UpgradeR4.sprite = Locked;
        UpgradeR5.sprite = Available;
        UpgradeR6.sprite = Locked;
        UpgradeT1.sprite = Available;
        UpgradeT2.sprite = Locked;
        UpgradeTo1.sprite = Available;
        UpgradeTo2.sprite = Locked;
        UpgradeTo3.sprite = Available;
        UpgradeTo4.sprite = Locked;
        UpgradeTo5.sprite = Locked;
        UpgradeB1.sprite = Available;
        UpgradeB2.sprite = Available;

        ButtonA1.enabled = true;
        ButtonA2.enabled = false;
        ButtonA3.enabled = true;
        ButtonR1.enabled = true;
        ButtonR2.enabled = false;
        ButtonR3.enabled = true;
        ButtonR4.enabled = false;
        ButtonR5.enabled = true;
        ButtonR6.enabled = false;
        ButtonT1.enabled = true;
        ButtonT2.enabled = false;
        ButtonTo1.enabled = true;
        ButtonTo2.enabled = false;
        ButtonTo3.enabled = true;
        ButtonTo4.enabled = false;
        ButtonTo5.enabled = false;
        ButtonB1.enabled = true;
        ButtonB2.enabled = true;
    }

    //ASTRONAUT TREE
    //##############################################################################
    public void UpgradeAstronautAttack()
    {
        UpgradeA3.sprite = Bought;
        ButtonA3.enabled = false;
        upgradeSystemScript.IncreaseUnitStatisticsMultiplier(
            UpgradeSystemScript.UnitType.Astronaut,
            UpgradeSystemScript.StatType.Damage,
            0.25f);
    }

    public void UpgradeAstronautHP1()
    {
        UpgradeA1.sprite = Bought;
        UpgradeA2.sprite = Available;
        ButtonA1.enabled = false;
        ButtonA2.enabled = true;
        upgradeSystemScript.IncreaseUnitStatisticsMultiplier(
            UpgradeSystemScript.UnitType.Astronaut,
            UpgradeSystemScript.StatType.Health,
            0.25f);
    }

    public void UpgradeAstronautHP2()
    {
        UpgradeA2.sprite = Bought;
        ButtonA2.enabled = false;
        upgradeSystemScript.IncreaseUnitStatisticsMultiplier(
            UpgradeSystemScript.UnitType.Astronaut,
            UpgradeSystemScript.StatType.Health,
            0.25f);
    }

    //ROVER TREE
    //##############################################################################
    public void UpgradeRoverSpeed1()
    {
        UpgradeR1.sprite = Bought;
        UpgradeR2.sprite = Available;
        ButtonR1.enabled = false;
        ButtonR2.enabled = true;
    }

    public void UpgradeRoverSpeed2()
    {
        UpgradeR2.sprite = Bought;
        ButtonR2.enabled = false;
    }

    public void UpgradeRoverHP1()
    {
        UpgradeR3.sprite = Bought;
        UpgradeR4.sprite = Available;
        ButtonR3.enabled = false;
        ButtonR4.enabled = true;
    }

    public void UpgradeRoverHP2()
    {
        UpgradeR4.sprite = Bought;
        ButtonR4.enabled = false;
    }

    public void UpgradeRoverAttack1()
    {
        UpgradeR5.sprite = Bought;
        UpgradeR6.sprite = Available;
        ButtonR5.enabled = false;
        ButtonR6.enabled = true;
    }

    public void UpgradeRoverAttack2()
    {
        UpgradeR6.sprite = Bought;
        ButtonR6.enabled = false;
    }

    //Tank Tree
    //##############################################################################
    public void UpgradeTankHP()
    {
        UpgradeT1.sprite = Bought;
        UpgradeT2.sprite = Available;
        ButtonT1.enabled = false;
        ButtonT2.enabled = true;
    }

    public void UpgradeTankAttack()
    {
        UpgradeT2.sprite = Bought;
        ButtonT2.enabled = false;
    }

    //Tower Tree
    //##############################################################################
    public void UpgradeTowerLight1()
    {
        UpgradeTo1.sprite = Bought;
        UpgradeTo2.sprite = Available;
        UpgradeTo3.sprite = Locked;
        UpgradeTo4.sprite = Available;
        ButtonTo1.enabled = false;
        ButtonTo2.enabled = true;
        ButtonTo3.enabled = false;
        ButtonTo4.enabled = true;
    }

    public void UpgradeTowerHeavy1()
    {
        UpgradeTo1.sprite = Locked;
        UpgradeTo2.sprite = Available;
        UpgradeTo3.sprite = Bought;
        UpgradeTo4.sprite = Available;
        ButtonTo1.enabled = false;
        ButtonTo2.enabled = true;
        ButtonTo3.enabled = false;
        ButtonTo4.enabled = true;
    }


    public void UpgradeTowerLight2()
    {
        UpgradeTo2.sprite = Bought;
        UpgradeTo4.sprite = Locked;
        UpgradeTo5.sprite = Available;
        ButtonTo2.enabled = false;
        ButtonTo4.enabled = false;
        ButtonTo5.enabled = true;
    }

    public void UpgradeTowerHeavy2()
    {
        UpgradeTo2.sprite = Locked;
        UpgradeTo4.sprite = Bought;
        UpgradeTo5.sprite = Available;
        ButtonTo2.enabled = false;
        ButtonTo4.enabled = false;
        ButtonTo5.enabled = true;
    }

    public void UpgradeTowerLast()
    {
        UpgradeTo5.sprite = Bought;
        ButtonTo5.enabled = false;
    }

    //Base Tree
    //##############################################################################
    public void UpgradeBank()
    {
        UpgradeB1.sprite = Bought;
        ButtonB1.enabled = false;
    }

    public void UpgradeFactory()
    {
        UpgradeB2.sprite = Bought;
        ButtonB2.enabled = false;
    }
}