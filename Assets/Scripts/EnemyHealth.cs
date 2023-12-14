using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Atributos")] 
    [SerializeField] private int hitPoints = 2;

    [SerializeField] private int currencyWorth = 50;

    [SerializeField] private bool deathRattle;

    private bool isDestroyed = false;

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed)
        {
            if (deathRattle)
            {
                DeathRattle();
            }

            EnemySpawner.OnEnemyDestroy.Invoke();
            // Esta variable booleana impide que se decremente si control los enemigos vivos
            isDestroyed = true;
            LevelManager.instance.IncreaseCurrency(currencyWorth);
            Destroy(gameObject);
        }
    }

    private void DeathRattle()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, 2);
        foreach (Collider2D colisioned in objetos)
        {
            Turret turret = colisioned.gameObject.GetComponent<Turret>();
            if (turret != null)
            {
                turret.Disable();
            }
        }
    }

}
