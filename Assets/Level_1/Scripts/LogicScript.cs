using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject pauseScreen;
    public GameObject instructionScreen;
    public GameObject controlsScreen;
    public Text targetText;
    public charactermvmt player;
    public int targetScore = 10; // Set a target score for the game
    public bool isEndless = false; // Flag to indicate if the game is endless
    public int level;
    private string highScoreKey ="";

    void Start()
    {
        isEndless = GameObject.FindGameObjectWithTag("mode").GetComponent<mode_controller>().isEndless; // Check if the game is in endless mode
        level = SceneManager.GetActiveScene().buildIndex;
        
        if (targetText != null && !isEndless)
        {
            targetText.text = "Target: " + targetScore.ToString();
        }
        else if (targetText != null && isEndless)
        {
            startEndless();
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<charactermvmt>();
        Time.timeScale = 0;

    }

    void startEndless()
    {
        highScoreKey = "Level " + level + " HighScore";
        try
        {
            targetScore = PlayerPrefs.GetInt("Level " + level + " HighScore", 0); // Load high score from PlayerPrefs
        }
        catch
        {
            targetScore = 0; // Default to 0 if no high score exists
        }
        targetText.text = "High Score: " + targetScore.ToString();
        showControls();

    }

    void Update()
    {
        checkStatus(); // Check the game status every frame
    }

    public void startGame()
    {
        instructionScreen.SetActive(false);
        controlsScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void addScore(int points)
    {
        playerScore += points;
        scoreText.text = "Score: " + playerScore.ToString();
        
    }

    public void checkStatus()
    {
        if (playerScore >= targetScore && !isEndless)
        {
            winGame();
        }
        else if (!player.isAlive)
        {
            gameOver();
        }else if(isEndless && playerScore >= targetScore)
        {
            updateHighScore();
        }

    }

    public void updateHighScore()
    {
        string highScoreKey = "Level " + level + " HighScore";
        int currentHighScore = PlayerPrefs.GetInt(highScoreKey, 0);
        if (playerScore > currentHighScore)
        {
            PlayerPrefs.SetInt(highScoreKey, playerScore);
            PlayerPrefs.Save();
            if (targetText != null)
            {
                targetText.text = "High Score: " + playerScore.ToString();
            }
        }
    }

    public void winGame()
    {
        Debug.Log("You Win!");
        Time.timeScale = 0;
        winScreen.SetActive(true);
    }

    public void restartGame()
    {
        Debug.Log("Game Restarted");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the current scene
    }

    public void returnToMainMenu()
    {
        Debug.Log("Returning to Main Menu");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void gameOver() { 
        gameOverScreen.SetActive(true);
        player.Die();
        Time.timeScale = 0;
        Debug.Log("Game Over");
    }

    public void showControls()
    {
        instructionScreen.SetActive(false);
        controlsScreen.SetActive(true);
    }

    public void nextLevel()
    {
        Debug.Log("Going to Next Level");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); // Reloads the current scene

    }

    public void pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            Debug.Log("Game Paused");
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            Debug.Log("Game Resumed");
        }
    }

    public void pickBIOS()
    {
        addScore(1); // Add score when picking up a BIOS chip

    }

    public void platformLanding()
    {
        addScore(1);
    }

}
