﻿
using UnityEngine;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard.Data.Card
{
    [CreateAssetMenu(menuName = "Data/Card")]
    public class CardData : ScriptableObject , ICardData
    {
        [SerializeField]  Sprite artwork;
        [SerializeField]  int cardCost;
        [SerializeField]  CardMonsterType cardMonsterType;
        [SerializeField] string cardName;

        [SerializeField] CardType cardType;

        EffectsSet dataEffects;
        [SerializeField] string description;
        [SerializeField] CardId id;
        
        // ------------------------------------------------------

        public CardId Id => id;
        public int CardCost => cardCost;
        public CardType CardType => cardType;
        public CardMonsterType CardMonsterType => cardMonsterType;
        public string Name => cardName;
        public string Description => description;
        public Sprite Artwork => artwork;
       
         public EffectsSet Effects => dataEffects;

    }
}