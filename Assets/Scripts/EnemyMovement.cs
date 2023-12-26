using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Referencias")] 
    [SerializeField] private Rigidbody2D rigidBody2D;
    
    // Velocidad del enemigo. Ajustar segun sea necesario para conseguir una experiencia equilibrada
    [Header("Atributos")]
    [SerializeField] private float moveSpeed = 2f;
    
    // Referencia al siguiente objetivo en el camino definido
    private Transform target;
    
    // Indice al siguiente punto a alcanzar
    private int pathIndex = 0; // Se inicializa en el punto 1 
    private void Start()
    {
        target = LevelManager.instance.path[pathIndex];
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            // Incrementamos el pathIndex
            pathIndex++;
            // Si ha alcanzado el ultimo punto, se destruye
            if (pathIndex == LevelManager.instance.path.Length)
            {
                LevelManager.instance.currency = LevelManager.instance.currency - 50;
                // Invocamos el evento de enemigo destruido
                EnemySpawner.OnEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.instance.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        // El enemigo apunta hacia el punto que tiene que alcanzar
        Vector2 direction = (target.position - transform.position).normalized;
        
        // Velocidad del rigidBody
        rigidBody2D.velocity = direction * moveSpeed;
    }
}
