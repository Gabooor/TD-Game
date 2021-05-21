using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public Text enemyCountText;

    void Start()
    {
        
    }

    void Update()
    {
        if (GManager.GameIsOver)
        {
            return;
        }

        enemyCountText.text = Level1.totalEnemyCount.ToString();
    }
}
