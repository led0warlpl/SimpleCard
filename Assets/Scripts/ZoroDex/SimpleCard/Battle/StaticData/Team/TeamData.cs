using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using ZoroDex.SimpleCard.Data.Character;

namespace ZoroDex.SimpleCard.Data.Team
{
    public enum TeamId
    {
        Team1,
        Team2
    }
    
    [CreateAssetMenu(menuName="Data/Team")]
    public class TeamData : ScriptableObject
    {
        [SerializeField] [Tooltip("The capitan of the crew.")]
        private CharacterData capitain;

        [SerializeField] [Multiline] [Tooltip("Brief description of the team.")]
        private string description;

        [SerializeField] private TeamId id;

        [SerializeField] [Tooltip("All data of the members")]
        private List<CharacterData> members = new List<CharacterData>();

        public TeamId Id => id;

        public List<ICharacterData> GetMembers()
        {
            var allData = new List<ICharacterData>();
            members.ForEach(member => allData.Add(member));
            return allData;
        }

        public ICharacterData GetCapitain() => capitain;

    }
}