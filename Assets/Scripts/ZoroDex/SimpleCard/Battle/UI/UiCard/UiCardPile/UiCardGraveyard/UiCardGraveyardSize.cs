using System.Collections.Generic;
using ZoroDex.SimpleCard.Battle.Controller;

namespace ZoroDex.SimpleCard.Battle.UI.Card
{
    /// <summary>
    ///     Card graveyard holds a register with cards played by the player.
    /// </summary> : 
    public class UiCardGraveyardSize: UiText3DListener,GameEvents.IDoReShuffle,GameEvents.IPlayerPlayCard,GameEvents.IPlayerDiscardCard,
        GameEvents.IPreGameStart
    {
        const string Size = "Size: ";

        void GameEvents.IDoReShuffle.OnReShuffle(IPlayer player) => SetSize(player);

        void GameEvents.IPlayerDiscardCard.OnDiscardCard(IPlayer player, IRuntimeCard card) => SetSize(player);
        void GameEvents.IPlayerPlayCard.OnPlayCard(IPlayer player, IRuntimeCard card) => SetSize(player);
        void GameEvents.IPreGameStart.OnPreGameStart(List<IPlayer> players) => SetSize(GameController.Instance.GetUser().Player);


        void SetSize(IPlayer player)
        {
            if (player == GameController.Instance.GetUser().Player)
                SetText(Size + player.Graveyard.Size);
        }

    }
}