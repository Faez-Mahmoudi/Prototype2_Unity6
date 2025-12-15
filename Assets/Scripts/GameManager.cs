using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    public int bestScore;
    public bool isGameActive;

    // Save bestScore
    [System.Serializable]
    class SaveData
    {
        public int b_Score;
    }

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
       LoadScore();
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.b_Score = bestScore;

        string json  = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScore = data.b_Score;
        }
        else
        {
            bestScore = 0;
        }
    }
}
