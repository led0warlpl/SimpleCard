using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZoroDex.SimpleCard.Data.Effects
{
    /// <summary>
    ///     It holds all the effects of a card.
    /// </summary>
    [CreateAssetMenu(menuName = "Data/Effect Set")]
    public class EffectsSet : ScriptableObject
    {
        [SerializeField] private EffectRegister register = new EffectRegister();

        public EffectRegister Register => register;

        public bool HasDynamicTarget => register.Values.ToList().Exists(x => x.HasDynamicTarget);
        
        /// <summary>
        ///     A register of effects organized by trigger type .
        ///     TODO: Evalute whether to keep or not the sorted dictionary.
        /// </summary>
        public class EffectRegister : SerializableSortedDictionary<EffectTriggerCondition, ListEffects>
        {
            
        }

        /// <summary>
        ///     Just a serializable list of effects.
        /// </summary>
        public class ListEffects
        {
            public List<BaseEffectData> Effects = new List<BaseEffectData>();
            public bool HasDynamicTarget => Effects.Exists(x => x.Target.IsDynamic);

        }
        

    }
}