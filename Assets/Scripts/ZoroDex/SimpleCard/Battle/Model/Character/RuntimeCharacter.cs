using ZoroDex.SimpleCard.Data.Character;
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard
{
    public class RuntimeCharacter : IRuntimeCharacter,IPoolable
    {
        public RuntimeCharacter()
        {
            
        }

        
        
        public void SetData(ICharacterData data, IPlayer player)
        {
            Data = data;
            Attributes = new CharAttributes(Data, player);
            // TODO: wait implement Mechanics
        }
        public int DoHeal(IHealable target, int healAmount)
        {
            throw new System.NotImplementedException();
        }

        public int TakeHeal(IHealer source, int amount)
        {
            throw new System.NotImplementedException();
        }

        public int TakeDamage(IDamager source, int amount)
        {
            throw new System.NotImplementedException();
        }

        public int GiveDamage(IDamageable target)
        {
            throw new System.NotImplementedException();
        }

        public void EvaluateDeath()
        {
            throw new System.NotImplementedException();
        }

        public bool CanAttack()
        {
            throw new System.NotImplementedException();
        }

        public void ExecuteAttack()
        {
            throw new System.NotImplementedException();
        }

        public void OnBeforeAttack()
        {
            throw new System.NotImplementedException();
        }

        public void OnAfterAttack()
        {
            throw new System.NotImplementedException();
        }

        public ICharacterData Data { get; set; }
        public CharAttributes Attributes { get; private set; }
        public void StartPlayerTurn()
        {
            throw new System.NotImplementedException();
        }

        public void Restart()
        {
            throw new System.NotImplementedException();
        }
    }
}