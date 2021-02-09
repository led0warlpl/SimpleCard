using System.Collections;
using UnityEngine;

namespace ZoroDex.SimpleCard
{
    public class UiParticles : UiListener
    {
        protected ParticleSystem[] Particles { get; set; }

        protected virtual void Awkae() => Particles = GetComponentsInChildren<ParticleSystem>();

        protected virtual IEnumerator Play(float delay = 0)
        {
            yield return new WaitForSeconds(delay);
            
            foreach (var particleSys in Particles)
                if(particleSys != null)
                    particleSys.Play();
        }

    }
}