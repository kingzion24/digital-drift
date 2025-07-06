using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1; // Ensure the game is running at normal speed when starting
        mode_controller mode = GameObject.FindGameObjectWithTag("mode").GetComponent<mode_controller>();
        mode.cutscene = 0; // Reset cutscene index to 0 when starting the game
        mode.isEndless = false; // Set the game mode to non-endless by default
        GameObject.FindGameObjectWithTag("sound").GetComponent<SoundController>().playBackgroundMusic(0); // Play the menu background music
    }

    public void loadBootSequence()
    {
        SceneManager.LoadScene(1); 

    }
    public void loadEndlessMenu()
    {
        SceneManager.LoadScene(2); 

    }
    public void loadSettings()
    {
        SceneManager.LoadScene(3); 

    }
      public void loadCredit()
    {
        SceneManager.LoadScene(4); 
        
    }
}
