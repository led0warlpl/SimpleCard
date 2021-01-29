using System;
using UnityEngine;

namespace ZoroDex.SimpleCard.Data.Effects
{
    [Serializable]
    public class EffectTriggerCondition
    {
        [SerializeField] private int currentAmt;

        public int triggerAmt;
        public EffectTriggerType tType;

        public EffectTriggerCondition(EffectTriggerType tType, int triggerAmt)
        {
            this.tType = tType;
            this.triggerAmt = triggerAmt;
            currentAmt = 0;
        }

        public EffectTriggerCondition(EffectTriggerType tType, int triggerAmt, int currentAmt)
        {
            this.tType = tType;
            this.triggerAmt = triggerAmt;
            this.currentAmt = currentAmt;
        }

        public int GetCurrentAmt() => currentAmt;

        public void Trigger() => currentAmt++;

        public void Reset() => currentAmt = 0;
        public bool CanExpressEffect() => currentAmt >= triggerAmt;


    }
}