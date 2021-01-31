using UnityEngine;
using ZoroDex.SimpleCard.Data.Team;

namespace ZoroDex.SimpleCard.Data.Team
{
   [CreateAssetMenu(menuName = "Data/Teams")]
   public class TeamsCurrentData : ScriptableObject
   {
      public TeamData EnemyTeam;
      public TeamData PlayerTeam;
   }
}