using UnityEngine;
using UnityEngine.SceneManagement;

public class level_selector : MonoBehaviour
{
    public void level_1()
    {
        SceneManager.LoadScene(1);
    }
    public void level_2()
    {
        SceneManager.LoadScene(2);
    }
    public void level_3()
    {
        SceneManager.LoadScene(3);
    }
}
