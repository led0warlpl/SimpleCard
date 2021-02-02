
using ZoroDex.SimpleCard.Battle;
using ZoroDex.SimpleCard.Patterns;


namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     Manages RuntimeCard memory allocation.
    /// </summary>
    public class RuntimeCardFactory : Pooler<RuntimeCard,RuntimeCardFactory>
    {
        private const int Size = 30;
        
        public RuntimeCardFactory() : base(Size){}
    }
}