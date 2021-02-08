
using ZoroDex.SimpleCard.Patterns;
using UnityEngine;

namespace ZoroDex.SimpleCard.Battle.Controller
{
    /// <summary>
    ///     Main Controller. Holds the FSM which controls the game flow Also provides access to the players controllers
    /// </summary>
    public class GameController : SingletonMB<GameController>,IGameController
    {
        [SerializeField] private Configurations configurations;

        /// <summary>
        ///     All game data. Access via Singleton Pattern.
        /// </summary>
        public IGameData Data => GameData.Instance;

        /// <summary>
        ///     State machine that holds the game logic.
        /// </summary>
        private TurnBasedFsm TurnBasedLogic { get; set; }

        /// <summary>
        ///     Handler for the state machine. Used to dispatch coroutines.
        /// </summary>
        public MonoBehaviour MonoBehaviour => this;

        public string Name => gameObject.name;

        protected override void OnAwake() => Debug.Log("Awake");

        void Start()
        {
            Debug.Log("Start");

            StartBattle();
        }

        /// <summary>
        ///     Return the Left Player. 
        /// </summary>
        /// <returns></returns>
        public IPlayerTurn GetUser() => GetPlayerController(PlayerSeat.Left);

        /// <summary>
        ///     Provides access to players controllers according to the player seat.
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public IPlayerTurn GetPlayerController(PlayerSeat seat) => TurnBasedLogic.GetPlayerController(seat);

        [Button]
        public void StartBattle()
        {
            TurnBasedLogic = new TurnBasedFsm(this, Data, configurations);
            TurnBasedLogic.StartBattle();
        }

        [Button]
        public void EndBattle() => TurnBasedLogic.EndBattle();

        [Button]
        public void RestartGameImmediately()
        {
            GameEvents.Instance.Notify<GameEvents.IRestartGame>(i => i.OnRestart());
            Data.CreateGame();
            StartBattle();
        }
        


    }
}