namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     All units that are able to die.
    /// </summary>
    public interface IKillable
    {
        /// <summary>
        ///     Evaluate character death.
        /// </summary>
        void EvaluateDeath();
    }
}