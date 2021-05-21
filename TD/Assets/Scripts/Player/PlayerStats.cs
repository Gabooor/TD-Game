using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    private int StartMoney = 400;
    public Text moneyText;

    public static int Health;
    private int StartHealth = 40;

    public static int Waves;
    public static int EnemyCount;

    void Start()
    {
        Money = StartMoney;
        Health = StartHealth;

        Waves = 0;
        EnemyCount = 0;
    }

    void Update()
    {
        moneyText.text = "Money: " + Money;
    }
}
