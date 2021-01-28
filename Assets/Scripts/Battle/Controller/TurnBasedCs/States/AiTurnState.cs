﻿using System.Collections;
using UnityEngine;

namespace SimpleCardGames.Battle.Controller
{
    public class AiTurnState : TurnState
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        protected AiTurnState(TurnBasedFsm fsm, IGameData gameData, Configurations configurations) : base(fsm, gameData,
            configurations) =>
            AiModule = new AiModule(Player, GameData.RuntimeGame);

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        Coroutine AiFinishTurnRoutine { get; set; }
        AiModule AiModule { get; }
        protected virtual AiArchetype AiArchetype => Configurations.Ai.TopPlayer.Archetype;
        float AiFinishTurnDelay => Configurations.AiFinishTurnDelay;
        float AiDoTurnDelay => Configurations.AiDoTurnDelay;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Operations

        protected override IEnumerator StartTurn()
        {
            AiModule.SwapAiToArchetype(AiArchetype);
            yield return base.StartTurn();
            //call do turn routine
            Fsm.Handler.MonoBehaviour.StartCoroutine(AiDoTurn());
            //call finish turn routine
            AiFinishTurnRoutine = Fsm.Handler.MonoBehaviour.StartCoroutine(AiFinishTurn(AiFinishTurnDelay));
        }

        protected override void RestartTimeouts()
        {
            base.RestartTimeouts();

            if (AiFinishTurnRoutine != null)
                Fsm.Handler.MonoBehaviour.StopCoroutine(AiFinishTurnRoutine);
            AiFinishTurnRoutine = null;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Coroutines

        IEnumerator AiDoTurn()
        {
            yield return new WaitForSeconds(AiDoTurnDelay);

            if (!IsMyTurn)
                yield break;

            if (!IsAi)
                yield break;

            var bestMoves = AiModule.GetBestMove();

            foreach (var move in bestMoves)
            {
                yield return new WaitForSeconds(0.8f);
                Attack(move);
            }
        }

        IEnumerator AiFinishTurn(float delay)
        {
            yield return new WaitForSeconds(delay);
            if (!IsMyTurn)
                yield break;

            if (!IsAi)
                yield break;

            Fsm.Handler.MonoBehaviour.StartCoroutine(TimeOut());
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}