namespace ZoroDex.SimpleCard.Battle
{
    /// <summary>
    ///     Base for all the Artificial Intelligence of the game.
    /// </summary>
    public abstract class AiBase
    {
        
        //--------------------------------------------------------------

        protected AiBase(IPlayer player, IGame game)
        {
            Game = game;
            Player = player;
            Enemy = game.TurnLogic.GetOpponent(player);
        }
        
        // -----------------------------------------------------------

        public abstract AttackMechanics.RuntimeAttackData[] GetAttackMoves();
        
        // ------------------------------------------------------------

        #region Properties

        protected IGame Game { get; }
        protected IPlayer Player { get; }
        protected IPlayer Enemy { get; }

        #endregion

    }
}