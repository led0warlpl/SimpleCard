﻿using Extensions;
using SimpleCardGames.Battle.Controller;
using Tools.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleCardGames.Battle.UI.Card
{
    /// <summary>
    ///     Dicard/Play cards when the object is clicked.
    /// </summary>
    [RequireComponent(typeof(IMouseInput))]
    public class UiCardDiscardClick : MonoBehaviour
    {
        UiPlayerHandUtils Utils { get; set; }
        IMouseInput Input { get; set; }

        void Awake()
        {
            Utils = transform.parent.GetComponentInChildren<UiPlayerHandUtils>();
            Input = GetComponent<IMouseInput>();
            Input.OnPointerClick += PlayRandom;
        }

        void PlayRandom(PointerEventData obj)
        {
            var myPlayer = GameController.Instance.GetPlayerController(PlayerSeat.Left).Player;
            if (myPlayer.Hand.Size > 0)
            {
                var rndCard = myPlayer.Hand.Units.RandomItem();
                if (rndCard != null)
                    myPlayer.Discard(rndCard);
            }
        }
    }
}