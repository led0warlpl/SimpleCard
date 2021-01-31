using UnityEngine;

namespace ZoroDex.SimpleCard.Data.Effects
{
    [CreateAssetMenu(menuName=Path +"/Damage")]
    public class DamageDataEffect : BaseEffectData,IDamager
    {
        public int GiveDamage(IDamageable target)
        {
            var damageDealt = target.TakeDamage(this, Amount);
           // OnDoneDamage(this, target, damageDealt);
            return damageDealt;
        }

        public override void Apply(ITargetable target, IEffectable source) => GiveDamage(target as IDamageable);

        // void OnDoneDamage(IDamager source, IDamageable target, int amount) =>
        //     GameEvents.Instance.Notify<IDoDamage>(i => i.OnDamage(source, target, amount));

    }
}