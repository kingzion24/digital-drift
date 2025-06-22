using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public Text targetText;
    public charactermvmt player;
    public int tergetScore = 10; // Set a target score for the game

    void Start()
    { 
        targetText.text = "Target: " + tergetScore.ToString();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<charactermvmt>();
    }

    public void addScore(int points)
    {
        playerScore += points;
        scoreText.text = "Score: " + playerScore.ToString();
        if(playerScore >= tergetScore)
        {
            Debug.Log("Target Score Reached: " + playerScore);
            Time.timeScale = 0;
            winScreen.SetActive(true);
        }
    }

    public void restartGame()
    {
        playerScore = 0;
        scoreText.text = "Score: " + playerScore.ToString();
        Debug.Log("Game Restarted");
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
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
        SceneManager.LoadScene(2); //TODO: Change to route to the next level
    }
}
