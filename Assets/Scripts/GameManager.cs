using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public bool isGameRunning;
    public bool dead = false;
    public bool gameOver = false;
    public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        score = 0;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddScore()
    {
        score++;
    }
    public void RestartTheGame()
    {
        dead = false;
        gameOver = false;
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

