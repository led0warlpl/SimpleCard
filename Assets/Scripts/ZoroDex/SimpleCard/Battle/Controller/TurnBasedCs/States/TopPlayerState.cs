namespace ZoroDex.SimpleCard.Battle.Controller
{
    public class TopPlayerState : AiTurnState
    {
        public TopPlayerState(TurnBasedFsm fsm, IGameData gameData, Configurations configurations) :
            base(fsm, gameData, configurations)
        {
            
        }

        public override PlayerSeat Seat => PlayerSeat.Right;
        public override bool IsAi => Configurations.TopIsAi;
        protected override AiArchetype AiArchetype => Configurations.TopAiArchetype;
        public override bool IsUser => false;
    }
}