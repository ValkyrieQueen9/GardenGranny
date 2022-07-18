using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
   public class Wave
    {
        public string name;
        public GameObject enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public bool wave1PopUp = false;
    public bool wave2PopUp = false;
    public bool wave3PopUp = false;
    public bool wave4PopUp = false;
    public bool wave5PopUp = false;

    private GameObject scoreObj;
    private Score scoreScript;

    private GameObject gameManagerObj;
    private GameManager gameManagerScript;

    private void Start()
    {
        gameManagerObj = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManagerObj.GetComponent<GameManager>();

        scoreScript = FindObjectOfType<Score>();

        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));

                if (nextWave == 0)
                {
                    wave1PopUp = true;
                }
                if (nextWave == 1)
                {
                    wave2PopUp = true;
                }
                if (nextWave == 2)
                {
                    wave3PopUp = true;
                }
                if (nextWave == 3)
                {
                    wave4PopUp = true;
                }
                if (nextWave == 4)
                {
                    wave5PopUp = true;
                }
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            gameManagerScript.gameWin = true;
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }

}