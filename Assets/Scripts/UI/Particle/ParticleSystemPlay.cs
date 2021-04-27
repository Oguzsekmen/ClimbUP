using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemPlay : MonoBehaviour
{
    ParticleSystem particleEffects;
    private void Start()
    {
        particleEffects = GetComponent<ParticleSystem>();
        
    }
    public void EffectStart()
    {
        particleEffects.Play();
    }
}
