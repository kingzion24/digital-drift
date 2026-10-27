using UnityEngine;
using UnityEngine.SceneManagement;

public class BTcode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SoundController soundController;

    void Start()
    {
        soundController = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundController>();
        Time.timeScale = 1; // Ensure the game is running at normal speed
        soundController.playBackgroundMusic(6);
        StartCoroutine(LoadSceneAfterDelay());
    }

    private System.Collections.IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(4f);
        soundController.stopBackgroundMusic();
        SceneManager.LoadScene(1);
    }

}
