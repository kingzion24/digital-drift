using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Call this method in the button's OnClick() event
    public void LoadLevel1()
    {
        SceneManager.LoadScene(1); // loads scene at build index 1

    }
    public void settings()
    {
        SceneManager.LoadScene(2); // loads scene at build index 1

    }
      public void credit()
    {
        SceneManager.LoadScene(3); // loads scene at build index 1
        
    }
}
