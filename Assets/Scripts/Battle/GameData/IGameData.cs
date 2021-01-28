namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     Game data public interface
    /// </summary>
    public interface IGameData
    {
        IGame RuntimeGame { get; }
        void CreateGame();
        void LoadGame();
        void Clear();
    }
}