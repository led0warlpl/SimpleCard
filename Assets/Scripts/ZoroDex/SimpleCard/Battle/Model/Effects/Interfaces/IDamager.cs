

namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     All units tht are able to give damage.
    /// </summary>
    public interface IDamager
    {

        /// <summary>
        ///     Tries to inflict damage to the target. Returns the effective damage dealt after reductions or bonus.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        int GiveDamage(IDamageable target);

    }
}