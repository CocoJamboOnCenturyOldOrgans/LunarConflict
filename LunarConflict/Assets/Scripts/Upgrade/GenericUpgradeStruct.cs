public class UpgradeValues
{
    public float healthModifier { get; set; }
    public float damageModifier { get; set; }
    public float fireRateModifier { get; set; }
    public float speedModifier { get; set; }
    public float unitCostModifier { get; set; }

    public UpgradeValues(
        float health,
        float damage,
        float fireRate,
        float speed,
        float unitCost)
    {
        healthModifier = health;
        damageModifier = damage;
        fireRateModifier = fireRate;
        speedModifier = speed;
        unitCostModifier = unitCost;
    }
}