using System.Collections.Generic;

namespace ZoroDex.SimpleCard.Battle
{
    /// <summary>
    ///     Simple concrete Game Implementation.
    ///     TODO: Consider to break this class down into small partial classes.
    /// </summary>
    public class Game : IGame
    {
        // --------------------------------------------------------------
        public Game(List<IPlayer> players, Configurations configurations)
        {
            Configurations = configurations;
            ProcessTurn = new ProcessTurn(players);
            ProcessPreStartGame = new PreStartGameMechanics(this);
            ProcessStartGame = new StartGameMechanics(this);
            ProcessStartPlayerTurn = new StartPlayerTurnMechanics(this);
            ProcessFinishPlayerTurn = new FinishPlayerTurnMechanics(this);

            global::Logger.Instance.Log<Game>("Game Created", "blue);");

        }
        
        // -----------------------------------------------------------------

        #region Properties

        public FinishGameMechanics FinishGame => ProcessFinishGame;
        public List<IPlayer> Players => ProcessTurn.Players;
        public ITurnLogic TurnLogic => ProcessTurn;
        public bool IsGameStarted { get; set; }
        public bool IsGameFinished { get; set; }
        public bool IsTurnInProgress { get; set; }
        
        public int TurnTime { get; set; }
        public int TotalTime { get; set; }
        public  Configurations Configurations { get; }
        

        #endregion
        
        // -----------------------------------------------------------------


        #region Processes

        public List<BaseGameMechanics> Mechanics { get; set; } = new List<BaseGameMechanics>();
        private ProcessTurn ProcessTurn { get; }
        private PreStartGameMechanics ProcessPreStartGame { get; }
        private StartGameMechanics ProcessStartGame { get; }
        TickTimeMechanics ProcessTick{get;}
        private StartPlayerTurnMechanics ProcessStartPlayerTurn { get; }
        private FinishPlayerTurnMechanics ProcessFinishPlayerTurn { get; }
        private AttackMechanics ProcessAttack { get; }
        private FinishGameMechanics ProcessFinishGame { get; }

        #endregion
        
        // -----------------------------------------------------------

        public void PreStartGame() => ProcessPreStartGame.Execute();

        public void StartGame() => ProcessStartGame.Execute();

        public void StartCurrentPlayerTurn() => ProcessStartPlayerTurn.Execute();
        public void FinishCurrentPlayerTurn()=>ProcessFinishPlayerTurn.Execute();

        public void Tick() => ProcessTick.Execute();

        public void Attack(AttackMechanics.RuntimeAttackData data) => ProcessAttack.Execute(data);
    }
}