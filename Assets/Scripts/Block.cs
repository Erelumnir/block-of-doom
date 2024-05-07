using UnityEngine;

public class Block : MonoBehaviour
{
    public int maxHp = 2; // Maximum health of the block
    private int currentHp;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHp = maxHp;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    public void TakeDamage(int damage)
    {
        GameManager.Instance.IncreaseScore(10);
        currentHp -= damage;

        UpdateColor();
        if (currentHp <= 0)
        {
            GameManager.Instance.IncreaseScore(50);
            DestroyBlock();
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
        // Update the game score or any other relevant game events here
        //GameManager.Instance.IncreaseScore(10); // Increment score by 10 for each block destroyed
        Destroy(gameObject);
    }
}
