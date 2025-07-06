using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject pauseScreen;
    public GameObject instructionScreen;
    public GameObject controlsScreen;
    private SoundController soundController;
    public Text targetText;
    public charactermvmt player;
    public int targetScore = 10; // Set a target score for the game
    public bool isEndless = false; // Flag to indicate if the game is endless
    public int level;
    private string highScoreKey ="";

    void Start()
    {
        isEndless = GameObject.FindGameObjectWithTag("mode").GetComponent<mode_controller>().isEndless; // Check if the game is in endless mode
        level = SceneManager.GetActiveScene().buildIndex - 4;
        
        if (targetText != null && !isEndless)
        {
            targetText.text = "Target: " + targetScore.ToString();
        }
        else if (targetText != null && isEndless)
        {
            startEndless();
        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<charactermvmt>();
        soundController = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundController>();
        Time.timeScale = 0;

        soundController.playBackgroundMusic(level);
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
            targetScore = 0;
        }
        targetText.text = "High Score: " + targetScore.ToString();
        showControls();

    }

    public void showControls()
    {
        instructionScreen.SetActive(false);
        controlsScreen.SetActive(true);
    }

    public void startGame()
    {
        instructionScreen.SetActive(false);
        controlsScreen.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        checkStatus();
        if ((Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.P)) && !gameOverScreen.activeSelf && !winScreen.activeSelf)
        {
            pause();
        }
        else if((Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))&& controlsScreen.activeSelf)
        {
            startGame();
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && instructionScreen.activeSelf)
        {
            showControls();
        }
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
    
    public void addScore(int points)
    {
        playerScore += points;
        scoreText.text = "Score: " + playerScore.ToString();

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
        if (!winScreen.activeSelf)
        {
            soundController.stopBackgroundMusic();
            soundController.playWinSound();
            Debug.Log("You Win!");
            Time.timeScale = 0;
            winScreen.SetActive(true);
        }
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
        soundController.playBackgroundMusic(0);
        SceneManager.LoadScene(0);
    }

    public async void gameOver()
    {
        if (!gameOverScreen.activeSelf)
        {
            Debug.Log("Game Over Started");
            soundController.stopBackgroundMusic();
            gameOverScreen.SetActive(true);
            await player.Die();
            // await Task.Delay(2000); // Wait for 5 second before showing game over
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }
    }

    public void nextLevel()
    {
        Debug.Log("Going to Next Level");
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("mode").GetComponent<mode_controller>().cutscene = level; // Set the cutscene index for the next level
        SceneManager.LoadScene(1); 
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
        soundController.playScoreSound();
        addScore(1); 

    }

    public void platformLanding()
    {
        soundController.playLandingSound();
        addScore(1);
    }

}
