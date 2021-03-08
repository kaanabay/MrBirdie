using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public UIManager uIManager;

    public bool playerAlive = false;

    public GameObject[] randomRocks;

    public GameObject[] items;

    public float[] spawnRates;

    public float[] incrementRates;

    private float[] timeToSpawn;

    private GameObject instRef = null;

    public static readonly float[] maxRates = { 30.0f, 15.0f };



    private void Awake()
    {
        timeToSpawn = new float[items.Length];
        GameController.resetItemSpeeds();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        
        for(int i=0; playerAlive && i < items.Length; ++i)
        {
            if (Time.time > timeToSpawn[i])
            {
                if(spawnRates[i] < maxRates[i])
                    spawnRates[i] += incrementRates[i];

                instRef = Instantiate(items[i], new Vector3(Random.Range(-2.258f, 2.258f), 5.4f), Quaternion.identity);

                if (items[i].CompareTag("Rock") && playerAlive)
                {
                    uIManager.addPoints(1);
                    items[i] = getRandomRockShape();
                }
                    

                timeToSpawn[i] = Time.time + 10f / spawnRates[i];
            }
        }

        if (instRef && !playerAlive)
        {
            Destroy(instRef);
        }
    }

    private GameObject getRandomRockShape()
    {
        return randomRocks[Random.Range(0,3)];
    }
}
