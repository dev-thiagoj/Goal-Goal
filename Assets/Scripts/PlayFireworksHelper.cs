using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevUtills.Core.Singleton;

public class PlayFireworksHelper : Singleton<PlayFireworksHelper>
{
    [SerializeField] private ParticleSystem particleSystem;

    private void OnValidate()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        particleSystem.Stop(true);
    }

    public void StartFireworks()
    {
        particleSystem.Play(true);
    }

    public void StopFireworks()
    {
        particleSystem.Stop(true);
    }
}
