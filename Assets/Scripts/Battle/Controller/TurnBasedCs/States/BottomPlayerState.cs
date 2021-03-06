﻿namespace SimpleCardGames.Battle.Controller
{
    /// <summary>
    ///     Bottom, where the User is always sitting.
    /// </summary>
    public class BottomPlayerState : AiTurnState
    {
        //----------------------------------------------------------------------------------------------------------

        #region Constructor

        public BottomPlayerState(TurnBasedFsm fsm, IGameData gameData, Configurations configurations) :
            base(fsm, gameData, configurations)
        {
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        public override PlayerSeat Seat => PlayerSeat.Left;
        protected override AiArchetype AiArchetype => Configurations.BottomAiArchetype;
        public override bool IsAi => Configurations.BottomIsAi;
        public override bool IsUser => true;

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}