using UnityEngine.Animations;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard.Data.Card
{
    public class UiChangeCardMinion : UiChangeCardText
    {
        protected override string GetText()
        {
            if(Handler.StaticData.CardType == CardType.Minion)
                foreach(var effect in Handler.RuntimeData.Effects.Register)
                    foreach(var eff in effect.Value.Effects)
                        if (eff is SpawnDataEffect)
                        {
                            var minionData = (eff as SpawnDataEffect).GetCharacterSpawnedFromEffect();
                            return minionData.Attack + "/" + minionData.Defense;
                        }

            return "";

        }
        
    }
}