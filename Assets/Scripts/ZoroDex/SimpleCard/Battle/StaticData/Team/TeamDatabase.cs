using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard.Data.Team
{
    public class TeamDatabase: Singleton<TeamData>
    {
        private const string PathDataBase = "Battle/TeamDatabase/Database";

        public TeamDatabase()
        {
            if (Teams == null)
                Teams = Resources.LoadAll<TeamData>(PathDataBase).ToList();
        }

        private List<TeamData> Teams { get; }

        public TeamData Get(TeamId id) => Teams?.Find(team => team.Id == id);

        public List<TeamData> GetFullList() => Teams;

    }
}