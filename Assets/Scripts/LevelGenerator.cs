using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Plank Prefabs")]
    public List<GameObject> redPlankPrefabs;    // Red plank prefabs
    public List<GameObject> bluePlankPrefabs;   // Blue plank prefabs
    public List<GameObject> greenPlankPrefabs;  // Green plank prefabs
    public List<GameObject> yellowPlankPrefabs; // Yellow plank prefabs

    [Header("Level Settings")]
    public int totalPlanks = 12;          // Total number of planks to generate
    public float spawnWidthFraction = 0.4f; // Fraction of the screen width for spawning planks
    public float startYFraction = 0.6f;     // Fraction of the screen height to start spawning
    public float gapYFraction = 0.1f;       // Vertical gap as a fraction of the screen height

    private List<GameObject> spawnedPlanks = new List<GameObject>();

    private void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        ClearLevel(); // Clear previously spawned planks

        // Get screen bounds
        Camera mainCamera = Camera.main;
        float screenWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float screenHeight = mainCamera.orthographicSize;

        float spawnWidth = screenWidth * spawnWidthFraction; // Horizontal spawn range
        float startY = screenHeight * startYFraction;        // Starting Y position
        float gapY = screenHeight * gapYFraction;            // Vertical gap

        // Mix all plank colors
        List<GameObject> mixedPlanks = GetMixedPlanks();

        // Spawn planks
        for (int i = 0; i < totalPlanks; i++)
        {
            // Get a random plank prefab from the mixed list
            GameObject randomPlankPrefab = mixedPlanks[Random.Range(0, mixedPlanks.Count)];

            // Randomize horizontal spawn position
            float randomX = Random.Range(-spawnWidth, spawnWidth);

            // Calculate vertical spawn position
            float spawnY = startY - i * gapY;

            // Instantiate the plank
            GameObject spawnedPlank = Instantiate(randomPlankPrefab, new Vector3(randomX, spawnY, 0), Quaternion.identity , transform);

            // Assign "Plank" layer to the plank
            spawnedPlank.layer = LayerMask.NameToLayer("Plank");

            // Assign the appropriate tag based on the prefab
            if (redPlankPrefabs.Contains(randomPlankPrefab))
                spawnedPlank.tag = "Red";
            else if (bluePlankPrefabs.Contains(randomPlankPrefab))
                spawnedPlank.tag = "Blue";
            else if (greenPlankPrefabs.Contains(randomPlankPrefab))
                spawnedPlank.tag = "Green";
            else if (yellowPlankPrefabs.Contains(randomPlankPrefab))
                spawnedPlank.tag = "Yellow";

            // Track the spawned plank
            spawnedPlanks.Add(spawnedPlank);
        }
    }

    private List<GameObject> GetMixedPlanks()
    {
        // Combine all plank prefabs into a single list
        List<GameObject> allPlanks = new List<GameObject>();
        allPlanks.AddRange(redPlankPrefabs);
        allPlanks.AddRange(bluePlankPrefabs);
        allPlanks.AddRange(greenPlankPrefabs);
        allPlanks.AddRange(yellowPlankPrefabs);

        return allPlanks;
    }

    public void ClearLevel()
    {
        // Destroy all previously spawned planks
        foreach (var plank in spawnedPlanks)
        {
            Destroy(plank);
        }

        spawnedPlanks.Clear();
    }
}
