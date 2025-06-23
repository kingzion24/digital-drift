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
    public Text targetText;
    public charactermvmt player;
    public int tergetScore = 10; // Set a target score for the game

    void Start()
    { 
        if(targetText != null)
        {
            targetText.text = "Target: " + tergetScore.ToString();
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<charactermvmt>();
    }

    public void addScore(int points)
    {
        playerScore += points;
        scoreText.text = "Score: " + playerScore.ToString();
        if(playerScore >= tergetScore)
        {
            Debug.Log("Target Score Reached: " + playerScore);
            winGame();
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
        //playerScore = 0;
        //scoreText.text = "Score: " + playerScore.ToString();
        Debug.Log("Game Restarted");
        Time.timeScale = 1;
        //SceneManager.LoadScene();
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

}
