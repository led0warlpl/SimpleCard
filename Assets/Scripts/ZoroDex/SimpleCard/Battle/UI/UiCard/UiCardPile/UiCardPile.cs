using System;
using System.Collections.Generic;
using ZoroDex.SimpleCard.Data.Card;

namespace ZoroDex.SimpleCard.Battle.UI.Card
{
    /// <summary>
    ///     Pile of cards. Add or Remove cards and be notified when changes happen.
    /// </summary>
    public abstract class UiCardPile: UiListener,IUiCardPile,GameEvents.IRestartGame
    {
        protected virtual void Awake()
        {
            //initialize register
            Cards = new List<IUiCard>();

            Restart();

        }
        
        /// <summary>
        ///     List with all cards.
        /// </summary>
        public List<IUiCard> Cards { get; private set; }
        public Action<IUiCard[]> OnPileChanged { get; set; } = card => { };
        
        /// <summary>
        ///     Add a card to the pile.
        /// </summary>
        /// <param name="card"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual void AddCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valied argument.");
            
            Cards.Add(card);
            card.transform.SetParent(transform);
            card.Initialize();
            NotifyPileChange();
            card.Draw();
        }
        
        /// <summary>
        ///     Remove a card from the pile.
        /// </summary>
        /// <param name="card"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual void RemoveCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Cards.Remove(card);
            
            NotifyPileChange();
            
            
        }

        /// <summary>
        ///     Clear ll the pile.
        /// </summary>
        [Button]
        public virtual void Restart()
        {
            var childCards = GetComponentsInChildren<IUiCard>();
            foreach(var uiCardHand in childCards)
                CardFactory.Instance.ReleasePooledObject(uiCardHand.gameObject);

            Cards.Clear();

        }
        

        /// <summary>
        ///     Notify all listeners of this pile that some change has been made.
        /// </summary>
        [Button]
        public void NotifyPileChange() => OnPileChanged?.Invoke(Cards.ToArray());

        void GameEvents.IRestartGame.OnRestart() => Restart();




    }
}