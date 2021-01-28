using SimpleCardGames.Battle.UI.Card;

namespace ZoroDex.SimpleCard.Data.Card
{
    //TODO: IUiCard <===
    public class CardFactory :PrefabPooler<CardFactory,IUiCard>
    {
        public CardDatabase Database => CardDatabase.Instance;
        
        //TODO IRuntimeCard

    }
}