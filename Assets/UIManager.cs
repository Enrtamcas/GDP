using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    static UIManager current;

    public TextMeshProUGUI monedasText;
    public TextMeshProUGUI tiempoText;

    public Image healthBar;

    private void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }

        current = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        current.healthBar.fillAmount = 1f;
    }

    public static void ActualizarMonedasUI(int monedasCount)
    {
        if (current == null)
            return;

        current.monedasText.text = monedasCount.ToString();
    }

    public static void UpdateTimeUI(float time)
    {
        if (current == null)
            return;

        int minutes = (int)time / 60;  
        float seconds = (float)time % 60; 

        current.tiempoText.text = minutes.ToString("00" + ":" + seconds.ToString("00"));
    }

    public static void actualizarVidaUI(int vidaCount)
    { 
        if(current == null)
            return;

        current.healthBar.fillAmount = (float)vidaCount / 100f;
    }
}
