using System.Collections.Generic;
using ZoroDex.SimpleCard.Battle.Controller;

namespace ZoroDex.SimpleCard.Battle.UI.Card
{
    public class UiCardLibrarySize : UiText3DListener,GameEvents.IDoReShuffle,GameEvents.IPlayerDrawCard,GameEvents.IPreGameStart
    {
        const string Size = "Size: ";
        void GameEvents.IDoReShuffle.OnReShuffle(IPlayer player) => SetSize(player);

        void GameEvents.IPlayerDrawCard.OnDrawCard(IPlayer player, IRuntimeCard card) => SetSize(player);

        void GameEvents.IPreGameStart.OnPreGameStart(List<IPlayer> players) =>
            SetSize(GameController.Instance.GetUser().Player);

        void SetSize(IPlayer player)
        {
            if (player == GameController.Instance.GetUser().Player)
                SetText(Size + player.Library.Size);
        }

    }
}