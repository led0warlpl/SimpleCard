namespace ZoroDex.SimpleCard
{
    public class FinishTurnMecahnics : BasePlayerMechanics
    {

        public FinishTurnMecahnics(IPlayer player) : base(player)
        {
            
        }

        public void FinishTurn()
        {
            var isDiscard = Player.Configurations.Amount.LibraryPlayer.isDiscardableHands;
            if (isDiscard)
                DiscardAll();
        }

        void DiscardAll()
        {
            var quant = Player.Hand.Size;
            for (var i = 0; i < quant; i++)
                Player.Discard(Player.Hand.Units[0]);
        }
        
    }
}