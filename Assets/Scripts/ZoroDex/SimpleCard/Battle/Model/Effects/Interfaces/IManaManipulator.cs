namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     Any thing which can manipulate mana.
    /// </summary>
    public interface IManaManipulator
    {
        void ReplanishMana();

        void ConsumeMana(int amount);

        void HasMana(int amount);

    }
}