using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     All units that are able to draw cards thought effects.
    /// </summary>
    public interface IDrawable
    {

        /// <summary>
        ///     Draws an amount of cards. Send the source of the effects.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="source"></param>
        void DoDraw(int amount, IEffectable source);

    }
}