using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource coinSound;
    public AudioSource rockHitSound;
    public AudioSource gameOverSound;

    public void playCoinSound()
    {
        coinSound.Play();
    }

    public void playRockHitSound()
    {
        rockHitSound.Play();
    }

    public void playGameOverSound()
    {
        gameOverSound.Play();
    }
}
