using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    private int score = 0;
    private int lives = 3;
    public bool isGameActive;

    //UI
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       if (Instance != null)
       {
            Destroy(gameObject);
            return;
       }

       Instance = this;
       DontDestroyOnLoad(gameObject); 
       isGameActive = true;
    }

    public void AddLives(int value)
    {
        lives += value;
        if(lives <= 0)
        {
            lives = 0;
            isGameActive = false;
        }
        livesText.text = "Lives = " + lives;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.SetText("Score = " + score);
    }
}
