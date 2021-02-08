using System;
using ZoroDex.SimpleCard.Battle;
using ZoroDex.SimpleCard.Data.Character;
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     A concrete character in the game.
    /// </summary>
    public class RuntimeCharacter : IRuntimeCharacter,IPoolable
    {
        public RuntimeCharacter()
        {
            
        }

        public RuntimeCharacter(ICharacterData characterData, IPlayer player) => SetData(characterData, player);
        
        // ------------------------------------------------------------------
        
        
        public void SetData(ICharacterData data, IPlayer player)
        {
            Data = data;
            Attributes = new CharAttributes(Data, player);
            Health = new HealthMechanic(this);
            Damage = new DamageMechanic(this);
            Heal = new HealMechanic(this);
            Death = new DeathMechanic(this);
            AttackTurn = new AttackCharacterMechanic(this);
           
        }

        #region Heal

        public int DoHeal(IHealable target, int healAmount) => Heal.DoHeal(target, healAmount);

        public int TakeHeal(IHealer source, int amount) => Health.TakeHeal(source, amount);

        #endregion

        #region Damage

        public int TakeDamage(IDamager source, int amount)
        {
            var dmg = Health.TakeDamage(source, amount);
            EvaluateDeath();
            return dmg;
        }

        public int GiveDamage(IDamageable target)
        {
            var dmg = Damage.DoAttack(target);
            return dmg;
        }

        #endregion

        #region Death

        public void EvaluateDeath() => Death.EvaluateDeath();

        #endregion

        #region Attack

        public bool CanAttack() => AttackTurn.CanAttack() && !Attributes.HasSummoningSickness;

        public void ExecuteAttack() => AttackTurn.Execute();

        public void OnBeforeAttack() => AttackTurn.OnBeforeAttack();

        public void OnAfterAttack() => AttackTurn.OnAfterAttack();

        #endregion

        public ICharacterData Data { get; set; }
        public CharAttributes Attributes { get; private set; }
        public void StartPlayerTurn()
        {
            Attributes.HasSummoningSickness = false;
            AttackTurn.ResetAttackQuantity();
        }

        

        public void Restart()
        {
            
        }

        #region Mechanics

        private AttackCharacterMechanic AttackTurn { get; set; }
        private HealthMechanic Health { get; set; }
        private DamageMechanic Damage { get; set; }
        private DeathMechanic Death { get; set; }
        private HealMechanic Heal { get; set; }

        #endregion
        
        // ------------------------------------------------------------
        
    }
}