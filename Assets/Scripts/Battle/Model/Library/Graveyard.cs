﻿using Tools;

namespace SimpleCardGames.Battle
{
    public class Graveyard : Collection<IRuntimeCard>
    {
        //----------------------------------------------------------------------------------------------------------

        public Graveyard(IPlayer player) => Owner = player;

        IPlayer Owner { get; }

        public void AddCard(IRuntimeCard card)
        {
            Add(card);
            card.Restart();
        }
    }
}