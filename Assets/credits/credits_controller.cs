using UnityEngine;
using UnityEngine.SceneManagement;

public class credits_controller : MonoBehaviour
{
    public void returnToMenu() {
        SceneManager.LoadScene(0);
    }
}
