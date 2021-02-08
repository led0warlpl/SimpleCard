using UnityEngine;
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard.Battle
{
    public interface IGameController : IStateMachineHandler,IGameDataHandler
    {
        MonoBehaviour MonoBehaviour { get; }
        IPlayerTurn GetUser();
        IPlayerTurn GetPlayerController(PlayerSeat seat);
        void StartBattle();
        void EndBattle();
        void RestartGameImmediately();

    }
}