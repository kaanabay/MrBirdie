using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool gameOverAbsolute = false;
    public GameObject gameOverText;
    public GameObject buttons;
    public GameObject rewardAdButton;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI highScoreText;
    public PlayerController player;
    public GooglePlayGameController googlePlayGames;

    private int point = 0;
    public int highScore;
    private int highScoreBeforePlay;
    // Start is called before the first frame update
    void Start()
    {
        //Get Highscore value from Google Play Games Leaderboard
        //if (Social.localUser.authenticated)
        //{
        //    PlayGamesPlatform.Instance.LoadScores(
        //    GPGSIds.leaderboard_highscores,
        //    LeaderboardStart.PlayerCentered,
        //    1,
        //    LeaderboardCollection.Public,
        //    LeaderboardTimeSpan.AllTime,
        //    (LeaderboardScoreData data) =>
        //    {
        //        if (data.Valid)
        //        {
        //            System.Int32.TryParse(data.PlayerScore.formattedValue, out this.highScore);
        //            this.highScoreBeforePlay = this.highScore;
        //        }
        //    });
        //}
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMenu(false);
        }
    }

    void FixedUpdate()
    {
        if (gameOverAbsolute)
        {
            point = 0;
            gameOverText.SetActive(true);
            buttons.SetActive(true);
            rewardAdButton.SetActive(false);
        } else if (gameOver)
        {
            gameOverText.SetActive(true);
            buttons.SetActive(true);
        } else
        {
            gameOverText.SetActive(false);
            buttons.SetActive(false);

            updateLifeInfo();
            updatePointInfo();
            updateHighScoreInfo();
        }
    }

    public void addPoints(int p)
    {
        point += p;

        if(point > highScore)
        {
            highScore = point;
        }
    }

    public void updateLifeInfo()
    {
        lifeText.text = player.health.ToString();

    }

    public void updatePointInfo()
    {
        pointText.text = point.ToString();
    }

    public void updateHighScoreInfo()
    {
        highScoreText.text = highScore.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        googlePlayGames.DieAchievements();
        googlePlayGames.HighScoreReport((long)highScore);
    }

    public void BackToMenu(bool incrDieAchievements)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1) ;

        if(incrDieAchievements)
        {
            googlePlayGames.DieAchievements();
        }
        googlePlayGames.HighScoreReport((long)highScore);
    }
}