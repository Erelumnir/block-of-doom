using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameConfig config;

    public GameObject blockPrefab;
    int rows;
    int columns;
    float spacing;

    Vector3 origin;

    private void Awake()
    {
        InitializeSpawner();
    }

    void Start()
    {
        SpawnBlocks();
    }

    void InitializeSpawner()
    {
        rows = (int)config.rowsAndColumns.x;
        columns = (int)config.rowsAndColumns.y;
        spacing = config.blockSpacing;
        origin = config.spawnerOrigin;
    }
    void SpawnBlocks()
    {
        Vector2 startPosition = origin;
        Vector2 blockSize = blockPrefab.GetComponent<SpriteRenderer>().bounds.size;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector2 spawnPosition = new Vector2(startPosition.x + (col * (blockSize.x + spacing)),
                                                    startPosition.y - (row * (blockSize.y + spacing)));
                Instantiate(blockPrefab, spawnPosition, Quaternion.identity, transform);
                GameManager.Instance.totalBlocks++;
                Debug.Log(GameManager.Instance.totalBlocks);
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
