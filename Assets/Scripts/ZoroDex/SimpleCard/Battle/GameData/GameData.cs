using System;
using System.Collections.Generic;
using UnityEngine;
using ZoroDex.SimpleCard.Data.Deck;
using ZoroDex.SimpleCard.Data.Team;
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard.Battle
{
    /// <summary>
    ///     Game Data concrete implementation with Singleton pattern.
    /// </summary>
    public class GameData : SingletonMB<GameData>,IGameData
    {
        // ---------------------------------------------------------------
        [SerializeField] private Configurations configurations;
        [SerializeField] private TeamsCurrentData currentTeams;
        [SerializeField] private LibraryData deckData;

        private TeamData TeamData => currentTeams.PlayerTeam;
        private TeamData EnemiesData => currentTeams.EnemyTeam;

        #region Properties

        /// <summary>
        ///     All game data.
        /// </summary>
        public IGame RuntimeGame { get; private set; }
        

        #endregion
        
        // -------------------------------------------------------------------

        #region Unity Callbacks

        
        /// <summary>
        ///     Initialize game data OnAwake.
        /// </summary>
        protected override void OnAwake()
        {
            Logger.Instance.Log<GameData>("Awake");
        }

        void Start() => Logger.Instance.Log<GameData>("Start");
        

        #endregion
        
        // ------------------------------------------------------------

        /// <summary>
        ///     Clears the game data.
        /// </summary>
        public void Clear() => RuntimeGame = null;

        /// <summary>
        ///     Create a new game data overriding the previous one. Produces Garbage.
        /// </summary>
        public void CreateGame()
        {
            //TODO: wait Player implement
            //create and connect players to their seats
            var player1 = new Player(PlayerSeat.Left, TeamData, deckData, configurations);
            
            //if the second player doesn't have a dec, send null
            var player2 = new Player(PlayerSeat.Right, EnemiesData, null, configurations);
            
            //create game data
            RuntimeGame = new Game(new List<IPlayer> {player1, player2}, configurations);



        }

        public void LoadGame() => throw new NotImplementedException();


    }
}