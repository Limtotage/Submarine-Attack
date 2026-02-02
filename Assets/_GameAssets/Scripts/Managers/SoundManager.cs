using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [Header("References")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource Music;
    [SerializeField] private AudioSource SFX;
    [Header("Clips")]

    [SerializeField] private AudioClip MissileExplosionClip;
    [SerializeField] private AudioClip NukeMissileExplosionClip;
    [SerializeField] private AudioClip ShipExplosionClip;


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
    }
    void Start()
    {

        if (!Music.isPlaying)
        {
            Music.loop = true;
            Music.Play();
        }
    }

    public void PlayMissileSFX()
    {
        SFX.PlayOneShot(MissileExplosionClip);
    }
    public void PlayNukeMissileSFX()
    {
        SFX.PlayOneShot(NukeMissileExplosionClip);
    }
    public void PlayDestroySFX()
    {
        SFX.PlayOneShot(ShipExplosionClip);
    }
    public void Play(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }

    public void SetMasterVolume(float value)
    {
        Debug.Log(value);
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }

    public void SetMusicVolume(float value)
    {
        Debug.Log(value);
        value = Mathf.Clamp(value, 0.0001f, 1f);
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    public void SetSFXVolume(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
    }
    public float GetVolume(string valumeName)
    {
        audioMixer.GetFloat(valumeName, out float db);
        return Mathf.Pow(10, db / 20f);
    }
}
