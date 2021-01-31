using ZoroDex.SimpleCard.Data.Character;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard
{
    /// <summary>
    /// A character in the game.
    /// </summary>
    public interface IRuntimeCharacter : ITargetable,IHealer,IHealable,IDamageable,IDamager,IKillable,IAttackable 
    {
        ICharacterData Data { get; }
        CharAttributes Attributes { get; }
        void StartPlayerTurn();
    }
}