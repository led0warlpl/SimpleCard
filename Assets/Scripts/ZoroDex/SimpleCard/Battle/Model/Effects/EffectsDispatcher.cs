using System.Linq;
using ZoroDex.SimpleCard.Data.Effects;
using static ZoroDex.SimpleCard.Data.Effects.EffectsSet;

namespace ZoroDex.SimpleCard.Battle
{
    public static partial class EffectsDispatcher
    {
        //TODO: Merge these two classes into one. I'm building out the relic class now, so don't want too fuck up two thing at once
        public static void DispatchEffects(IRuntimeCard card, EffectTriggerType triggerType)
        {
            // grab all effects from the card
            var effects = GetEffects(card);

            //return if the specified trigger is not present
            if (effects.All(eff => eff.Key.tType != triggerType))
                return;
            
            //grab all effects of the specifed trigger
            var effectsByTrigger = effects[effects.First(eff => eff.Key.tType == triggerType).Key].Effects;
            
            //dispatch all effects
            foreach(var effect in effectsByTrigger)
                EffectsResolver.Resolve(effect,card,card.Targets[effect]);

        }

        static EffectRegister GetEffects(IRuntimeCard card) => card.Data.Effects.Register;


    }
}