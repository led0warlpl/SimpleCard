using System;

namespace ZoroDex.SimpleCard.Battle.UI.Card
{
    /// <summary>
    ///     An pile of UI Card
    /// </summary>
    public interface IUiCardPile
    {
        Action<IUiCard[]> OnPileChanged { get; set; }
        void AddCard(IUiCard uiCard);
        void RemoveCard(IUiCard uiCard);
        void Restart();

    }
}