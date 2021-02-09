using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ZoroDex.SimpleCard.Battle;

namespace ZoroDex.SimpleCard
{
    public class UiClock : UiListener,GameEvents.IDoTick,GameEvents.IPreGameStart,GameEvents.IFinishPlayerTurn
    {
        private void Awake()
        {
            Text = GetComponent<TMP_Text>();
            TimeText = Localization.Instance.Get(LocalizationIds.Time) + ":";
            
        }

        void Update()
        {
            if (!IsBlinking)
                return;

            currentBlinkTime += Time.deltaTime;
            if (!(currentBlinkTime >= maxBlinkTime))
                return;

            currentBlinkTime = 0;
            Text.enabled = !Text.enabled;

            
        }

        void Restart()
        {
            IsBlinking = false;
            Text.enabled = false;

        }

        private const float BlinkFactor = 0.1f;
        private const int BlinkStart = 3;
        private float currentBlinkTime;
        private float maxBlinkTime;
        [SerializeField] private PlayerSeat seat;
        private TMP_Text Text { get; set; }
        private string TimeText { get; set; }
        private bool IsBlinking { get; set; }

        void GameEvents.IDoTick.OnTickTime(int time, IPlayer player)
        {
            if (player.Seat != seat)
                return;

            Text.text = TimeText + time;
            Text.enabled = true;

            if (time > BlinkStart)
                return;

            IsBlinking = true;

            if (time > 0)
                maxBlinkTime = time * BlinkFactor;

        }

        void GameEvents.IFinishPlayerTurn.OnFinishPlayerTurn(IPlayer player) => Restart();

        void GameEvents.IPreGameStart.OnPreGameStart(List<IPlayer> players) => Restart();


    }
}