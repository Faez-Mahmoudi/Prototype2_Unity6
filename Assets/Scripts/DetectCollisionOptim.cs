using UnityEngine;

public class DetectCollisionOptim : MonoBehaviour
{
    private UIHandler uiHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiHandler = GameObject.Find("Canvas").GetComponent<UIHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            uiHandler.AddLives(-1);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Animal"))
        {
            AnimalHunger animalHunger = other.GetComponent<AnimalHunger>();
            animalHunger.hungerSlider.gameObject.SetActive(true);
            animalHunger.FeedAnimal(1);
            uiHandler.AddScore(5);
            gameObject.SetActive(false);
        }   
    }
}
