using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    public void Pausa()
    { 
        Time.timeScale = 0f;
        Debug.Log("P");
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Continuar()
    {
        Time.timeScale = 1f;
        Debug.Log("C");
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Salir()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}
