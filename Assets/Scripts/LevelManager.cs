using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int currency;

    [Header("Dinero")]
    [SerializeField] private Text scoreText;

    // Singleton
    public static LevelManager instance;
    
    // Punto de respawn inicial de los enemigos
    public Transform startPoint;

    // Array con el camino a tomar por los enemigos. Es importante que en el editor de Unity estos esten en orden
    public Transform[] path;

    private void Start()
    {
        currency = 250;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(currency <= 0)
            {
            Debug.Log("a");
            SceneManager.LoadScene("Menu Principal");
        }
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("No tienes suficiente vida");
            return false;
        }

    }
}
