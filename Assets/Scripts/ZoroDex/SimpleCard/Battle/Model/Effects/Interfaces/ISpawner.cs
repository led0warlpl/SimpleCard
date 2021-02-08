using ZoroDex.SimpleCard.Data.Character;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     All units that are able to spawn other units.
    /// </summary>
    public interface ISpawner
    {
        
        void DoSpawn(int amount, ICharacterData data, IEffectable source);

    }
}