namespace ZoroDex.SimpleCard.Battle
{
    /// <summary>
    ///     Game dat public interface
    /// </summary>
    public interface IGameData
    {
        IGame RuntimeGame { get; }
        void CreateGame();
        void LoadGame();
        void Clear();
    }
}