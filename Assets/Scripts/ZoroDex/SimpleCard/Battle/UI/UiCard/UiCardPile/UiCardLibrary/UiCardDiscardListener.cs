


using Extensions;
using UnityEngine;
using ZoroDex.SimpleCard.Battle.Controller;

namespace ZoroDex.SimpleCard.Battle.UI.Card
{
    public class UiCardDiscardListener : UiListener,GameEvents.IPlayerDiscardCard
    {
        UiPlayerHandUtils CardUtils { get; set; }
        IUiPlayer UiPlayer { get; set; }

        void GameEvents.IPlayerDiscardCard.OnDiscardCard(IPlayer player, IRuntimeCard card)
        {
            if (player.Seat != UiPlayer.Seat)
                return;

            CardUtils.Discard(card);
        }

        void Awake()
        {
            CardUtils = transform.parent.GetComponentInChildren<UiPlayerHandUtils>();
            UiPlayer = transform.parent.GetComponentInChildren<IUiPlayer>();

        }
        
        //TODO: it will be removed
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
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
}