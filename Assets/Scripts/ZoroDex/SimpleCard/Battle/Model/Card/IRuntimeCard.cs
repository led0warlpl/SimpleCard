using System.Collections.Generic;
using ZoroDex.SimpleCard.Data.Card;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard
{
    public interface IRuntimeCard : IEffectable
    {
        Dictionary<BaseEffectData,ITargetable[]> Targets { get; }
        ICardData Data { get; }
        void Play();
        void Discard();
        void Draw();
        void AddTargets(BaseEffectData effect, ITargetable[] targets);
        void Restart();

    }
}