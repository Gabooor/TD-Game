using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING, END};

    [System.Serializable]
    public class Wave
    {
        public string name; 
        public Transform enemy;
        public int count;
        public float rate;
    }

    public GameObject levelFinishUI;

    public int enemyCount;
    public int waveCount;
    public static int totalEnemyCount;

    private bool finishLevelTriggered;
    public static bool noEnemiesRemaining;

    public Wave[] waves;
    public int nextWave;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        Time.timeScale = 1f;
        nextWave = 0;
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced");
        }
        enemyCount = 0;
        waveCount = 0;
        waveCountdown = timeBetweenWaves;
        noEnemiesRemaining = false;
        finishLevelTriggered = false;
        totalEnemyCount = 0;
    }

    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            WaveCompleted();
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING && state != SpawnState.END)
            {
                if(state != SpawnState.END) StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            if(state != SpawnState.END) waveCountdown -= Time.deltaTime;

        }

        if(state == SpawnState.END)
        {
            AreEnemiesDead();
            if (noEnemiesRemaining)
            {
                if (!finishLevelTriggered)
                {
                    FinishLevel();
                    finishLevelTriggered = true;
                }
            }
        }
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            state = SpawnState.END;
        }
        else
        {
            nextWave++;
        }
    }
    
    void AreEnemiesDead()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                noEnemiesRemaining = true;
            }
            else
            {
                noEnemiesRemaining = false;
            }
        }
    }

    void FinishLevel()
    {
        Debug.Log("<color=orange><b>LEVEL FINISHED</b></color>");
        levelFinishUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GManager.LevelFinished = true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning wave");
        state = SpawnState.SPAWNING;

        for(int i = 0; i<_wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            enemyCount++;
            totalEnemyCount++;
            yield return new WaitForSeconds(0.5f);
        }
        waveCount++;
        Debug.Log("<color=orange><b>" + _wave.name + ": SPAWNED " + enemyCount + " ENEMIES</b></color>");
        enemyCount = 0;
        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}