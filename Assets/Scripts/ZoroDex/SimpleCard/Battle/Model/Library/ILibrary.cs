using ZoroDex.SimpleCard.Data.Card;

namespace ZoroDex.SimpleCard.Battle
{
    /// <summary>
    ///     The Library or Deck interface.
    /// </summary>
    public interface ILibrary
    {
         bool IsFinite { get; }
         int Size { get; }
        void Shuffle();
        IRuntimeCard DrawTop();
        void AddCard(ICardData cardData);


    }
}