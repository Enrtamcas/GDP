using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasillaScript : MonoBehaviour
{
    // Este script gestiona la colocacion de torretas en los casilleros

    [Header("Referencias")] 
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Color de la casilla cuando es pulsada
    [SerializeField] private Color hoverColor;
    
    
    // Referencia a la torreta
    private GameObject tower;
    // Color inicial de la casilla 
    private Color startColor;

    private void Start()
    {
        startColor = spriteRenderer.color;
    }

    // Casilla marcada
    private void OnMouseEnter()
    {
        spriteRenderer.color = hoverColor;
    }
    
    // Casilla desmarcada
    private void OnMouseExit()
    {
        spriteRenderer.color = startColor;
    }
    
    // Construir torreta
    private void OnMouseDown()
    {
        // Si la casilla esta ocupada no construimos
        if (tower != null) return;
        
        // En caso contrario, construimos la torre seleccionada.
        // La torre selecionada es gestionada por el BuilManager
        Tower towerToBuild = BuildManager.instance.GetSelectorTower();

        if (towerToBuild.cost > LevelManager.instance.currency)
        {
            Debug.Log("No tienes dinero suficiente");
            return;
        }

        LevelManager.instance.SpendCurrency(towerToBuild.cost);

        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);


    }
}
