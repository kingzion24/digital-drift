using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    public GameObject highScoreScreen;
    public Text l1_hs;
    public Text l2_hs;
    public Text l3_hs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        l1_hs.text = ""+ PlayerPrefs.GetInt("Level " + 1 + " HighScore", 0);
        l2_hs.text = "" + PlayerPrefs.GetInt("Level " + 2 + " HighScore", 0);
        l3_hs.text = "" + PlayerPrefs.GetInt("Level " + 3 + " HighScore", 0);
    }

    public void showHighScores()
    {
        highScoreScreen.SetActive(true);
    }

    public void hideHighScores()
    {
        highScoreScreen.SetActive(false);
    }
}
