namespace ZoroDex.SimpleCard.Battle
{
    /// <summary>
    ///     Start Current player turn Implementatiion.
    /// </summary>
    public class StartPlayerTurnMechanics : BaseGameMechanics
    {
        public StartPlayerTurnMechanics(IGame game) : base(game)
        {
            
        }

        public void Execute()
        {
            if (Game.IsTurnInProgress)
                return;
            if (!Game.IsGameStarted)
                return;
            if (Game.IsGameFinished)
                return;

            Game.IsTurnInProgress = true;
            Game.TurnLogic.UpdateCurrentPlayer();
            Game.TurnLogic.CurrentPlayer.StartTurn();
            
            OnStartedCurrentPlayerTurn(Game.TurnLogic.CurrentPlayer);

        }

        /// <summary>
        ///     Dispatch start current player turn to the listeners.
        /// </summary>
        /// <param name="currentPlayer"></param>
        void OnStartedCurrentPlayerTurn(IPlayer currentPlayer) =>
            GameEvents.Instance.Notify<GameEvents.IStartPlayerTurn>(i => i.OnStartPlayerTurn(currentPlayer));

    }
}