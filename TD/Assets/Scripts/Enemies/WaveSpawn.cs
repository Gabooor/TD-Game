using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour
{
    [Header("Unity Setup Fields")]
    public Transform enemy;
    public Transform spawnPoint;
    public Text waveCountdownText;

    private float timer = 5f;
    private float countdown = 5f;
    private int waveIndex = 0;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(spawnWave());
            countdown = timer;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Floor(countdown + 1).ToString();
    }

    IEnumerator spawnWave()
    {
        waveIndex++;
        PlayerStats.Waves++;
        for (int i = 0; i < waveIndex; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void spawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);

    }
}
