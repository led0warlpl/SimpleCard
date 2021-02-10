using System.Collections.Generic;
using ZoroDex.SimpleCard.Battle.Controller;

namespace ZoroDex.SimpleCard.Battle
{
    public class UiManaText : UiText3DListener,GameEvents.IDoManaManipulation,GameEvents.IPreGameStart
    {
        private const string Mana = "Mana: ";

        void GameEvents.IDoManaManipulation.OnChangeMana(IPlayer player, int amount)
        {
            var user = GameController.Instance.GetUser();

            if (user.Player == player)
                SetMana(player);
        }

        void GameEvents.IPreGameStart.OnPreGameStart(List<IPlayer> list)
        {
            var player = GameController.Instance.GetUser();
            SetMana(player.Player);
        }

        void SetMana(IPlayer player) => SetText(Mana + player.Mana);

    }
}