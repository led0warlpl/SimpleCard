﻿using UnityEngine;
using ZoroDex.SimpleCard.Battle.Controller;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard.Battle
{
    public static partial class EffectsDispatcher
    {
        public static class EffectsResolver
        {
            /// <summary>
            ///     Resolves the game data reference using singleton pattern.
            /// </summary>
            private static IGame GameData => GameController.Instance.Data.RuntimeGame;

            /// <summary>
            ///     Resolves and apply an effect caused by a source uppon on or many targets.
            /// </summary>
            /// <param name="effect"></param>
            /// <param name="source"></param>
            /// <param name="targets"></param>
            public static void Resolve(BaseEffectData effect, IEffectable source, ITargetable[] targets)
            {
                if (effect == null)
                {
                    Debug.LogError("Can't resolve a null effect.");
                    return;
                }
                
                //apply the effect on the targets
                ApplyEffect(effect, targets, source);


            }

            static void ApplyEffect(BaseEffectData effect, ITargetable[] targets, IEffectable source)
            {
                for (var i = 0; i < targets.Length; i++)
                {
                    var target = targets[i];
                    effect.Apply(target, source);
                }
            }
            
            
        }
    }
}