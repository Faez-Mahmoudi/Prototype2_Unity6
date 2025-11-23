using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 15.0f;
    private float xRange = 15.0f;
    private float zMIn = -1.5f;
    private float zMax = 15.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player horizontally
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        // Move the player vertically
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);

        // Keep the player in bound
        if(transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if(transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        if(transform.position.z < zMIn)
            transform.position = new Vector3(transform.position.x, transform.position.y, zMIn);
        if(transform.position.z > zMax)
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
        
        // Instantiate projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
        }
    }
}
