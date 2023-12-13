using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Atributos")] 
    [SerializeField] private int hitPoints = 2;

    [SerializeField] private int currencyWorth = 50;

    private bool isDestroyed = false;

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.OnEnemyDestroy.Invoke();
            // Esta variable booleana impide que se decremente si control los enemigos vivos
            isDestroyed = true;
            LevelManager.instance.IncreaseCurrency(currencyWorth);
            Destroy(gameObject);
        }
    }

}
