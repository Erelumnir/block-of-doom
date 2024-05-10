using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configuration/GameConfig")]
public class GameConfig : ScriptableObject
{
    [Header("Game Settings")]
    public int initialLives = 3;
    public int initialScore = 0;
    public int currentLevel = 1;
    public int currentExperience = 0;

    [Header("Ball Settings")]
    public float ballInitialSpeed = 1f;
    public float ballSpeedIncrement = 0.1f;
    public float ballMaxSpeed = 15f;
    public int ballDamage = 1;
    public int ballSpawnAmount = 1;

    [Header("Points Settings")]
    public int pointsPerBlockHit = 10;
    public int pointsPerBlockDestroyed = 50;

    [Header("Paddle Settings")]
    public float paddleMoveSpeed = 1.0f;
    public float paddleWidth = 1f;

    [Header("Block & Spawner Settings")]
    public Vector2 rowsAndColumns = new Vector2(4,4);
    public Vector3 spawnerOrigin = new Vector3(-1.5f, 1, 0);
    public float blockSpacing = 0f;
    public int blockHealth = 2;

    [Header("Upgrade Settings")]
    public float paddleSizeUpgradeIncrement = 0.1f;
    public float ballSpeedUpgradeIncrement = 0.2f;
    public int amountOfBallsAdded = 1;
    public float scoreMultiplier = 0.1f;

    public void ApplyUpgrades(PlayerUpgrades playerUpgrades)
    {
        if (playerUpgrades == null) return;

        if (playerUpgrades.upgrades.ContainsKey(UpgradeType.PaddleSizeIncrease))
        {
            paddleWidth += paddleSizeUpgradeIncrement;
        }

        if (playerUpgrades.upgrades.ContainsKey(UpgradeType.BallSpeedIncrease))
        {
            ballInitialSpeed += ballSpeedUpgradeIncrement;
        }

        if (playerUpgrades.upgrades.ContainsKey(UpgradeType.ExtraBalls))
        {
            ballSpawnAmount += amountOfBallsAdded;
        }

        if (playerUpgrades.upgrades.ContainsKey(UpgradeType.ScoreMultiplier))
        {
            int newRoundedHitResult = Mathf.RoundToInt((float)pointsPerBlockHit * (1 +  (scoreMultiplier * playerUpgrades.GetUpgradeLevel(UpgradeType.ScoreMultiplier))));
            pointsPerBlockHit = newRoundedHitResult;
            int newRoundedDestroyedResult = Mathf.RoundToInt((float)pointsPerBlockDestroyed * (1 + (scoreMultiplier * playerUpgrades.GetUpgradeLevel(UpgradeType.ScoreMultiplier))));
            pointsPerBlockDestroyed = newRoundedDestroyedResult;
        }
        // Repeat for other upgrades
    }

}


