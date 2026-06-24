using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip spinSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip buttonSound;

    public void PlaySpin()
    {
        audioSource.PlayOneShot(spinSound);
    }

    public void PlayWin()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void PlayLose()
    {
        audioSource.PlayOneShot(loseSound);
    }

    public void PlayButton()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}