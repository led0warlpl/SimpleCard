﻿namespace ZoroDex.SimpleCard.Data.Card
{
    public interface ICardData : IBaseData
    {
        CardId Id { get; }
        int CardCost { get; }
        CardType CardType { get; }
        CardMonsterType CardMonsterType { get; }
        // TODO: EffectsSet 
        //EffectsSet Effects { get; }
        
    }
}