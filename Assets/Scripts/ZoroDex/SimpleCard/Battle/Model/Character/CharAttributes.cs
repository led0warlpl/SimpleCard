using ZoroDex.SimpleCard.Data.Character;

namespace ZoroDex.SimpleCard
{
    public class CharAttributes
    {
        public CharAttributes(ICharacterData data, IPlayer owner) => SetData(data, owner);

        public IPlayer Owner { get; set; }
        public int Health { get; set; }
        public bool IsDead => Health <= 0;
        public bool HasTaunt { get; set; }
        
        public void SetData(ICharacterData data, IPlayer owner)
        {
            
        }
    }
}