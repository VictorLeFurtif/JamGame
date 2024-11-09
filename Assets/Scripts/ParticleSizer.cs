using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSizer : MonoBehaviour
{
    
    public ParticleSystem particleSystem;
    public float newSize = 4.0f;

    void Start()
    {
      
        var main = particleSystem.main;
        
        
        main.startSize = newSize;
    }
}


