using UnityEngine;

namespace ZoroDex.SimpleCard.Data.Effects
{
    [CreateAssetMenu(menuName = Path +"/Draw")]
    public class DrawDataEffect : BaseEffectData
    {
        public override void Apply(ITargetable target, IEffectable source)
        {
            var drawable = target as IDrawable;
            drawable.DoDraw(Amount,source);

        }
        
    }
}