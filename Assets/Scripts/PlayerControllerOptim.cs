using UnityEngine;

public class PlayerControllerOptim : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;
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
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        // Move the player vertically
        float verticalInput = Input.GetAxis("Vertical");
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
            // Get an onject from the pool
            GameObject pooledProjecctile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjecctile != null)
            {
                pooledProjecctile.SetActive(true); // Ativate it
                pooledProjecctile.transform.position = transform.position; // Position it at player
            } 
        }
    }
}
