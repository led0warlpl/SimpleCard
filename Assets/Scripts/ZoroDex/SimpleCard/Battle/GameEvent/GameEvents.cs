using System.Collections.Generic;
using ZoroDex.SimpleCard.Battle.Model.Player;
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard.Battle
{
    public class GameEvents : Observer<GameEvents>
    {
        
        // ----------------------------------------------------------------
        protected override void OnAwake() => global::Logger.Instance.Log<GameEvents>("Awake");

        void Start() => global::Logger.Instance.Log<GameEvents>("Start");
        
        // -----------------------------------------------------------------

        /// <summary>
        ///     Broadcast of the players right before the game start.
        /// </summary>
        public interface IPreGameStart : ISubject
        {
            void OnPreGameStart(List<IPlayer> players);
        }

        /// <summary>
        ///     Broadcast of the starter player to the Listeners.
        /// </summary>
        public interface IStartGame : ISubject
        {
            void OnStartGame(IPlayer starter);
        }

        /// <summary>
        ///     Broadcast of the winner after a game is finished to the Listerners.
        /// </summary>
        public interface IFinishGame : ISubject
        {
            void OnFinishGame(IPlayer winner);
        }

        /// <summary>
        ///     Broadcast of a player when it starts the turn to the Listeners.
        /// </summary>
        public interface IStartPlayerTurn : ISubject
        {
            void OnStartPlayerTurn(IPlayer player);
        }

        /// <summary>
        ///     Broadcast of player when it finishes the turn to the Listners.
        /// </summary>
        public interface IFinishPlayerTurn : ISubject
        {
            void OnFinishPlayerTurn(IPlayer player);
        }

        /// <summary>
        ///     Broadcast of a attack to the Listeners.
        /// </summary>
        public interface IDoAttack : ISubject
        {
            void OnDamage(IDamager source, IDamageable target, int amount);
            
            //Character has not attacks left
            void OnCantAttack(IDamager source, IDamageable target, int amount);
        }
        
        
        
    }
}