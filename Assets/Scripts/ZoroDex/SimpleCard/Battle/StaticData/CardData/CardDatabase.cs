using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard.Data.Card
{
    /// <summary>
    ///     Database that manages static card data.
    /// </summary>
    public class CardDatabase : Singleton<CardDatabase>
    {
        private const string PathDataBase = "Battle/CardDatabase";

        public CardDatabase()
        {
            if (Cards == null)
                Cards = Resources.LoadAll<CardData>(PathDataBase).ToList();

        }

        List<CardData> Cards { get; }

        public CardData Get(CardId id) => Cards?.Find(card => card.Id == id);

        public List<CardData> GetFullList() => Cards;

    }
}