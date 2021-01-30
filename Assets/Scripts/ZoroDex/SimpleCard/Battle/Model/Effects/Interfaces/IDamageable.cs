using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard
{
 
        /// <summary>
        ///     All units that are able to take damage.
        /// </summary>
        public interface IDamageable : ITargetable
        {

            /// <summary>
            ///     Take some damage and return the real damage after reductions or bonus.
            /// </summary>
            /// <param name="source"></param>
            /// <param name="amount"></param>
            /// <returns></returns>
            int TakeDamage(IDamager source, int amount);

        }
    
}