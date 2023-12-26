using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DamageEvent : MonoBehaviour
{
    public delegate void EnemyDamageHandler(int damage, EnemyHealth enemyHealth);

    public static event EnemyDamageHandler OnEnemyDamage;

    public static void NotifyEnemyDamage(int damage,EnemyHealth enemy)
    {
        if (OnEnemyDamage != null)
        {
            OnEnemyDamage(damage, enemy);
        }
    }
}
