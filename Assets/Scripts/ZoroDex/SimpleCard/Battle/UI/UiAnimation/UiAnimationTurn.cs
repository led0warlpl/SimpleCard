using UnityEngine;
using ZoroDex.SimpleCard.Battle;

namespace ZoroDex.SimpleCard
{
    public class UiAnimationTurn : UiAnimation,GameEvents.IStartPlayerTurn
    {
        [SerializeField] private PlayerSeat seat;

        void GameEvents.IStartPlayerTurn.OnStartPlayerTurn(IPlayer player)
        {
            if (player.Seat == seat)
                StartCoroutine(Animate());
        }
    }
}