using System;
using System.Collections.Generic;
using ZoroDex.SimpleCard.Battle.UI.Card;

namespace ZoroDex.SimpleCard.Battle.UI.UiPlayerHand
{
    public interface IUiPlayerHand : IUiCardPile
    {
        List<IUiCard> Cards { get; }
        
        Action<IUiCard> OnCardPlayed { get; set; }
        Action<IUiCard> OnCardSelected { get; set; }
        Action<IUiCard> OnCardDiscarded { get; set; }

        void PlaySelected();
        void Unselect();
        void PlayCard(IUiCard uiCard);
        void SelectCard(IUiCard uiCard);
        void DiscardCard(IUiCard uiCard);
        void UnselectCard(IUiCard uiCard);
        void EnableCards();
        void DisableCards();
        IUiCard GetCard(IRuntimeCard card);



    }
}