
using TMPro;
using UnityEngine;

namespace ZoroDex.SimpleCard.Battle.UI.Character
{
    public class UiCharacterCombat : UiListener,GameEvents.IDoAttack
    {
        const string CantAttack = "CantAttack";
        const float HeightNotification = 4;
        const float SpeedNotification = 3;

        [SerializeField] UiPlayerTeam leftTeam;
        [SerializeField] UiPlayerTeam rightTeam;

        public void OnDamage(IDamager source, IDamageable target, int amount)
        {
            throw new System.NotImplementedException();
        }

        void GameEvents.IDoAttack.OnCantAttack(IDamager source, IDamageable target, int amount)
        {
            var sourceChar = (IRuntimeCharacter) source;
            var agressor = GetUi(sourceChar);
            var notf = UiNotificationTextPooler.Instance.Get(); 
            var final = agressor.transform.position + new Vector3(0, HeightNotification, 0);
            notf.Write(agressor.transform.position,final,CantAttack,SpeedNotification,Color.red);
        }

        void GameEvents.IDoAttack.OnDamage(IDamager source, IDamageable target, int amount)
        {
            var targetChar = (IRuntimeCharacter) target;
            var sourceChar = (IRuntimeCharacter) source;

            var agressor = GetUi(sourceChar);
            var defender = GetUi(targetChar);

            if (agressor != null && defender != null)
                agressor.Attack(defender.transform.position);
        }
        

        IUiCharacter GetUi(IRuntimeCharacter ch)
        {
            var ui = rightTeam.GetCharacter(ch);
            if (ui == null)
                ui = leftTeam.GetCharacter(ch);
            return ui;
        }

    }
}