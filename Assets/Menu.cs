using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("Dinero")]
    [SerializeField] TextMeshProUGUI currencyUI;

    [SerializeField] Animator anim;

    private bool isMenuOpen = true;

    public void AbriMenu()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("IsOpen", isMenuOpen);
    }

    public void OnGUI()
    {
        currencyUI.text = LevelManager.instance.currency.ToString();
    }

    public void TorreSeleccionada()
    { 
    
    }
}
