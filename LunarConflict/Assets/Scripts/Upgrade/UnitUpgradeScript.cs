using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitUpgradeScript : MonoBehaviour
{
    public UpgradeValues astronautUpgradeValues;
    public UpgradeValues lunarUpgradeValues;
    public UpgradeValues tankUpgradeValues;

    private void Start()
    {
        astronautUpgradeValues = new UpgradeValues(1, 1, 1, 1, 1);
        lunarUpgradeValues = new UpgradeValues(1, 1, 1, 1, 1);
        tankUpgradeValues = new UpgradeValues(1, 1, 1, 1, 1);
    }
}
