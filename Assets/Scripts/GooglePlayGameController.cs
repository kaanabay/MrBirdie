using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlayGameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PlayGamesPlatform.Instance.SetDefaultLeaderboardForUI(GPGSIds.leaderboard_highscores);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DieAchievements()
    {
        if (!Social.localUser.authenticated)
            return;

        PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_rise_and_shine_again,
                                                  100.0f,
                                                  (bool success) =>
                                                  {
                                                      Debug.Log("Rise and Shine: " + success);
                                                  });
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_die_die_die,
                                                  1,
                                                  (bool success) =>
                                                  {
                                                      Debug.Log("Die Die Die: " + success);
                                                  });
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_mastering_death,
                                                  1,
                                                  (bool success) =>
                                                  {
                                                      Debug.Log("Mastering Death: " + success);
                                                  });
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_you_cant_be_serious,
                                                  1,
                                                  (bool success) =>
                                                  {
                                                      Debug.Log("You can't be serious: " + success);
                                                  });

    }

    public void CoinAchievements()
    {
        if (!Social.localUser.authenticated)
            return;

        PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_have_a_soda_or_something,
                                                  100.0f,
                                                  (bool success) =>
                                                  {
                                                      Debug.Log("Have a soda: " + success);
                                                  });
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_jeweler,
                                                  1,
                                                  (bool success) =>
                                                  {
                                                      Debug.Log("Jeweler: " + success);
                                                  });
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_millionaire,
                                                  1,
                                                  (bool success) =>
                                                  {
                                                      Debug.Log("Millionaire: " + success);
                                                  });
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_bitcoin,
                                                  1,
                                                  (bool success) =>
                                                  {
                                                      Debug.Log("Bitcoin: " + success);
                                                  });

    }

    public void ReviveAchievements()
    {
        Debug.Log("In ReviveAchievements....");
        Debug.Log("Social.localUser.authenticated....");
        if (!Social.localUser.authenticated)
            return;

        PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_second_chance,
                                                  100.0f,
                                                  (bool success) =>
                                                  {
                                                      Debug.Log("Second chance: " + success);
                                                  });
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_3_lives_aint_enough,
                                                  1,
                                                  (bool success) =>
                                                  {
                                                      Debug.Log("3 Lives Ain't Enough: " + success);
                                                  });
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_master_of_revival,
                                                  1,
                                                  (bool success) =>
                                                  {
                                                      Debug.Log("Master of revival: " + success);
                                                  });
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_i_can_revive_forever,
                                                  1,
                                                  (bool success) =>
                                                  {
                                                      Debug.Log("I can revive forever: " + success);
                                                  });
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_inconceivable,
                                                  1,
                                                  (bool success) =>
                                                  {
                                                      Debug.Log("Inconcievable: " + success);
                                                  });

    }

    public void HighScoreReport(long score)
    {
        Debug.Log("HighScoreReport Called");
        Debug.Log("Table: " + GPGSIds.leaderboard_highscores);

        if (!PlayGamesPlatform.Instance.localUser.authenticated)
            return;

        PlayGamesPlatform.Instance.ReportScore(score,
                                               GPGSIds.leaderboard_highscores,
                                               (bool success) =>
                                               {
                                                   Debug.Log("Leaderboard reported: " + success);
                                               });
    }

}
