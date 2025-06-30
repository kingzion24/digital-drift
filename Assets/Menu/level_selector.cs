using UnityEngine;
using UnityEngine.SceneManagement;

public class level_selector : MonoBehaviour
{

    public mode_controller mode;

    void Start()
    {
        mode = GameObject.FindGameObjectWithTag("mode").GetComponent<mode_controller>();
    }

    public void level_1()
    {
        mode.isEndless = true;
        SceneManager.LoadScene(5);

    }
    public void level_2()
    {
        mode.isEndless = true;
        SceneManager.LoadScene(6);
    }
    public void level_3()
    {
        mode.isEndless = true;
        SceneManager.LoadScene(7);
    }
}
