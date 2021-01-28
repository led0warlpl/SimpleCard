﻿using System;
using SimpleCardGames.Battle;
using UnityEngine;

namespace SimpleCardGames
{
    /// <summary>
    ///     This class holds all the custumizeable configurations.
    /// </summary>
    [CreateAssetMenu(menuName = "Configurations")]
    public class Configurations : ScriptableObject
    {
        //----------------------------------------------------------------------------------------------------------

        public Amounts Amount = new Amounts();
        //----------------------------------------------------------------------------------------------------------

        #region Extra

        [SerializeField] bool areLogsEnabled;

        #endregion

        [Serializable]
        public class Amounts
        {
            #region DamagePlayers

            public DamagePlayers Damage = new DamagePlayers();

            [Serializable]
            public class DamagePlayers
            {
                [Range(1, 10)] public int MaxDamage = 4;

                [Range(1, 10)] public int MinDamage = 1;
            }

            #endregion

            //----------------------------------------------------------------------------------------------------------

            #region HealPlayers

            public HealPlayers Heal = new HealPlayers();

            [Serializable]
            public class HealPlayers
            {
                [Range(1, 10)] public int MaxHeal = 4;

                [Range(1, 10)] public int MinHeal = 1;
            }

            #endregion

            //----------------------------------------------------------------------------------------------------------

            #region Health

            public Health HealthPlayers = new Health();

            [Serializable]
            public class Health
            {
                [Range(1, 15)] public int healthBottomPlayer = 6;
                [Range(1, 15)] public int healthTopPlayer = 6;
                [Range(1, 15)] public int maxMana = 5;

                public int GetHealth(PlayerSeat seat) => seat == PlayerSeat.Left ? healthBottomPlayer : healthTopPlayer;
            }

            #endregion

            //----------------------------------------------------------------------------------------------------------

            #region Bonus Random

            public BonusRandom Bonus = new BonusRandom();

            [Serializable]
            public class BonusRandom
            {
                [Range(1, 5)] public int Value = 2;
            }

            #endregion

            //----------------------------------------------------------------------------------------------------------

            #region Library

            public Library LibraryPlayer = new Library();

            [Serializable]
            public class Library
            {
                [Tooltip("Quantity of cards drawn each turn.")] [Range(0, 7)]
                public int drawAmountByTurn = 1;

                [Tooltip("Whether hands are discarded in the end of the turn or not.")]
                public bool isDiscardableHands;

                [Tooltip("Whether the library has an finite amount of cards or it reshuffles automatically.")]
                public bool isFinite;

                [Tooltip("Amount of cards in the starting hand.")] [Range(0, 7)]
                public int startingAmount = 3;
            }

            #endregion

            //----------------------------------------------------------------------------------------------------------
        }

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        //logs
        public bool AreLogsEnabled => areLogsEnabled;

        //player turn
        public float TimeStartTurn => PlayerTurn.TimeStartTurn;
        public float TimeOutTurn => PlayerTurn.TimeOutTurn;

        //game start
        public float PreGameEvent => GameStart.PreGameEvent;
        public float StartGameEvent => GameStart.StartGameEvent;
        public float FirstPlayer => GameStart.FirstPlayer;
        public float TotalStartGame => StartGameEvent + PreGameEvent + FirstPlayer;

        //ai
        public AiArchetype TopAiArchetype => Ai.TopPlayer.Archetype;
        public AiArchetype BottomAiArchetype => Ai.BottomPlayer.Archetype;
        public bool TopIsAi => Ai.TopPlayer.IsAi;
        public bool BottomIsAi => Ai.BottomPlayer.IsAi;
        public float AiDoTurnDelay => Ai.AiDoTurnDelay;
        public float AiFinishTurnDelay => Ai.AiFinishTurnDelay;

        //player health
        public int HealthTopPlayer => Amount.HealthPlayers.healthTopPlayer;
        public int HealthBottomPlayer => Amount.HealthPlayers.healthBottomPlayer;

        public int MaxMana => Amount.HealthPlayers.maxMana;

        public bool withStartingHands;
        public bool WithStartingHands => withStartingHands;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Game Start

        public GameStartEvents GameStart = new GameStartEvents();

        [Serializable]
        public class GameStartEvents
        {
            [Tooltip("Time between Start Game event and First Player turn animation")] [Range(3f, 6f)]
            public float FirstPlayer;

            [Range(0.01f, 0.5f)] [Tooltip("Time between Load and Pregame Event")]
            public float PreGameEvent;

            [Tooltip("Time between Pregame event and Start Game Event")] [Range(0.01f, 0.5f)]
            public float StartGameEvent;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region PlayerHandler Turn

        public PlayerTurnEvents PlayerTurn = new PlayerTurnEvents();

        [Serializable]
        public class PlayerTurnEvents
        {
            [Range(6f, 12f)] [Tooltip("Total player turn time")]
            public float TimeOutTurn;

            [Range(0.01f, 2f)] [Tooltip("Time until player starts the turn after the animation.")]
            public float TimeStartTurn;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region AI

        public AiConfigs Ai = new AiConfigs();

        [Serializable]
        public class AiConfigs
        {
            [Range(0.01f, 4)] [Tooltip("Time until ai do it's turn.")]
            public float AiDoTurnDelay = 2.5f;

            [Range(0.01f, 10)] [Tooltip("Time maximum for AI turns.")]
            public float AiFinishTurnDelay = 3.5f;

            [Tooltip("Configurations for Bottom player")]
            public Player BottomPlayer = new Player
            {
                IsAi = false
            };

            [Tooltip("Configurations for Top player")]
            public Player TopPlayer = new Player
            {
                IsAi = true
            };

            [Serializable]
            public class Player
            {
                [Tooltip("The behavior of the AI system")]
                public AiArchetype Archetype;

                [Tooltip("Whether this player controlled by an AI System or not")]
                public bool IsAi;
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}