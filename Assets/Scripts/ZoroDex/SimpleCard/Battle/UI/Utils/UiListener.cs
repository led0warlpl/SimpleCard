using System;
using UnityEngine;
using ZoroDex.SimpleCard.Battle;
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard
{
    public class UiListener : MonoBehaviour,IListener
    {
        protected virtual void Start()
        {
            //subscribe
            if(GameEvents.Instance)
                GameEvents.Instance.AddListener(this);
            
        }

        protected void OnDestroy()
        {
            //unsubscribe
            if (GameEvents.Instance)
                GameEvents.Instance.RemoveListener(this);
        }
    }
}