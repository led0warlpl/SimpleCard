using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard
{

    /// <summary>
    ///     All units that are able to draw cards thought effect.
    /// </summary>
    public interface IDiscardable
    {
        void DoDiscard(int amount, IEffectable source);

    }
}