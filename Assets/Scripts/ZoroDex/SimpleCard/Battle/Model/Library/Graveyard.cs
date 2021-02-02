using Tools;

namespace ZoroDex.SimpleCard.Battle
{
    public class Graveyard : Collection<IRuntimeCard>
    {
        public Graveyard(IPlayer player) => Owner = player;
        private IPlayer Owner { get; }

        public void AddCard(IRuntimeCard card)
        {
            Add(card);
            card.Restart();
        }

    }
}