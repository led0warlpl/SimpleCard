﻿using System.Collections.Generic;
using UnityEngine;
using ZoroDex.SimpleCard.Data.Card;

namespace ZoroDex.SimpleCard.Data.Deck
{
    [CreateAssetMenu(menuName = "Data/Deck")]
    public class LibraryData : ScriptableObject
    {
        [Tooltip("All data of the cards")] [SerializeField]
        protected List<CardData> cards = new List<CardData>();

        [SerializeField] [Multiline] [Tooltip("Brief description of the deck. The text won't be visible to the user.")]
        private string description;

        [SerializeField] private bool EnabledLoad;

        /// <summary>
        ///     It returns a list with all the data of the library.
        /// </summary>
        /// <returns></returns>
        public List<ICardData> GetCards()
        {
            //new list with everything inside
            var allData = new List<ICardData>();
            cards.ForEach(cardData => allData.Add(cardData));
            return allData;

        }

        public void Clear() => cards.Clear();

        public void AddCard(CardData card) => cards.Add(card);


    }
}