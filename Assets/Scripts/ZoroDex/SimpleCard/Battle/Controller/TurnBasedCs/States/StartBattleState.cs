using System.Collections;
using UnityEngine;

namespace ZoroDex.SimpleCard.Battle.Controller
{
    public class StartBattleState : BaseBattleState,GameEvents.IStartGame
    {

        public StartBattleState(TurnBasedFsm fsm, IGameData gameData, Configurations configurations) :
            base(fsm, gameData, configurations)
        {
            
        }


        public override void OnEnterState()
        {
            base.OnEnterState();
            //schedule pre game
            Fsm.Handler.MonoBehaviour.StartCoroutine(PreGameRoutine());
            
            //schedule start game
            Fsm.Handler.MonoBehaviour.StartCoroutine(StartGameRoutine());
        }
        
        // ------------------------------------------------------------

        void GameEvents.IStartGame.OnStartGame(IPlayer starter)
        {
            var nextState = Fsm.GetPlayerController(starter);
            Fsm.Handler.MonoBehaviour.StartCoroutine(NextStateRoutine(nextState));
        }

        IEnumerator NextStateRoutine(BaseBattleState nextState)
        {
            yield return new WaitForSeconds(Configurations.FirstPlayer);
            OnNextState(nextState);
        }
        
        
        // -----------------------------------------------------------

        IEnumerator PreGameRoutine()
        {
            yield return new WaitForSeconds(Configurations.PreGameEvent);
            GameData.RuntimeGame.PreStartGame();
            
        }

        IEnumerator StartGameRoutine()
        {
            var time = Configurations.PreGameEvent + Configurations.StartGameEvent;
            yield return new WaitForSeconds(time);
            GameData.RuntimeGame.StartGame();
        }
        
        
    }
}