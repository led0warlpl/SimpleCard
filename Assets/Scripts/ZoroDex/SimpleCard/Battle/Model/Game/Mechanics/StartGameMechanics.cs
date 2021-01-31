namespace ZoroDex.SimpleCard.Battle
{
    /// <summary>
    ///     Start Game Step Implementation.
    /// </summary>
    public class StartGameMechanics : BaseGameMechanics
    {
        public StartGameMechanics(IGame game) : base(game)
        {
            
        }

        /// <summary>
        ///     Execution of start game
        /// </summary>
        public void Execute()
        {
            if (Game.IsGameStarted) return;

            Game.IsGameStarted = true;
            
            //calculus of the starting player
            Game.TurnLogic.DecideStartPlayer();
            
            OnGameStarted(Game.TurnLogic.StarterPlayer);
        }

        /// <summary>
        ///     Dispatch start game event to the listeners.
        /// </summary>
        /// <param name="starterPlayer"></param>
        void OnGameStarted(IPlayer starterPlayer) =>
            GameEvents.Instance.Notify<GameEvents.IStartGame>(i => i.OnStartGame(starterPlayer));

    }
}