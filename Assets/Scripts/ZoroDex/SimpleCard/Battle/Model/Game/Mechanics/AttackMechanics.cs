
namespace ZoroDex.SimpleCard.Battle
{
    /// <summary>
    ///     Attack Logic Implementation
    /// </summary>
    public class AttackMechanics : BaseGameMechanics
    {
        public AttackMechanics(IGame game) : base(game)
        {
            
        }
        
        /// <summary>
        ///     Execution of the damage logic
        /// </summary>
        /// <param name="data"></param>
        public void Execute(RuntimeAttackData data)
        {
            if (!Game.IsTurnInProgress)
                return;
            if (!Game.IsGameStarted)
                return;
            if (Game.IsGameFinished)
                return;
            
            //get attacker
            var attackerPlayer = Game.TurnLogic.GetPlayer(data.Agressor.Attributes.Owner.Seat);

            if (!Game.TurnLogic.IsMyTurn(attackerPlayer))
                return;

            var source = data.Agressor;
            var target = data.Blocker;
            

        }

        /// <summary>
        ///     Dispatch damage dealt to the listeners.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="amount"></param>
        void OnDoneDamage(IRuntimeCharacter source, IRuntimeCharacter target, int amount) =>
            GameEvents.Instance.Notify<GameEvents.IDoAttack>(i => i.OnDamage(source, target, amount));
        
        public struct RuntimeAttackData
        {
            public IRuntimeCharacter Agressor { get; set; }
            public IRuntimeCharacter Blocker { get; set; }
            
        }
        
        
    }
}