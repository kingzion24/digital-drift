using UnityEngine;
using UnityEngine.SceneManagement;

public class bootendscreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SoundController soundController;
    public GameObject homeButton;

    void Start()
    {
        soundController = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundController>();
        Time.timeScale = 1; // Ensure the game is running at normal speed
        soundController.playBackgroundMusic(5);
        StartCoroutine(ShowHome());
    }

    private System.Collections.IEnumerator ShowHome()
    {
        yield return new WaitForSeconds(4f);
        soundController.stopBackgroundMusic();
        homeButton.SetActive(true); // Hide the home button initially
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Returning to Main Menu");
        Time.timeScale = 1;
        soundController.playBackgroundMusic(0);
        SceneManager.LoadScene(0);
    }
}
