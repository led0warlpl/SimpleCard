using UnityEngine;
using ZoroDex.SimpleCard.Battle;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard.Data.Targets
{
    /// <summary>
    ///     Effects which taget the Player have to assign this SO to the target field.
    /// </summary>
    [CreateAssetMenu(menuName = SOPath + "/Player")]
    public class Target_Player : BaseTargetType
    {
        public override ITargetable[] GetTargets(IEffectable source, IGame gameData)
        {
            //get the player
            var player = gameData.TurnLogic.GetPlayer(PlayerSeat);
            
            //add it as a target
            var targets = new ITargetable[] {player};

            return targets;

        }
        
    }
}