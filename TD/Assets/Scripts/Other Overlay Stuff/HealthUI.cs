﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [Header("Unity Setup Fields")]
    public Text healthText;

    void Update()
    {
        healthText.text = ("Health: " + PlayerStats.Health);
    }
}
