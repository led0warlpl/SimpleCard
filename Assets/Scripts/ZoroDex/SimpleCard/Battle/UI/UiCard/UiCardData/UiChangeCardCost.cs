namespace ZoroDex.SimpleCard.Data.Card
{
    public class UiChangeCardCost : UiChangeCardText
    {
        protected override string GetText() => Handler.StaticData.CardCost.ToString();
    }
}