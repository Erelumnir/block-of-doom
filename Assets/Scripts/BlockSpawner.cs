using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public int rows = 4;
    public int columns = 8;
    public float spacing = 0.5f;

    void Start()
    {
        SpawnBlocks();
    }

    void SpawnBlocks()
    {
        Vector2 startPosition = transform.position; // Start spawning at the spawner's position
        Vector2 blockSize = blockPrefab.GetComponent<SpriteRenderer>().bounds.size;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector2 spawnPosition = new Vector2(startPosition.x + (col * (blockSize.x + spacing)),
                                                    startPosition.y - (row * (blockSize.y + spacing)));
                Instantiate(blockPrefab, spawnPosition, Quaternion.identity, transform);
            }
        }
    }

    void OnDrawGizmos()
    {
        Vector2 startPosition = transform.position;
        Vector2 blockSize = new Vector2(1, 1); // Adjust if your block prefab is accessible
        if (blockPrefab)
        {
            blockSize = blockPrefab.GetComponent<SpriteRenderer>().bounds.size;
        }

        Gizmos.color = Color.yellow; // Set Gizmos color to yellow

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector2 spawnPosition = new Vector2(startPosition.x + (col * (blockSize.x + spacing)),
                                                    startPosition.y - (row * (blockSize.y + spacing)));

                // Draw a small cube at each spawn position
                Gizmos.DrawWireCube(spawnPosition, blockSize);
            }
        }
    }
}
