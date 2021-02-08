
using System.Collections.Generic;
using UnityEngine;
using ZoroDex.SimpleCard.Data.Card;
using ZoroDex.SimpleCard.Data.Effects;
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard.Battle
{
    /// <summary>
    ///     A Card at the runtime.
    /// </summary>
    public class RuntimeCard : IRuntimeCard, IPoolable
    {

        public RuntimeCard() => Restart();

        public RuntimeCard(ICardData data)
        {
            Restart();
            SetData(data);
        }

        public Dictionary<BaseEffectData, ITargetable[]> Targets { get; private set; } =
            new Dictionary<BaseEffectData, ITargetable[]>();

        EffectsSet IEffectable.Effects => Data.Effects;

        /// <summary>
        ///     Reference for all card data.
        /// </summary>
        public ICardData Data { get; private set; }

        //TODO: wait implement EffectsDispatcher
        public void Play() => EffectsDispatcher.DispatchEffects(this, EffectTriggerType.OnPlay);
        public void Discard() => EffectsDispatcher.DispatchEffects(this, EffectTriggerType.OnDiscard);

        public void Draw() => EffectsDispatcher.DispatchEffects(this, EffectTriggerType.OnDraw);

        public void AddTargets(BaseEffectData effect, ITargetable[] targets) => Targets.Add(effect, targets);

        /// <summary>
        ///     Reset all values.
        /// </summary>
        public void Restart() => Targets.Clear();

        public void SetTargets(Dictionary<BaseEffectData, ITargetable[]> target) => Targets = target;

        /// <summary>
        ///     Set the data inside a card.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(ICardData data) => Data = data;

    }
}