using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Call this method in the button's OnClick() event
    public void loadLevel1()
    {
        SceneManager.LoadScene(1); // loads scene at build index 1

    }
    public void loadEndlessMenu()
    {
        SceneManager.LoadScene(4); // loads scene at build index 1

    }
    public void loadSettings()
    {
        SceneManager.LoadScene(6); // loads scene at build index 1

    }
      public void loadCredit()
    {
        SceneManager.LoadScene(5); // loads scene at build index 1
        
    }
}
