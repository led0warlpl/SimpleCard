﻿namespace ZoroDex.SimpleCard.Battle.UI.Card
{
    public class UiCardDrawListener : UiListener,GameEvents.IPlayerDrawCard
    {
        UiPlayerHandUtils CardUtils { get; set; }
        
        IUiPlayer UiPlayer { get; set; }

        void GameEvents.IPlayerDrawCard.OnDrawCard(IPlayer player, IRuntimeCard card)
        {
            if (player.Seat != UiPlayer.Seat)
                return;

            CardUtils.Draw(card);
        }

        void Awake()
        {
            CardUtils = transform.parent.GetComponentInChildren<UiPlayerHandUtils>();
            UiPlayer = transform.parent.GetComponentInChildren<IUiPlayer>();
        }
        
    }
}