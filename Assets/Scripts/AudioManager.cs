using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;

    public AudioClip music1;
    public AudioClip music2;
    public AudioClip gameEnd;

    private void Start()
    {
        PlayMenuMusic();
    }

    public void PlayMenuMusic()
    {
        musicSource.clip = music1;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayGameMusic()
    {
        musicSource.clip = music2;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayGameEnd()
    {
        musicSource.PlayOneShot(gameEnd);
    }
}