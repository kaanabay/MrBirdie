
using UnityEngine;

public class ItemController : MonoBehaviour
{

    //public float speedCoin = 3.0f;
    //public float speedRock = 6.0f;

    private const float speedIncrease = 0.0002f;

    void FixedUpdate()
    {
        if(this.transform.position.y <= -6.0f)
        {
            Destroy(this.gameObject);
            return;
        }

        float itemSpeed = 0f;

        if (this.tag == "Coin")
        {
            itemSpeed = GameController.coinSpeed;
        }

        else if (this.tag == "Rock")
        {
            itemSpeed = GameController.rockSpeed;
        }

        if(GameController.coinSpeed < GameController.maxCoinSpeed)
        {
            GameController.coinSpeed += speedIncrease;
        }

        if (GameController.rockSpeed < GameController.maxRockSpeed)
        {
            GameController.rockSpeed += speedIncrease * 2;
        }

        this.transform.Translate(Vector3.down * itemSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if(player)
        { /*
            if(this.tag == "Coin")
            {
                player.incrementCoin(1);
            }
            else if (this.tag == "Rock")
            {
                player.decrementHealth(1);
            } */

            Destroy(this.gameObject);
        }
    }
}
