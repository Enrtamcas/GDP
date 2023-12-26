using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControler : MonoBehaviour
{
    public static MusicControler Instance;

    private AudioSource audioSource;

    [SerializeField] private AudioClip firstSong;

    private float currentTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOnLoop()
    {
        audioSource.loop = true;
        audioSource.clip = firstSong;
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource.Stop();
        currentTime = 0;
    }
}