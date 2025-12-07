using UnityEngine;
using System.Collections;

public class PlayerControllerOptim : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;
    [SerializeField] private GameObject foodSpawnPosRight;
    [SerializeField] private GameObject foodSpawnPosLeft;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject powerupPanel;
    [SerializeField] private GameObject livePanel;
    private Vector3 offset = new Vector3(0.0f, 0.5f, 1.5f);
    private float xRange = 15.0f;
    private float zMIn = -1.5f;
    private float zMax = 15.5f;

    private UIHandler uiHandler;

    public bool hasPowerup;

    void Start()
    {
        uiHandler = GameObject.Find("Canvas").GetComponent<UIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        KeepInBound();
        
        if(GameManager.Instance.isGameActive)
            FoodFire();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupPanel.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }

        if(other.CompareTag("LivePear"))
        {
            Destroy(other.gameObject);
            livePanel.gameObject.SetActive(true);
            uiHandler.AddLives(1);
            StartCoroutine(LiveCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupPanel.gameObject.SetActive(false);
    }

    IEnumerator LiveCountdownRoutine()
    {
        yield return new WaitForSeconds(1);
        livePanel.gameObject.SetActive(false);
    }

    public void Move()
    {
        // Move the player horizontally
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        // Move the player vertically
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
    }

    public void KeepInBound()
    {
        // Keep the player in bound
        if(transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if(transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        if(transform.position.z < zMIn)
            transform.position = new Vector3(transform.position.x, transform.position.y, zMIn);
        if(transform.position.z > zMax)
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
    }

    public void FoodFire()
    {
        // Instantiate projectile
        if(Input.GetKeyDown(KeyCode.Space) && !uiHandler.paused)
        {
            if (!hasPowerup)
            {
                foodSpawnPosLeft.gameObject.SetActive(false);
                foodSpawnPosRight.gameObject.SetActive(false);

                GameObject pooledProjecctile = ObjectPooler.SharedInstance.GetPooledObject();
                
                if (pooledProjecctile != null)
                {
                    pooledProjecctile.SetActive(true); // Ativate it
                    pooledProjecctile.transform.position = transform.position + offset; // Position it at player
                    pooledProjecctile.transform.rotation = transform.rotation;
                }
            }
            if(hasPowerup)
            {
                foodSpawnPosLeft.gameObject.SetActive(true);
                foodSpawnPosRight.gameObject.SetActive(true);

                // Get an onject from the pool
                for (int i = 0; i < 3; i++)
                {
                    GameObject pooledProjecctile = ObjectPooler.SharedInstance.GetPooledObject();
                    if (pooledProjecctile != null)
                    {
                        pooledProjecctile.SetActive(true); // Ativate it

                        if (i == 0 )
                        {
                            pooledProjecctile.transform.position = transform.position + offset; // Position it at player
                            pooledProjecctile.transform.rotation = transform.rotation;
                        }
                        else if (i == 1)
                        {
                            pooledProjecctile.transform.position = foodSpawnPosRight.transform.position; // Position it at right
                            pooledProjecctile.transform.rotation = foodSpawnPosRight.transform.rotation; // rotation 
                        }
                        else if (i == 2)
                        {
                            pooledProjecctile.transform.position = foodSpawnPosLeft.transform.position; // Position it at left
                            pooledProjecctile.transform.rotation = foodSpawnPosLeft.transform.rotation; // rotation
                        }
                    } 
                }
            }
        }
    }
}
