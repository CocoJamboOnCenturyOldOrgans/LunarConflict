using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeSystemScript : MonoBehaviour
{
    public enum UnitType
    {
        Astronaut,
        LunarRover,
        Tank,
        Spaceship
    }

    public enum StatType
    {
        Health,
        Damage,
        FireRate,
        Speed,
        UnitCost
    }

    private UnitUpgradeScript playerUpgrades;

    void Start()
    {
        playerUpgrades = GetComponent<UnitUpgradeScript>();
    }

    public void IncreaseUnitStatisticsMultiplier(
        UnitType unit, StatType stat, float increase)
    {
        UpgradeValues upgradeValue = assignUpgradeValue(unit);
        switch (stat)
        {
            case StatType.Health:
                upgradeValue.healthModifier += increase;
                break;
            case StatType.Damage:
                upgradeValue.damageModifier += increase;
                break;
            case StatType.FireRate:
                upgradeValue.fireRateModifier += increase;
                break;
            case StatType.UnitCost:
                upgradeValue.unitCostModifier += increase;
                break;
            case StatType.Speed:
                upgradeValue.speedModifier += increase;
                break;
        }
    }

    private UpgradeValues assignUpgradeValue(UnitType unit)
    {
        switch (unit)
        {
            case UnitType.Astronaut:
                return playerUpgrades.AstronautUpgradeValues;
            case UnitType.LunarRover:
                return playerUpgrades.LunarUpgradeValues;
            case UnitType.Tank:
                return playerUpgrades.TankUpgradeValues;
            case UnitType.Spaceship:
                return playerUpgrades.SpaceshipUpgradeValues;
        }

        throw new Exception();
    }
}