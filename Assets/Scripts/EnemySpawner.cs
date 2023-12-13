using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("Referencias")] 
    // Tipo de enemigos que van a salir en el nivel
    [SerializeField] private GameObject[] enemyPrefabs;

    // Modificar los atributos segun sea necesario.
    [Header("Atributos")]
    // Cantidad de enemigos por nivel
    [SerializeField] private int baseEnemies = 8;
    // Enemigos por segundo
    [SerializeField] private float enemiesPerSecond = 0.5f;
    // Tiempo entre rondas
    [SerializeField] private float timeBetweenWaves = 5f;
    // Variable que controla la tasa de spawn de enemigos por segundo. Aumentar si se quiere mas dificultad
    [SerializeField] private float difficultScalingFactor = 0.75f; 
    
    // Indice que lleva la cuenta de la ronda actual. TODO (establecer un limite de rondas)
    private int currentWave = 1;
    // Variable que lleva la cuenta de cuanto tiempo ha pasado desde el ultimo spawn
    private float timeSinceLastSpawn;
    // Variable que lleva la cuenta de la cantidad de enemigos en pantalla con vida
    private int enemiesAlive;
    // Variable que lleva la cuenta de la cantidad de enemigos que faltan por spawnear
    private int enemiesLeftToSpawn;
    // Variable booleana para controlar los spawneos
    private bool isSpawning = false;

    [Header("Eventos")] 
    // Evento para gestionar la eliminacion de enemigos
    public static UnityEvent OnEnemyDestroy = new UnityEvent();

    private void Awake()
    {
        // Cada vez que se invoque al evento OnEnemyDestroy se ejecutara EnemyDestroyed
        OnEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }


    private void Update()
    {
        // Si estamos spawneando un enemigo, salimos de la funcion
        if (!isSpawning) return;
        
        // Llevamos registro del tiempo, para un spawn controlado
        timeSinceLastSpawn += Time.deltaTime;
        
        // Spawn cada 2 segundos
        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            // Reiniciamos el contador
            timeSinceLastSpawn = 0f;
            // Decrementamos la cantidad de enemigos que spawnear
            enemiesLeftToSpawn--;
            // Cantidad de enemigos en pantalla
            enemiesAlive++;
        }
        
        // Si la cantidad de enemigos por spawnear es 0, al igual que el numero de enemigos vivos, entonces se finaliza la ronda
        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    /* Declaramos StartWave() como un IEnumerator para que se pueda meter
     en una corrutina para comenzar la ronda despues de timeBetweenWaves */
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        // Despues de pasados timeBetweenWaves, comienza la ronda
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();

    }

    // Reseteo de variables isSpawning y tiempo desde el ultimo spawneo
    void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        // Incrementamo el numero de rondas superadas
        currentWave++;
        // Despues de finalizada una ronda, se comienza otra
        StartCoroutine(StartWave());
    }

    private void SpawnEnemy()
    {
        // Usar un random en el futuro para spawnear diferentes enemigos
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, LevelManager.instance.startPoint.position, Quaternion.identity);
    }

    private void EnemyDestroyed()
    {
        // Se decrementa la cantidad de enemigos vivos en pantalla
        enemiesAlive--;
    }

    private int EnemiesPerWave()
    {
        // Ecuacion que controla el nivel de spawneo de los enemigos
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultScalingFactor));
    }
}
