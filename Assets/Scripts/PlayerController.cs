using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    public int coins = 0;
    public int health = 3;

    public UIManager uIManager;
    public SpawnManager spawnManager;
    public AudioManager audioManager;
    public Animator uIAnimator;
    public AdManager adManager;
    public GooglePlayGameController googlePlayGames;

    private float directionHorizontal;
    private float directionVertical;
    private bool alreadyRewarded = false;

    void Start()
    {
    }

    void Update()
    {
            directionHorizontal = Input.GetAxisRaw("Horizontal");
            directionVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        handleKeyboardInput();

    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
    }

    private void OnMouseDown()
    {
        spawnManager.playerAlive = (uIManager.gameOver) ? false : true;
    }

    private void handleKeyboardInput()
    {

        this.transform.Translate(new Vector3(directionHorizontal, directionVertical) * speed * Time.fixedDeltaTime);

        if (this.transform.position.x <= -2.258f)
        {
            this.transform.position = new Vector3(-2.258f, this.transform.position.y);
        }
        else if (this.transform.position.x >= 2.258f)
        {
            this.transform.position = new Vector3(2.258f, this.transform.position.y);
        }

        if (this.transform.position.y <= -4.4f)
        {
            this.transform.position = new Vector3(this.transform.position.x, -4.4f);
        }
        else if (this.transform.position.y >= 4.0f)
        {
            this.transform.position = new Vector3(this.transform.position.x, 4.0f);
        }
    }

    public void incrementCoin(int i)
    {

        if (spawnManager.playerAlive)
        {
            coins += i;
            uIManager.addPoints(3);
            googlePlayGames.CoinAchievements();
        }

    }

    public void decrementHealth(int h)
    {
        if(health != 0)
        {
            health -= h;
        }
        
        if(health == 0)
        {
            if(!alreadyRewarded)
            {
                adManager.ShowAd();
                endTheGame();
            } else
            {
                endTheGameAbsolute();
            }
            
        }
    }

    private void endTheGame()
    {

        uIManager.gameOver = true;
        uIManager.updateLifeInfo();

        audioManager.playGameOverSound();

        spawnManager.playerAlive = false;
        this.gameObject.SetActive(false);
    }

    private void endTheGameAbsolute()
    {
        uIManager.gameOver = true;
        uIManager.gameOverAbsolute = true;
        uIManager.updateLifeInfo();

        audioManager.playGameOverSound();

        spawnManager.playerAlive = false;

        googlePlayGames.DieAchievements();
        googlePlayGames.HighScoreReport((long) uIManager.highScore);

        this.gameObject.SetActive(false);

    }

    public void revive()
    {
        health = 1;
        uIManager.gameOver = false;
        uIManager.gameOverAbsolute = false;

        uIManager.updateLifeInfo();

        //spawnManager.playerAlive = true;
        this.gameObject.SetActive(true);
        Debug.Log("Calling ReviveAchievements....");
        googlePlayGames.ReviveAchievements();

        this.alreadyRewarded = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Coin"))
        {
            if(spawnManager.playerAlive)
            {
                incrementCoin(1);
            }

            audioManager.playCoinSound();
        }
        else if (other.CompareTag("Rock"))
        {

            if(spawnManager.playerAlive)
            {
                decrementHealth(1);


#if (UNITY_IPHONE || UNITY_ANDROID)
                if(GameController.vibrateOption)
                {
                    Handheld.Vibrate();
                }
#endif
            }

            audioManager.playRockHitSound();

            if(spawnManager.playerAlive)
                StartCoroutine(lifeAnimSetAndReset());
        }
    }

    private IEnumerator lifeAnimSetAndReset()
    {
        uIAnimator.SetBool("lifeCountTextBool", true);
        yield return new WaitForSeconds(.5f);
        uIAnimator.SetBool("lifeCountTextBool", false);
    }

}
