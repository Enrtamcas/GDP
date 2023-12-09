using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Singleton
    public static LevelManager instance;
    
    // Punto de respawn inicial de los enemigos
    public Transform startPoint;
    // Array con el camino a tomar por los enemigos. Es importante que en el editor de Unity estos esten en orden
    public Transform[] path;

    private void Awake()
    {
        instance = this;
    }



}
