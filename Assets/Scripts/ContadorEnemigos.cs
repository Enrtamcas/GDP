using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorEnemigos : MonoBehaviour
{
    // Singleton
    public static LevelManager instance;

    [Header("Vida")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [Header("Vida")]
    [SerializeField] TextMeshProUGUI currencyUI2;


    public void OnGUI()
    {
        currencyUI.text = EnemySpawner.instance.totalEnemies.ToString();
        currencyUI2.text = EnemySpawner.instance.enemiesLeftToSpawn.ToString();
    }
}
