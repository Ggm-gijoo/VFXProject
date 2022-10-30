using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]ParticleSystem[] startParticles;
    [SerializeField] ParticleSystem[] endParticles;

    private void Start()
    {
        StartCoroutine(particlePlay());
    }

    private IEnumerator particlePlay()
    {
        foreach (var sParticle in startParticles)
        {
            sParticle.Play();
        }
        yield return new WaitForSeconds(2f);
        foreach(var eParticle in endParticles)
        {
            eParticle.Play();
        }
    }
}
