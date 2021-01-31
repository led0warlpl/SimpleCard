using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     Manages RuntimeCharacter memory allocation.
    /// </summary>
    public class RuntimeCharacterFactory : Pooler<RuntimeCharacter,RuntimeCharacterFactory>
    {
        private const int Size = 30;
        public RuntimeCharacterFactory() : base(Size)
        {
        }
    }
}