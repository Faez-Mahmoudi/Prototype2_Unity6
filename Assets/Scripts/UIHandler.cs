using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
# if UNITY_EDITOR
using UnityEditor;
# endif

public class UIHandler : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject powerupPrefab;
    [SerializeField] private GameObject livePearPrefab;
    public bool paused;
    private int score = 0;
    private int lives = 3;
    private int nextPowerupScore = 50;
    private int nextLiveScore = 100;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI yourScoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameActive)
            gameOverPanel.gameObject.SetActive(true);
        else
            gameOverPanel.gameObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Escape))
            ChangePause();

        yourScoreText.SetText("Your score: " + score);
    }

    public void AddLives(int value)
    {
        lives += value;
        if(lives <= 0)
        {
            lives = 0;
            GameManager.Instance.isGameActive = false;
            bestScoreText.SetText("Best Score: " + GameManager.Instance.bestScore);
        }
        livesText.text = "Lives = " + lives;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.SetText("Score = " + score);

        if (score > GameManager.Instance.bestScore)
        {
            GameManager.Instance.bestScore = score;
            bestScoreText.SetText("Best Score: " + GameManager.Instance.bestScore);
        }

        while (score >= nextPowerupScore)
        {
            Vector3 pos = new Vector3(Random.Range(-10, 10), 1, Random.Range(0, 10));
            Instantiate(powerupPrefab, pos, powerupPrefab.transform.rotation);
            nextPowerupScore += 100;            
        }

        while (score >= nextLiveScore)
        {
            Vector3 pos = new Vector3(Random.Range(-10, 10), 1, Random.Range(0, 10));
            Instantiate(livePearPrefab, pos, livePearPrefab.transform.rotation);
            nextLiveScore += 100;            
        }
    }

    public void ChangePause()
    {
        if (GameManager.Instance.isGameActive)
        {
            if(!paused)
            {
                paused = true;
                pausePanel.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                paused = false;
                pausePanel.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.isGameActive = true;
    }

    public void Exit()
    {
        GameManager.Instance.SaveScore();

        # if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        # else
        Application.Quit();
        # endif
    }
}
