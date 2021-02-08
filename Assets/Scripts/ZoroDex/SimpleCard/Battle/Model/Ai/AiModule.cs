using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;


namespace ZoroDex.SimpleCard.Battle
{
    
    /// <summary>
    ///     This class holds ai submodules that interact with
    ///     a game and player to accomplish its own goals
    /// </summary>
    public class AiModule
    {
        // -------------------------------------------------------
        public AiModule(IPlayer player, IGame game)
        {
            //add all submodules
            subModules.Add(AiArchetype.RandomMoves, GetAi(AiArchetype.RandomMoves, player, game));
            
            //define current ai randomly
            CurrentAi = subModules.Keys.ToList().RandomItem();
        }
        
        // ---------------------------------------------------------

        #region Properties and Fields

        /// <summary>
        ///     Register with all the AiConfigs submodules.
        /// </summary>
        private readonly Dictionary<AiArchetype, AiBase> subModules = new Dictionary<AiArchetype, AiBase>();

        /// <summary>
        ///     AiConfigs that is current operating.
        /// </summary>
        private AiArchetype CurrentAi { get; set; }

        #endregion

        // ----------------------------------------------------------

        #region Factory

        /// <summary>
        ///     Small factory to create sub ai modules
        /// </summary>
        /// <param name="archetype"></param>
        /// <param name="player"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        static AiBase GetAi(AiArchetype archetype, IPlayer player, IGame game)
        {
            switch (archetype)
            {
                case AiArchetype.RandomMoves: return new AiRandomMoves(player, game);
                default:
                    throw new ArgumentOutOfRangeException(nameof(archetype), archetype, null);
            }
        }

        #endregion
        
        // --------------------------------------------------------------

        /// <summary>
        ///     Returns the best move according to hte current ai submodule.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public AttackMechanics.RuntimeAttackData[] GetBestMove()
        {
            if (!subModules.ContainsKey(CurrentAi))
                throw new ArgumentOutOfRangeException(
                    CurrentAi + " is not registered as a valid archetype in this module.");
            return subModules[CurrentAi].GetAttackMoves();
        }

        /// <summary>
        ///     Change the current archetype.
        /// </summary>
        /// <param name="archetype"></param>
        public void SwapAiToArchetype(AiArchetype archetype) => CurrentAi = archetype;

    }
}