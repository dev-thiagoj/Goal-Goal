using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevUtills.Core.Singleton;

public class AudioHelper : Singleton<AudioHelper>
{
    [SerializeField] private AudioSource audioSource;

    private void OnValidate()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }
    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
    }

    public void PitchAccelerator(float f)
    {
        audioSource.pitch = f;
    }
}
