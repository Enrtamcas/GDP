using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Singleton
    public static BuildManager instance;

    [Header("Referencias")]
    // Referencia a los construibles
    [SerializeField] private Tower[] towers;

    // Solo hay una torreta por el momento
    private int selectedTower = 0;

    private void Awake()
    {
        instance = this;
    }

    public Tower GetSelectorTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _setSelectedTower)
    {
        selectedTower = _setSelectedTower;
    }
}
