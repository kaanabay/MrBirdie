using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Monetization;

public class GameController : MonoBehaviour
{

    public static int controlOptionForPlayer = 0;
    public static bool vibrateOption = true;

    /*ITEM CONTROLLER*/
    public static float coinSpeed;
    public static float rockSpeed;
    private const float InitialCoinSpeed = 3.0f;
    private const float InitialRockSpeed = 6.0f;

    public const float maxCoinSpeed = 10.0f;
    public const float maxRockSpeed = 20.0f;
    /*ITEM CONTROLLER*/

    /*SAVE&GET PLAYER PREFERENCES*/
    public AudioMixer audioMixer;
    public Slider bgSlider;
    public Slider sfxSlider;
    //public Dropdown controlDropDown;
    public Toggle vibrateToggle;
    /*SAVE&GET PLAYER PREFERENCES*/

    /*MONETIZATION INITIALIZE*/
#if UNITY_IOS
    private string gameId = "3083697";
#elif UNITY_ANDROID
    private string gameId = "3083696";
#endif
    /*MONETIZATION INITIALIZE*/

    private void Start()
    {
        if(Monetization.isSupported)
        {
            Monetization.Initialize(gameId, true);
        }
    }

    public static void resetItemSpeeds()
    {
        coinSpeed = InitialCoinSpeed;
        rockSpeed = InitialRockSpeed;
    }

    public void setControlOption(int option)
    {
        controlOptionForPlayer = option;
    }

    public void setVibrateOption(bool option)
    {
        vibrateOption = option;
    }

    public void savePreferences()
    {
        float playerSetSound;

        float sound = (audioMixer.GetFloat("volBG", out playerSetSound)) ? playerSetSound : 0;
        PlayerPrefs.SetFloat("musicVolume", sound);

        Debug.Log("musicVolume: " + sound);

        sound = (audioMixer.GetFloat("volSFX", out playerSetSound)) ? playerSetSound : 0;
        PlayerPrefs.SetFloat("sfxVolume", sound);

        Debug.Log("sfxVolume: " + sound);

        //PlayerPrefs.SetInt("controlOption", controlOptionForPlayer);

        //Debug.Log("controlOption: " + controlOptionForPlayer);

        PlayerPrefs.SetInt("vibrateOption", vibrateOption ? 1 : 0);

        Debug.Log("vibrateOption: " + vibrateOption);

    }

    public void getPreferences()
    {
        float f;
        //int i;
        bool b;


        f = PlayerPrefs.GetFloat("musicVolume");
        audioMixer.SetFloat("volBG", f);
        bgSlider.value = f;

        f = PlayerPrefs.GetFloat("sfxVolume");
        audioMixer.SetFloat("volSFX", f);
        sfxSlider.value = f;

        //i = PlayerPrefs.GetInt("controlOption");
        //controlOptionForPlayer = i;
        //controlDropDown.value = i;

        b = PlayerPrefs.GetInt("vibrateOption") == 1;
        vibrateOption = b;
        vibrateToggle.isOn = b;

    }

}
