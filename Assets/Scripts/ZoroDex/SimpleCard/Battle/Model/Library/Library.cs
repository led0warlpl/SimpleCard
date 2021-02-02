using System.Collections.Generic;
using Tools;
using UnityEngine;
using ZoroDex.SimpleCard.Data.Card;
using ZoroDex.SimpleCard.Data.Deck;

namespace ZoroDex.SimpleCard.Battle
{
    public class Library : Collection<IRuntimeCard>,ILibrary
    {
        private readonly IReadOnlyList<ICardData> cardDataRegister;
        
        // ------------------------------------------------------------

        public Library(IPlayer player, LibraryData deckData, Configurations configurations)
        {
            if (deckData == null)
                Debug.LogError("A deck can't have null cards");

            Deck = deckData;
            Owner = player;
            Configurations = configurations;
            cardDataRegister = Deck.GetCards();

        }

        private Configurations Configurations { get; }
        private LibraryData Deck { get; }
        private IPlayer Owner { get; }

        public bool IsFinite => Configurations.Amount.LibraryPlayer.isFinite;
        
        /// <summary>
        ///     Draw the card on the top of the LIbrary.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IRuntimeCard DrawTop()
        {
            if (Size == 0)
            {
                if (!IsFinite)
                    ReShuffleGraveyard();

                if (Size == 0)
                    return null;
            }

            var card = GetLastAndRemove();
            return card;
        }

        /// <summary>
        ///     Create and adds a car to the Library based on the data.
        /// </summary>
        /// <param name="cardData"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddCard(ICardData cardData)
        {
            var card = RuntimeCardFactory.Instance.Get();
            card.SetData(cardData);
            Add(card);
        }

        /// <summary>
        ///     Creates and shuffle the Library based on the cards in the register.
        /// </summary>
        void CreateAndShuffle()
        {
            foreach (var card in cardDataRegister)
                AddCard(card);
            Shuffle();
        }

        void ReShuffleGraveyard()
        {
            foreach(var card in Owner.Graveyard.Units)
                Add(card);
            Owner.Graveyard.Clear();

            OnReShuffle(Owner);
        }

        void OnReShuffle(IPlayer player) =>
            GameEvents.Instance.Notify<GameEvents.IDoReShuffle>(i => i.OnReShuffle(player));
    }
}