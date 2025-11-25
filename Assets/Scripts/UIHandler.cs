using UnityEngine;
using UnityEngine.SceneManagement;
# if UNITY_EDITOR
using UnityEditor;
# endif

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    private bool paused;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameActive)
            gameOverPanel.gameObject.SetActive(true);
        else
            gameOverPanel.gameObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Escape))
            ChangePause();
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
        # if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        # else
        Application.Quit();
        # endif
    }
}
