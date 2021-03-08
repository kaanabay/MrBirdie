using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuEvents : MonoBehaviour
{
    public GameObject startButton;
    public GameObject achButton;
    public GameObject highscoreButton;
    public GameObject signInButton;
    public Sprite[] signInImages;
    public Text signInButtonText;
    public Text authStatus;
    // ... other code here... 
    public void Start()
    {
        EventSystem.current.firstSelectedGameObject = signInButton;


        //  ADD THIS CODE BETWEEN THESE COMMENTS

        // Create client configuration
        PlayGamesClientConfiguration config = new
            PlayGamesClientConfiguration.Builder()
            .Build();

        // Enable debugging output (recommended)
        PlayGamesPlatform.DebugLogEnabled = true;

        // Initialize and activate the platform
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        // END THE CODE TO PASTE INTO START

        // Try silent sign-in (second parameter is isSilent)
        PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
    }

    public void Update()
    {
        achButton.SetActive(Social.localUser.authenticated);
        highscoreButton.SetActive(Social.localUser.authenticated);
    }


    public void SignIn()
    {
        Debug.Log("signInButton clicked!");

        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // Sign in with Play Game Services, showing the consent dialog
            // by setting the second parameter to isSilent=false.
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
        else
        {
            // Sign out of play games
            PlayGamesPlatform.Instance.SignOut();

            // Reset UI
            signInButtonText.text = "Sign In";
            signInButton.GetComponent<Image>().sprite = signInImages[0];
            authStatus.text = "";
        }
    }

    public void SignInCallback(bool success)
    {
        if (success)
        {
            Debug.Log("(Mr. Birdie) Signed in!");

            // Change sign-in button text
            signInButtonText.text = "Sign out";
            signInButton.GetComponent<Image>().sprite = signInImages[1];

            // Show the user's name
            authStatus.text = Social.localUser.userName;
        }
        else
        {
            Debug.Log("(Mr. Birdie) Sign-in failed...");

            // Show failure message
            signInButtonText.text = "Sign in";
            signInButton.GetComponent<Image>().sprite = signInImages[0];
            authStatus.text = "Sign-in to Google Play Games";
        }
    }

    public void ShowAchievements()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
        else
        {
            Debug.Log("Cannot show Achievements, not logged in");
        }
    }

    public void ShowLeaderboards()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            Debug.Log("Cannot show leaderboard: not authenticated");
        }
    }

}
