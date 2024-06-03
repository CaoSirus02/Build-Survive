using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip backgroundM;

    private void Start()
    {
        musicSource.clip = backgroundM;
        musicSource.Play();
    }
}
