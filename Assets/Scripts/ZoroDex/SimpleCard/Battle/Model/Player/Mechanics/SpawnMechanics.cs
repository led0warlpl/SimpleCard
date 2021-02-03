﻿

using ZoroDex.SimpleCard.Battle;
using ZoroDex.SimpleCard.Data.Character;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     Spawn mechanics.
    /// </summary>
    public class SpawnMechanics : BasePlayerMechanics
    {
        public SpawnMechanics(IPlayer player) : base(player)
        {
            
        }

        public void DoSpawn(int amount, ICharacterData data, IEffectable source)
        {
            var member = RuntimeCharacterFactory.Instance.Get();
            member.SetData(data,Player);
            
            for(var i = 0;i< amount;i++)
                Player.Team.AddMember(member);
            
            OnSpawnCharacter(Player,member);
        }



        /// <summary>
        ///     Dispatch card spawn to the listeners.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="character"></param>
        void OnSpawnCharacter(IPlayer player, IRuntimeCharacter character) =>
            GameEvents.Instance.Notify<GameEvents.IPlayerSpawnCharacter>(i => i.OnSpawnCharacter(player, character));
    }
}