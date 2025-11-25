using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;
    private float spawnRangeX = 15.0f;
    private float spawnPosZ = 20.0f;
    private float sideSpawnMinZ = 3.0f;
    private float sideSpawnMaxZ = 15.0f;
    private float sideSpawnX = 20.0f;

    [SerializeField] private float startDelay = 2.0f;
    [SerializeField] private float spawnInterval = 1.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(gameObject.name, startDelay, spawnInterval);
    }

    // Spawn random animal in the scene
    void SpawnRandomAnimal()
    {
        if (GameManager.Instance.isGameActive)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }
    }

    // Spawn random animal from left side
    void SpawnLeftAnimal()
    {
        if (GameManager.Instance.isGameActive)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
            Vector3 rotation = new Vector3(0, 90, 0);
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
        }
    } 

    // Spawn random animal from right side
    void SpawnRightAnimal()
    {
        if (GameManager.Instance.isGameActive)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
            Vector3 rotation = new Vector3(0, -90, 0);
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
        }
    } 
}
