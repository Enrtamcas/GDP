using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("Vida")]
    [SerializeField] TextMeshProUGUI currencyUI;

    [SerializeField] Animator anim;

    public void OnGUI()
    {
        currencyUI.text = LevelManager.instance.currency.ToString();
    }

    public void TorreSeleccionada()
    { 
    
    }
}
