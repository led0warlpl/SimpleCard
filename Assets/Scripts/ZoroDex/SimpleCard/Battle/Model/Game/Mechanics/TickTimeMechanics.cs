namespace ZoroDex.SimpleCard.Battle
{
    
    /// <summary>
    ///     Tick time Logic Implementation
    /// </summary>
    public class TickTimeMechanics : BaseGameMechanics
    {
        public TickTimeMechanics(IGame game) : base(game)
        {
            
        }

        private float TimeoutTurn => Game.Configurations.TimeOutTurn;
        private float TimeStartTurn => Game.Configurations.TimeStartTurn;

        /// <summary>
        ///     Execution of the tick logic.
        /// </summary>
        public void Execute()
        {
            if (!Game.IsTurnInProgress)
                return;
            if (!Game.IsGameStarted)
                return;
            if (Game.IsGameFinished)
                return;
            
            //Game.TurnTime++;
            //Gam.TotalTime++;
            // var reverseTime = (int) (TimeOutTurn - 1 - Game.TurnTime - TimeStartTurn);
            //OnTickTime(reverseTime,Game.TurnLogic.CurrentPlayer);

        }

        /// <summary>
        ///     Dispatch tick time to the listeners.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="current"></param>
        void OnTickTime(int time, IPlayer current) =>
            GameEvents.Instance.Notify<GameEvents.IDoTick>(i => i.OnTickTime(time, current));

    }
}