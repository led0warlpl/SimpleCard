using UnityEngine;
using ZoroDex.SimpleCard.Battle;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard.Data.Targets
{
    [CreateAssetMenu(menuName = SOPath+"/Player Team")]
    public class Target_PlayerTeam: BaseTargetType
    {
        public override ITargetable[] GetTargets(IEffectable source, IGame gameData)
        {
            //get player team
            var team = gameData.TurnLogic.GetPlayer(PlayerSeat).Team;

            var teamSize = team.Members.Count;
            
            //instantiate an array with the proper size
            var targets = new ITargetable[teamSize];
            
            //add all members to the target list
            for (var i = 0; i < teamSize; i++)
                targets[i] = team.GetMember(i);
            return targets;

        }
        
    }
}