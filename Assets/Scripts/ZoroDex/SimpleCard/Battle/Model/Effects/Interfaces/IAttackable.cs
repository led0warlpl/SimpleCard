namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     All units that are able to attack
    /// </summary>
    public interface IAttackable
    {

        /// <summary>
        ///     Check for applicable effects before playing (windfury for character, echo for cards)
        /// </summary>
        /// <returns></returns>
        bool CanAttack();

        void ExecuteAttack();

        void OnBeforeAttack();

        void OnAfterAttack();

    }
}