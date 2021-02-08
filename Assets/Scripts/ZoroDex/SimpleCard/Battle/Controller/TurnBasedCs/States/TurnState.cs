﻿using System.Collections;
using UnityEngine;

namespace ZoroDex.SimpleCard.Battle.Controller
{
    public abstract class TurnState : BaseBattleState,GameEvents.IFinishPlayerTurn,IPlayerTurn
    {

        protected TurnState(TurnBasedFsm fsm, IGameData gameData, Configurations configurations) : base(fsm, gameData,
            configurations)
        {
            var game = GameData.RuntimeGame;
            
            // get player according to the seat
            Player = game.TurnLogic.GetPlayer(Seat);
            
            //register turn state
            Fsm.RegisterPlayerState(Player,this);

        }

        #region Properties

        public IPlayer Player { get; }
        public IPlayer Opponent => GameData.RuntimeGame.TurnLogic.GetOpponent(Player);
        public bool IsMyTurn => GameData.RuntimeGame.TurnLogic.IsMyTurn(Player);

        public virtual PlayerSeat Seat => PlayerSeat.Right;
        public virtual bool IsAi => false;
        public virtual bool IsUser => false;
        private Coroutine TimeOutRoutine { get; set; }
        private Coroutine TickRoutine { get; set; }
        

        #endregion

        #region Game Events

        public void OnFinishPlayerTurn(IPlayer player)
        {
            if(IsMyTurn)
                NextTurn();
            
        }

        /// <summary>
        ///     Switches the turn according to the next player.
        /// </summary>
        void NextTurn()
        {
            var game = GameData.RuntimeGame;
            var nextPlayer = game.TurnLogic.NextPlayer;
            var nextState = Fsm.GetPlayerController(nextPlayer);
            OnNextState(nextState);
            
        }

        #endregion

        public override void OnEnterState()
        {
            base.OnEnterState();
            
            //setup timer to end the turn
            TimeOutRoutine = Fsm.Handler.MonoBehaviour.StartCoroutine(TimeOut());
            
            //start current player turn
            Fsm.Handler.MonoBehaviour.StartCoroutine(StartTurn());
        }

        public override void OnExitState()
        {
            base.OnExitState();
            RestartTimeouts();
        }


        /// <summary>
        ///     Clear the state to the initial configuration and stops all the internal routines.
        /// </summary>
        public override void OnClear()
        {
            base.OnClear();
            RestartTimeouts();
        }

        protected virtual void RestartTimeouts()
        {
            if (TimeOutRoutine != null)
                Fsm.Handler.MonoBehaviour.StopCoroutine(TimeOutRoutine);
            TimeOutRoutine = null;
            
            if(TickRoutine != null)
                Fsm.Handler.MonoBehaviour.StopCoroutine(TickRoutine);
            TickRoutine = null;
        }
        
        
        // --------------------------------------------------------------
        /// <summary>
        ///     Check if the player can pass the turn and passes the turn to the next player.
        /// </summary>
        /// <returns></returns>
        public bool PassTurn()
        {
            GameData.RuntimeGame.FinishCurrentPlayerTurn();
            return true;
        }

        public void Attack(AttackMechanics.RuntimeAttackData attackData) => GameData.RuntimeGame.Attack(attackData);
        

        // --------------------------------------------------------------


        #region Coroutine

        IEnumerator TickRoutineAsync()
        {
            while (true)
            {
                //every second
                yield return new WaitForSeconds(1);
                GameData.RuntimeGame.Tick();
            }
        }
        
        /// <summary>
        ///     Finishes the player turn.
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerator TimeOut()
        {
            //disable the timeout for player
            if (IsUser)
                yield return 0;

            if (TimeOutRoutine != null)
            {
                Fsm.Handler.MonoBehaviour.StopCoroutine(TimeOutRoutine);
                TimeOutRoutine = null;
            }
            else
            {
                yield return new WaitForSeconds(Configurations.TimeOutTurn);
            }

            PassTurn();

        }

        /// <summary>
        ///     Starts the player turn.
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerator StartTurn()
        {
            yield return new WaitForSeconds(Configurations.TimeStartTurn);
            GameData.RuntimeGame.StartCurrentPlayerTurn();
            
            //setup tick routine
            TickRoutine = Fsm.Handler.MonoBehaviour.StartCoroutine(TickRoutineAsync());
        }
        

        #endregion
        
        
    }
}