namespace ZoroDex.SimpleCard.Battle
{
    public class DamageMechanic : CharMechanic
    {
        public DamageMechanic(IRuntimeCharacter character) : base(character)
        {
            
        }

        public int DoAttack(IDamageable target)
        {
            var damage = Character.Attributes.Attack;
            return target.TakeDamage(Character, damage);
        }
        
    }
}