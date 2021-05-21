using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEnemy : MonoBehaviour
{
    [Header("Unity Setup Fields")]
    public Transform enemy;
    public Transform spawnPoint;

    private float timer = 5f;
    private float countdown = 5f;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(spawnWave());
            countdown = timer;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator spawnWave()
    {
        spawnEnemy();
        yield return new WaitForSeconds(15f);

    }

    void spawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
