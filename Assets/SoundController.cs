using UnityEngine;

public class SoundController : MonoBehaviour
{

    public AudioSource music, sfx;
    public AudioClip button_click, jump, landing, background, win, game_over, score;

    void Start()
    {
        playBackgroundMusic();
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

    public void playBackgroundMusic()
    {
        music.clip = background;
        music.Play();
        Debug.Log("Background music played");
    }

    public void playButtonClickSound()
    {
        sfx.clip = button_click;
        sfx.Play();
        Debug.Log("Button click sound played");
    }
}
