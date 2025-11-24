using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int lives = 3;

    //UI
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLives(int value)
    {
        lives += value;
        if(lives <= 0)
        {
            Debug.Log("Game Over!!");
            lives = 0;
        }
        livesText.text = "Lives = " + lives;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.SetText("Score = " + score);
    }
}
