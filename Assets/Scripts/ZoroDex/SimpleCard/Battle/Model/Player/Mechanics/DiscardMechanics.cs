using Extensions;
using ZoroDex.SimpleCard.Battle;
using ZoroDex.SimpleCard.Data.Card;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard.Battle
{
    /// <summary>
    ///     Discard cards player mechanics.
    /// </summary>
    public class DiscardMechanics : BasePlayerMechanics
    {
        public DiscardMechanics(IPlayer player) : base(player)
        {
            
        }

        public void DoDiscard(int amount, IEffectable source)
        {
            for (var i = 0; i < amount; i++)
            {
                if (Player.Hand.Size <= 0)
                    break;

                var card = Player.Hand.Units.RandomItem();
                Discard(card);
            }
        }

        public bool Discard(IRuntimeCard card)
        {
            var hasCard = Player.Hand.Has(card);
            if (!hasCard)
                return false;
            card.Discard();
            Player.Hand.Remove(card);
            Player.Graveyard.AddCard(card);
            OnDiscardCard(Player, card);
            return true;

        }

        /// <summary>
        ///     Dispatch card discarded to the listeners.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        void OnDiscardCard(IPlayer player, IRuntimeCard card)
        {
            GameEvents.Instance.Notify<GameEvents.IPlayerDiscardCard>(i => i.OnDiscardCard(player,card));
            switch (card.Data.CardType)
            {
                case CardType.Minion:
                    GameEvents.Instance.Notify<GameEvents.IPlayerDiscardMinionCard>(i => i.OnDiscardMinionCard(player,card));
                    break;
                case CardType.Power:
                    GameEvents.Instance.Notify<GameEvents.IPlayerDiscardPowerCard>(i =>i.OnDiscardPowerCard(player,card));
                    break;
                case CardType.Spell:
                    GameEvents.Instance.Notify<GameEvents.IPlayerDiscardSpellCard>(i =>
                        i.OnDiscardSpellCard(player, card));
                    break;
                case CardType.Curse:
                    GameEvents.Instance.Notify<GameEvents.IPlayerDrawCurseCard>(i=>i.OnDrawCurseCard(player,card));
                    break;
            }
        }
        
    }
}