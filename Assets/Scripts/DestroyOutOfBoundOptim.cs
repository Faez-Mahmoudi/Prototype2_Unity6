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
        if (gameObject.CompareTag("Food"))
        {
            if(transform.position.z > topBound || transform.position.x > sideBound || transform.position.x > sideBound)
                gameObject.SetActive(false);   
        }
        else if(gameObject.CompareTag("Animal"))
        {
            if(transform.position.z < lowerBound || transform.position.x > sideBound || transform.position.x < -sideBound )
            {
                Destroy(gameObject);
                uiHandler.AddLives(-1);
            } 
        }
        
         
    }
}
