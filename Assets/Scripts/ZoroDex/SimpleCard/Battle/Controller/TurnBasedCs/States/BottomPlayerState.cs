namespace ZoroDex.SimpleCard.Battle.Controller
{
    /// <summary>
    ///     Bottom, where the User is always sitting.
    /// </summary>
    public class BottomPlayerState : AiTurnState
    {
        public BottomPlayerState(TurnBasedFsm fsm, IGameData gameData, Configurations configuration)
            : base(fsm, gameData, configuration)
        {
            
        }


        public override PlayerSeat Seat => PlayerSeat.Left;
        protected override AiArchetype AiArchetype => Configurations.BottomAiArchetype;
        public override bool IsAi => Configurations.BottomIsAi;
        public override bool IsUser => true;

    }
}