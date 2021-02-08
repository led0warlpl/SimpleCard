using System.Collections.Generic;
using UnityEngine;
using ZoroDex.SimpleCard.Battle;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard.Data.Targets
{
    [CreateAssetMenu(menuName = SOPath+"/Dynamic")]
    public class Target_Dynamic : BaseTargetType
    {
        private readonly List<ITargetable> targets = new List<ITargetable>();
        [SerializeField] private int targetAmount;
        public PlayerSeat TargetPlayer = PlayerSeat.Left;
        public override bool IsDynamic => true;
        public override int TargetAmount => targetAmount;

        public override ITargetable[] GetTargets(IEffectable source, IGame gameData) => targets.ToArray();

        void GetDynamicTarget(ITargetable target, PlayerSeat player)
        {
            if (player == TargetPlayer)
                targets.Add(target);
        }

        //TODO: wait implement ITargetResolver
        //public override void Subscribe(ITargetResolver Resolver) => Resolver.OnSelectTarget += GetDynamicTarget;
        
        

    }
}