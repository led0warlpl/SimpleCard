using Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using ZoroDex.SimpleCard.Battle.Controller;
using ZoroDex.SimpleCard.Battle.UI.UiPlayerHand;

namespace ZoroDex.SimpleCard.Battle.UI.Card
{
    /// <summary>
    ///     Discard/Play cards when the object is clicked.
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