namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     Any thing which can manipulate mana.
    /// </summary>
    public interface IManaManipulator
    {
        void ReplanishMana();

        void ConsumeMana(int amount);

        bool HasMana(int amount);

    }
}