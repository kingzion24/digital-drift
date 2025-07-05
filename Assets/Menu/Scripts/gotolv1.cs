using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void loadLevel1()
    {
        SceneManager.LoadScene(5); 

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
