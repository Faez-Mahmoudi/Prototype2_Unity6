using UnityEngine;

public class DestroyOutOfBoundOptim : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    private float sideBound = 30.0f;
    private UIHandler uiHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiHandler = GameObject.Find("Canvas").GetComponent<UIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound)
            gameObject.SetActive(false);
        else if(transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            uiHandler.AddLives(-1);
        }
        else if(transform.position.x > sideBound)
        {
            Destroy(gameObject);
            uiHandler.AddLives(-1);
        }
        else if(transform.position.x < -sideBound)
        {
            Destroy(gameObject);
            uiHandler.AddLives(-1);
        }   
    }
}
