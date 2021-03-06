﻿using System;
using ZoroDex.SimpleCard.Data.Card;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard.Battle
{
    /// <summary>
    ///     Draw card
    /// </summary>
    public class DrawMechanics : BasePlayerMechanics
    {
        public DrawMechanics(IPlayer player) : base(player)
        {
            
        }

        public bool Draw()
        {
            if (Player.Library == null)
                return false;

            var card = Player.Library.DrawTop();
            if (card == null)
                return false;

            card.Draw();
            Player.Hand.Add(card);
            OnDrawCard(Player, card);
            return true;
        }

        public void DrawStartingHand()
        {
            var quant = Player.Configurations.Amount.LibraryPlayer.startingAmount;
            for (var i = 0; i < quant; i++)
                Draw();
        }

        public void DoDraw(int amount, IEffectable source)
        {
            for (var i = 0; i < amount; i++)
                Draw();

        }

        void OnDrawCard(IPlayer player, IRuntimeCard card)
        {
            GameEvents.Instance.Notify<GameEvents.IPlayerDrawCard>(i => i.OnDrawCard(player, card));
            switch (card.Data.CardType)
            {
                case CardType.Minion:
                    GameEvents.Instance.Notify<GameEvents.IPlayerDrawMinionCard>(i => i.OnDrawMinionCard(player, card));
                    break;
                
                case CardType.Spell:
                    GameEvents.Instance.Notify<GameEvents.IPlayerDrawSpellCard>(i =>i.OnDrawSpellCard(player,card));
                    break;
                    
                case CardType.Power:
                    GameEvents.Instance.Notify<GameEvents.IPlayerDrawPowerCard>(i => i.OnDrawPowerCard(player, card));
                    break;
                
                case CardType.Curse:
                    GameEvents.Instance.Notify<GameEvents.IPlayerDrawCurseCard>(i=>i.OnDrawCurseCard(player,card));
                    break;
                
            }
        }
        
    }
}