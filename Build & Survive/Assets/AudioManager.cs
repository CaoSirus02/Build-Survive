using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AudioSources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("AudioClips")]
    public AudioClip backgroundM;
    public AudioClip buildSFX;
    public AudioClip tierOneTurretShoot;
    public AudioClip tierTwoTurretShoot;
    public AudioClip tierTreeTurretShoot;
    public AudioClip explosion;
    public AudioClip loadAmmo;

    private void Start()
    {
        musicSource.clip = backgroundM;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
