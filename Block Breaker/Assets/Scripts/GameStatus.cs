using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText = null;
    [SerializeField] bool isAutoPlayEnabled = false;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount>1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = "Score: 0";
    }
    
    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
