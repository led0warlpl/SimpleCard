using TMPro;
using UnityEngine;
using ZoroDex.SimpleCard.Battle;

namespace ZoroDex.SimpleCard
{
    public class UiAnimationEndGame : UiAnimation,GameEvents.IFinishGame
    {
        private const float DelayToNotify = 1f;
        [SerializeField] private LocalizationIds id;
        [SerializeField] private PlayerSeat seat;
        private TMP_Text Text;

        void GameEvents.IFinishGame.OnFinishGame(IPlayer winner)
        {
            if (winner.Seat == seat)
            {
                Text.text = Localization.Instance.Get(id);
                StartCoroutine(Animate(DelayToNotify));
            }
        }

        protected override void Awake()
        {
            base.Awake();
            Text = GetComponent<TMP_Text>();
        }

    }
}