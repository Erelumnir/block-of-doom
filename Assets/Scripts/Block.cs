using UnityEngine;

public class Block : MonoBehaviour
{
    public GameConfig config;

    int maxHp;
    private int currentHp;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        maxHp = config.blockHealth;
        currentHp = maxHp;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    public void TakeDamage(int damage)
    {
        GameManager.Instance.IncreaseScore(10);
        currentHp -= damage;

        UpdateColor();
        AudioManager.Instance.PlayHitSound();

        if (currentHp <= 0)
        {
            DestroyBlock();
        } 
        else
        {
            AudioManager.Instance.IncreasePitch();
        }
    }

    void UpdateColor()
    {
        // Change color based on HP (simple gradient from green to red)
        float colorValue = currentHp / (float)maxHp;
        spriteRenderer.color = new Color(1 - colorValue, colorValue, 0);
    }

    void DestroyBlock()
    {
        GameManager.Instance.IncreaseScore(50);
        Destroy(gameObject);
        GameManager.Instance.totalBlocks--;
    }
}
