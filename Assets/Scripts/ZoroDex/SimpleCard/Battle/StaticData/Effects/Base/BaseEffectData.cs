using UnityEngine;
using ZoroDex.SimpleCard.Data.Targets;

namespace ZoroDex.SimpleCard.Data.Effects
{
    /// <summary>
    ///     Base class for all effects in the game.
    /// </summary>
    public abstract class BaseEffectData : ScriptableObject
    {
        public const string Path = "Data/Effect";
        
        // ------------------------------------------------------------

        [SerializeField] [Tooltip("Quantity of the effect.")]
        private int amount;
        
        // --------------------------------------------------------------
        
        //TODO: All these texts may be moved to a localization system and accessed via Ids.
        [Header("Data")]
        [SerializeField]
        [Tooltip("A brief description of what it does. This text won't be show to the user")]
        [Multiline]
        string description;

        [SerializeField] [Tooltip("Targets of this effect.")]
        private BaseTargetType target;

        public int Amount => amount;
        public BaseTargetType Target => target;
        
        // ------------------------------------------------------------
        public abstract void Apply(ITargetable target, IEffectable source);


    }
}