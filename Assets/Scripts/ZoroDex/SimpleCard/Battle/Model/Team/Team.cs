using System.Collections.Generic;

using Tools;
using ZoroDex.SimpleCard.Data.Character;
using ZoroDex.SimpleCard.Data.Team;

namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     A concrete group of characters.
    /// </summary>
    public class Team : Collection<IRuntimeCharacter>,ITeam
    {
        private readonly ICharacterData capitainDataRegister;
        private readonly IReadOnlyList<ICharacterData> memberDataRegister;

        public Team(IPlayer player, TeamData teamData)
        {
            Owner = player;
            capitainDataRegister = teamData.GetCapitain();
            memberDataRegister = teamData.GetMembers();
            CreateTeam();

        }
        
        public IPlayer Owner { get; }
        public bool IsEmpty => Size == 0;
        public IRuntimeCharacter Captain { get; private set; }
        public List<IRuntimeCharacter> Members => Units;
        public bool HasTaunt => EvaluateTaunt();
        
        /// <summary>
        ///     Gets the member of the team by a specific index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        
        public IRuntimeCharacter GetMember(int index)
        {
            var unit = Get(index);
            return unit;
        }

        /// <summary>
        ///     Adds a new team member.
        /// </summary>
        /// <param name="member"></param>
        public void AddMember(IRuntimeCharacter member) => Add(member);

        /// <summary>
        ///     Removes a team member.
        /// </summary>
        /// <param name="member"></param>
        public void RemoveMember(IRuntimeCharacter member) => Remove(member);

        void CreateTeam()
        {
            if (capitainDataRegister != null)
            {
                var member = RuntimeCharacterFactory.Instance.Get();
                member.SetData(capitainDataRegister, Owner);
                Captain = member;
                AddMember(Captain);
                
            }

            foreach (var memberData in memberDataRegister)
            {
                var member = RuntimeCharacterFactory.Instance.Get();
                member.SetData(memberData,Owner);
                AddMember(member);

            }
            
        }

        /// <summary>
        ///     Gets the index of an specific member of the team.
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public int GetIndex(IRuntimeCharacter member) => Units.IndexOf(member);

        bool EvaluateTaunt()
        {
            foreach(var u in Units)
                if (u.Attributes.HasTaunt && !u.Attributes.IsDead)
                    return true;
            return false;
        }
    }
}