﻿using TMPro;
using ZoroDex.SimpleCard.Battle;

namespace ZoroDex.SimpleCard
{
    public class UiAnimationStartGame : UiAnimation,GameEvents.IStartGame
    {
        private const float DelayToNotify = 0.75f;
        private const string You = "You";
        private const string Opp = "Opponent";
        private const string S = "s";
        private TMP_Text Text;

        void GameEvents.IStartGame.OnStartGame(IPlayer player)
        {
            var txt = player.Seat == PlayerSeat.Left ? You : Opp;
            var plural = player.Seat == PlayerSeat.Left ? string.Empty : S;
            Text.text = txt + " start" + plural + "!";
            StartCoroutine(Animate(DelayToNotify));
        }

        protected override void Awake()
        {
            base.Awake();
            Text = GetComponent<TMP_Text>();
        }
    }
}