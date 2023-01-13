using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitUpgradeScript : MonoBehaviour
{
    public UpgradeValues AstronautUpgradeValues;
    public UpgradeValues LunarUpgradeValues;
    public UpgradeValues TankUpgradeValues;
    public UpgradeValues SpaceshipUpgradeValues;

    private void Start()
    {
        AstronautUpgradeValues = new UpgradeValues(1, 1, 1, 1, 1);
        LunarUpgradeValues = new UpgradeValues(1, 1, 1, 1, 1);
        TankUpgradeValues = new UpgradeValues(1, 1, 1, 1, 1);
        SpaceshipUpgradeValues = new UpgradeValues(1, 1, 1, 1, 1);
    }
}
