using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public AudioMixer audioMixer;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitted Game!");
        Application.Quit();
    }

    public void setBGsound(float soundLevel)
    {
        audioMixer.SetFloat("volBG", soundLevel);
    }

    public void setSFX(float soundLevel)
    {
        audioMixer.SetFloat("volSFX", soundLevel);
    }

}
