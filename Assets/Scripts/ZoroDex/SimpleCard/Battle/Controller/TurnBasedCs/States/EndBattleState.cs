namespace ZoroDex.SimpleCard.Battle.Controller
{
    /// <summary>
    ///     Holds the Game flow when a match is Finished.
    /// </summary>
    public class EndBattleState : BaseBattleState,GameEvents.IFinishGame
    {

        public EndBattleState(TurnBasedFsm fsm, IGameData gameData, Configurations configurations) : base(fsm, gameData,
            configurations)
        {
            
        }

        void GameEvents.IFinishGame.OnFinishGame(IPlayer winner) => Fsm.EndBattle();
    }
}