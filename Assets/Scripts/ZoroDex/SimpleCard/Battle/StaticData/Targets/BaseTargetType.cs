using UnityEngine;
using ZoroDex.SimpleCard.Battle;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard.Data.Targets
{
    public abstract class BaseTargetType : ScriptableObject
    {
        protected const string SOPath = "Data/Targets";

        [SerializeField] [Multiline] [Tooltip("Brief description of the target for internal purposes.")]
        private string description;

        protected PlayerSeat PlayerSeat => PlayerSeat.Left;
        protected PlayerSeat OpponentSeat => PlayerSeat.Right;

        public virtual bool IsDynamic => false;
        public virtual int TargetAmount => 0;

        
         public abstract ITargetable[] GetTargets(IEffectable source, IGame gameData);
         //TODO: wait implementation ITargetResolver
         // public virtual void Subscribe(ITargetResolver Resolver){}
         //
         // public virtual void Unsubscribe(ITargetResolver Resolve){}

        

    }
}