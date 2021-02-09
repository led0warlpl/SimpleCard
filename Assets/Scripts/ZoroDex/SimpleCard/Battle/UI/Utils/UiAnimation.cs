using System;
using System.Collections;
using UnityEngine;

namespace ZoroDex.SimpleCard
{
    public class UiAnimation : UiListener
    {
        protected static readonly int HashName = Animator.StringToHash("Animation");
        protected Animator Animator { get; set; }

        protected void Awake() => Animator = GetComponent<Animator>();

        protected virtual IEnumerator Animate(float delay = 0)
        {
            yield return new WaitForSeconds(delay);
            if(Animator != null)
                Animator.Play(HashName);
        }
        
    }
}