

using UnityEngine;
using ZoroDex.SimpleCard.Battle.UI.Card;

namespace ZoroDex.SimpleCard.Data.Card
{
    //TODO: IUiCard <===
    public class CardFactory :PrefabPooler<CardFactory,IUiCard>
    {
        public CardDatabase Database => CardDatabase.Instance;

        public IUiCard Get(IRuntimeCard card)
        {
            var obj = Get(modelsPooled[0]);
            obj.Data.SetData(card);
            return obj;
        }

        protected override void OnRelease(GameObject prefabModel)
        {
            var cardUi = prefabModel.GetComponent<IUiCard>();
            cardUi.Restart();
            base.OnRelease(prefabModel);
        }

    }
}