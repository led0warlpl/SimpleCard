using System;
using UnityEngine;
using ZoroDex.SimpleCard.Battle.UI.UiPlayerHand;

namespace ZoroDex.SimpleCard.Battle.UI.Card
{
    /// <summary>
    ///     Card graveyard holds a register with cards played by the player.
    /// </summary>
    public class UiCardGraveyard : UiCardPile
    {
        [SerializeField] [Tooltip("World point where the graveyard is positioned")]
        Transform graveyardPosition;
        
        IUiPlayerHand PlayerHand { get; set; }
        
        ITargetResolver TargetResolver { get; set; }

        protected override void Awake()
        {
            base.Awake();
            TargetResolver = transform.parent.GetComponentInChildren<ITargetResolver>();
            PlayerHand = transform.parent.GetComponentInChildren<IUiPlayerHand>();
            PlayerHand.OnCardDiscarded += AddCard;
            TargetResolver.OnTargetsResolve += AddCard;
        }

        /// <summary>
        ///     Adds a card to the graveyard or discard pile.
        /// </summary>
        /// <param name="card"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public override void AddCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");
            
            Cards.Add(card);
            card.transform.SetParent(graveyardPosition);
            card.Discard();
            NotifyPileChange();
        }


        public override void RemoveCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Cards.Remove(card);
            NotifyPileChange();
        }
        
        
        
        

    }
}