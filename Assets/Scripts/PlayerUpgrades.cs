using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    PaddleSizeIncrease,
    BallSpeedIncrease,
    ExtraBalls,
    ScoreMultiplier
}

[CreateAssetMenu(fileName = "PlayerUpgrades", menuName = "Configuration/PlayerUpgrades")]
public class PlayerUpgrades : ScriptableObject
{
    public Dictionary<UpgradeType, int> upgrades;

    public PlayerUpgrades()
    {
        upgrades = new Dictionary<UpgradeType, int>();
    }

    public void PurchaseUpgrade(UpgradeType type)
    {
        if (!upgrades.ContainsKey(type))
            upgrades[type] = 0;
        upgrades[type]++;
    }

    public int GetUpgradeLevel(UpgradeType type)
    {
        if (upgrades.ContainsKey(type))
            return upgrades[type];
        return 0;
    }
}
