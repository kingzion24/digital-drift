using UnityEngine;

public class SoundController : MonoBehaviour
{

    public AudioSource music, sfx;
    public AudioClip button_click, jump, landing, menu_background, l1_background, l2_background, l3_background, win, game_over, score, booting_background, congrats_background;

    public int level = 0;

    void Start()
    {
        playBackgroundMusic(level);
    }


    public void playLandingSound()
    {
        sfx.clip = landing;
        sfx.Play();
        Debug.Log("Landing sound played");
    }

    public void playJumpSound()
    {
        sfx.clip = jump;
        sfx.Play();
        Debug.Log("Jump sound played");
    }

    public void playGameOverSound()
    {
        sfx.clip = game_over;
        sfx.Play();
        Debug.Log("Game over sound played");
    }

    public void playWinSound()
    {
        sfx.clip = win;
        sfx.Play();
        Debug.Log("Win sound played");
    }

    public void playScoreSound()
    {
        sfx.clip = score;
        sfx.Play();
        Debug.Log("Score sound played");
    }

    public void playBackgroundMusic(int level = 0)
    {
        switch (level)
        {
            case 1:
                music.clip = l1_background;
                break;
            case 2:
                music.clip = l2_background;
                break;
            case 3:
                music.clip = l3_background;
                break;
            case 4:
                music.clip = booting_background;
                break;
            case 5:
                music.clip = congrats_background;
                break;
            default:
                music.clip = menu_background;
                break;
        }

        music.Play();
        Debug.Log("Background music played");
    }

    public void playButtonClickSound()
    {
        sfx.clip = button_click;
        sfx.Play();
        Debug.Log("Button click sound played");
    }

    public void stopBackgroundMusic()
    {
        music.clip = null;
        music.Play();
    }
}
