using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    private float sideBound = 30.0f;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound)
            Destroy(gameObject);
        else if(transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            gameManager.AddLives(-1);
        }
        else if(transform.position.x > sideBound)
        {
            Destroy(gameObject);
            gameManager.AddLives(-1);
        }
        else if(transform.position.x < -sideBound)
        {
            Destroy(gameObject);
            gameManager.AddLives(-1);
        }   
    }
}
